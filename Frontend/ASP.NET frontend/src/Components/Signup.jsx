

import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { IconButton, Button, Input } from '@mui/material';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import styles from '../style_sheets/Login.module.css'; // Import the CSS module
import Background_signup from '../Assets/Background_signup.png'; // Import the background image
import { registerUser } from '../Services/TravelerService.js'; // Import the separated API call function

const Signup = () => {
  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [password, setPassword] = useState('');
  const [reEnteredPassword, setReEnteredPassword] = useState('');
  const [showPassword, setShowPassword] = useState(false);
  const [errors, setErrors] = useState({});

  const validateEmail = (email) => {
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return regex.test(email);
  };

  const validatePhoneNumber = (phoneNumber) => {
    const regex = /^\d{10}$/;
    return regex.test(phoneNumber);
  };

  const validatePassword = (password) => {
    const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    return regex.test(password);
  };

  const handleSignup = async (e) => {
    e.preventDefault();

    let formErrors = {};

    if (!validateEmail(email)) {
      formErrors.email = "Please enter a valid email address.";
    }
    if (!validatePhoneNumber(phoneNumber)) {
      formErrors.phoneNumber = "Phone number must be exactly 10 digits.";
    }
    if (!validatePassword(password)) {
      formErrors.password = "Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, a number, and a special character.";
    }
    if (reEnteredPassword !== password) {
      formErrors.reEnteredPassword = "Passwords do not match.";
    }

    if (Object.keys(formErrors).length === 0) {
      const newUser = {
        username,
        email,
        phoneNumber,
        password,
      };

      try {
        await registerUser(newUser); // Call the separated API function
        setUsername('');
        setEmail('');
        setPhoneNumber('');
        setPassword('');
        setReEnteredPassword('');
      } catch (err) {
        // Error handling can be done here if needed
      }
    } else {
      setErrors(formErrors);
    }
  };

  return (
    <div
      className={styles.gradientForm}
      style={{
        backgroundImage: `url(${Background_signup})`,
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        height: '100vh',
        overflow: 'auto', // Ensures background image covers the page while scrolling
      }}
    >
      <div className="container py-5 h-100">
        <div className="row d-flex justify-content-center align-items-center h-100">
          <div className="col-12 col-md-8 col-lg-6 col-xl-5">
            <div
              className="card shadow-2-strong"
              style={{
                borderRadius: "15px",
                borderColor: "white",
                boxShadow: "rgba(99, 99, 99, 0.2) 0px 2px 8px 0px",
                backgroundColor: "rgba(255, 255, 255, 0.3)", // Semi-transparent background color
                backdropFilter: "blur(10px)", // Blur effect for frosted glass look
                padding: '1.5rem',
                border: 'none'
              }}
            >
              <div className="card-body text-center">
                <h2 className="mb-5"> Traveler Sign up</h2>
                <form onSubmit={handleSignup}>
                  <div className="form-outline mb-4">
                    <Input
                      type="text"
                      id="username"
                      placeholder="Username"
                      fullWidth
                      value={username}
                      onChange={(e) => setUsername(e.target.value)}
                      style={{ marginBottom: '1rem' }}
                    />
                  </div>

                  <div className="form-outline mb-4">
                    <Input
                      type="email"
                      id="email"
                      placeholder="Email"
                      fullWidth
                      value={email}
                      onChange={(e) => setEmail(e.target.value)}
                      style={{ marginBottom: '1rem' }}
                    />
                    {errors.email && <p className="text-danger">{errors.email}</p>}
                  </div>

                  <div className="form-outline mb-4">
                    <Input
                      type="text"
                      id="phoneNumber"
                      placeholder="Phone Number"
                      fullWidth
                      value={phoneNumber}
                      onChange={(e) => setPhoneNumber(e.target.value)}
                      style={{ marginBottom: '1rem' }}
                    />
                    {errors.phoneNumber && <p className="text-danger">{errors.phoneNumber}</p>}
                  </div>

                  <div className="form-outline mb-4 position-relative">
                    <Input
                      type={showPassword ? 'text' : 'password'}
                      id="password"
                      placeholder="Password"
                      fullWidth
                      value={password}
                      onChange={(e) => setPassword(e.target.value)}
                      style={{ marginBottom: '1rem' }}
                      autoComplete="off"
                    />
                    <IconButton
                      onClick={() => setShowPassword(!showPassword)}
                      style={{
                        position: 'absolute',
                        right: 10,
                        top: '50%',
                        transform: 'translateY(-50%)',
                        color: '#000',
                      }}
                    >
                      {showPassword ? <VisibilityOff /> : <Visibility />}
                    </IconButton>
                    {errors.password && <p className="text-danger">{errors.password}</p>}
                  </div>

                  <div className="form-outline mb-4 position-relative">
                    <Input
                      type={showPassword ? 'text' : 'password'}
                      id="reEnteredPassword"
                      placeholder="Confirm Password"
                      fullWidth
                      value={reEnteredPassword}
                      onChange={(e) => setReEnteredPassword(e.target.value)}
                      style={{ marginBottom: '1rem' }}
                      autoComplete="off"
                    />
                    <IconButton
                      onClick={() => setShowPassword(!showPassword)}
                      style={{
                        position: 'absolute',
                        right: 10,
                        top: '50%',
                        transform: 'translateY(-50%)',
                        color: '#000',
                      }}
                    >
                      {showPassword ? <VisibilityOff /> : <Visibility />}
                    </IconButton>
                    {errors.reEnteredPassword && <p className="text-danger">{errors.reEnteredPassword}</p>}
                  </div>

                  <div className="form-check d-flex justify-content-start mb-4" style={{ marginTop: "25px" }}>
                    <input className="form-check-input" type="checkbox" value="" id="form1Example3" />
                    <label className="form-check-label" htmlFor="form1Example3" style={{ marginLeft: "10px", color: "#585555" }}>
                      Agree to terms & conditions
                    </label>
                  </div>

                  <Button
                    type="submit"
                    variant="contained"
                    color="primary"
                    style={{ marginTop: "15px", width: "fit-content" }}
                  >
                    Sign up
                  </Button>

                  <hr className="my-4" style={{ opacity: "0.15" }} />

                  <div className="d-flex align-items-center justify-content-center pb-4">
                    <p className="mb-0 me-2">Already have an account?</p>
                    <Link to="/login">Sign in</Link>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Signup;
