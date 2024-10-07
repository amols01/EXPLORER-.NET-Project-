

import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Background_AdminLogin from '../Assets/Background_AdminLogin.jpg';
import { loginAdmin } from '../Services/AdminServices'; // Import the API call function

const AdminLogin = () => {
  const navigate = useNavigate();
  const initialUserEnteredInfo = {
    user_name: "",
    password: ""
  };

  const [userEnteredInfo, setUserEnteredInfo] = useState(initialUserEnteredInfo);
  const [error, setError] = useState(null); // Add state to manage error

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setUserEnteredInfo({ ...userEnteredInfo, [name]: value });
  };

  const findUser = async (e) => {
    e.preventDefault();

    const { user_name, password } = userEnteredInfo;

    try {
      const credentials = {
        email: user_name,
        password: password
      };

      const response = await loginAdmin(credentials); // Call the API function

      if (response) {
        // Assuming successful login redirects to the admin dashboard
        navigate('/admin-dashboard');
      }
    } catch (error) {
      setError(error.message); // Set the error state if login fails
    }
  };

  return (
    <>
      {/* Login Section */}
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

          {/* Display error message */}
          {error && <div style={{ color: 'red', marginBottom: '1rem' }}>{error}</div>}

          <div className="form-outline mb-4">
            <input 
              type="text" 
              id="user_name" 
              className="form-control" 
              placeholder="Username"
              value={userEnteredInfo.user_name} 
              onChange={handleInputChange} 
              name="user_name" 
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

export default AdminLogin;
