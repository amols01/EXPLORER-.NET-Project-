
import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import Background_AdminLogin from '../Assets/Background_AdminLogin.jpg';

const AdminLogin = () => {
  const navigate = useNavigate();
  const [userEnteredInfo, setUserEnteredInfo] = useState({ email: "", password: "" });

  useEffect(() => {
    // Clear any existing tokens to ensure a fresh start
    localStorage.removeItem('token');
    localStorage.removeItem('userRole');
    localStorage.removeItem('tokenExpiration');

    // Check if the user is already logged in
    const token = localStorage.getItem('token');
    const role = localStorage.getItem('userRole');

    if (token && role === 'ROLE_Admin') {
      navigate('/admin-dashboard'); // Redirect to dashboard if already logged in
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

      // Check if the response contains the JWT token
      if (response.data.jwt) {
        localStorage.setItem('token', response.data.jwt);
        localStorage.setItem('userRole', response.data.role); // Store the user's role

        // Set token expiration
        const expirationTime = Date.now() + 3600000; 
        localStorage.setItem('tokenExpiration', expirationTime); 

        // Redirect based on role
        if (response.data.role === 'ROLE_Admin') {
          navigate('/admin-dashboard');
        } else {
          alert("Access denied. Only admin can log in.");
        }
      } else {
        alert("Login failed. Please check your credentials.");
      }
    } catch (err) {
      console.error('Login error:', err);
      alert("Login failed. Please check your credentials.");
    }
  };

  const handleLogout = () => {
    localStorage.removeItem('token');
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
    <section
      style={{
        backgroundImage: `url(${Background_AdminLogin})`,
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
          backgroundColor: 'rgba(255, 255, 255, 0.8)', // Semi-transparent white background for the form
          padding: '2rem',
          borderRadius: '15px',
          boxShadow: 'rgba(99, 99, 99, 0.2) 0px 2px 8px 0px',
          width: '100%',
          maxWidth: '400px',
          textAlign: 'center'
        }}
      >
        <h2 className="mb-5">Welcome Admin</h2>

        <form onSubmit={findUser}>
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
            type="submit"
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
          >
            Login
          </button>
        </form>
      </div>
    </section>
  );
};

export default AdminLogin;

