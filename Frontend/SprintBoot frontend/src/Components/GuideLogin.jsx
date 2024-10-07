
import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import Background_GuideLogin from '../Assets/Background_GuideLogin.png';

const Guide_Login = () => {
  const navigate = useNavigate();
  const initialUserEnteredInfo = {
    email: "",
    password: ""
  };

  const [userEnteredInfo, setUserEnteredInfo] = useState(initialUserEnteredInfo);

  useEffect(() => {
    // Clear any existing tokens to ensure a fresh start
    localStorage.setItem('authToken', ''); // Clear the token by setting it to an empty string
    localStorage.removeItem('userRole');
    localStorage.removeItem('tokenExpiration');

    // Check if the user is already logged in
    const token = localStorage.getItem('authToken');
    const role = localStorage.getItem('userRole');

    if (token && role === 'ROLE_Guide') {
      navigate('/guide_dashboard'); // Redirect to guide dashboard if already logged in
    }
  }, [navigate]);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setUserEnteredInfo({ ...userEnteredInfo, [name]: value });
  };

  const findUser = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post('http://localhost:8080/api/auth/login', {
        email: userEnteredInfo.email,
        password: userEnteredInfo.password,
      });

      // Store the JWT token and role in local storage
      if (response.data.jwt) {
        localStorage.setItem('authToken', response.data.jwt);
        localStorage.setItem('userRole', response.data.role); // Store the user's role

        // Set token expiration handling
        const expirationTime = Date.now() + 3600000; // 1 hour expiration
        localStorage.setItem('tokenExpiration', expirationTime); // Store expiration time
      }

      // Redirect based on role
      if (response.data.role === 'ROLE_Guide') {
        navigate('/guide-dashboard');
      } else {
        alert("Access denied. Only guides can log in.");
      }
    } catch (err) {
      console.error(err);
      alert("Login failed. Please check your credentials.");
    }
  };

  const handleLogout = () => {
    localStorage.removeItem('authToken');

    // Clear any other stored user data
    localStorage.removeItem('userRole');
    localStorage.removeItem('tokenExpiration');
    navigate('/'); // Redirect to home or login page
  };

  useEffect(() => {
    // Auto logout if the token is expired
    const checkTokenExpiration = () => {
      const tokenExpiration = localStorage.getItem('tokenExpiration');
      if (tokenExpiration && Date.now() > tokenExpiration) {
        handleLogout(); // Call logout if token is expired
      }
    };

    const interval = setInterval(checkTokenExpiration, 60000); // Check every minute

    return () => clearInterval(interval); // Cleanup interval on component unmount
  }, []);

  return (
    <>
      <section
        style={{
          backgroundImage: `url(${Background_GuideLogin})`,
          backgroundSize: 'cover',
          backgroundPosition: 'center',
          height: '100vh',
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center'
        }}
      >
        <div
          style={{
            backgroundColor: 'rgba(255, 255, 255, 0.8)',
            padding: '2rem',
            borderRadius: '15px',
            boxShadow: 'rgba(99, 99, 99, 0.2) 0px 2px 8px 0px',
            width: '100%',
            maxWidth: '400px',
            textAlign: 'center'
          }}
        >
          <h2 className="mb-5">Guide Sign in</h2>

          <div className="form-outline mb-4">
            <input 
              type="text" 
              id="email" 
              className="form-control" 
              placeholder="Email"
              value={userEnteredInfo.email} 
              onChange={handleInputChange} 
              name="email" 
            />
          </div>

          <div className="form-outline mb-4">
            <input 
              type="password" 
              id="password" 
              className="form-control" 
              placeholder="Password" 
              value={userEnteredInfo.password} 
              onChange={handleInputChange} 
              name="password" 
            />
          </div>

          <button 
            style={{
              width: '100px',
              textDecoration: 'none',
              color: 'white',
              fontWeight: '700',
              backgroundColor: '#4468E2',
              textAlign: 'center',
              padding: '7px 30px',
              borderRadius: '5px',
              outlineStyle: 'solid',
              outlineWidth: '2px',
              marginTop: '15px'
            }} 
            type="submit" 
            onClick={findUser}
          >
            Login
          </button>
        </div>
      </section>
    </>
  );
};

export default Guide_Login;
