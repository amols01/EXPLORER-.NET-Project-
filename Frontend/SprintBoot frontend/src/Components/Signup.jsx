
import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { IconButton, Button, Input } from '@mui/material';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import styles from '../style_sheets/Login.module.css'; // Import the CSS module
import Background_signup from '../Assets/Background_signup.png'; // Import the background image

const Signup = () => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [password, setPassword] = useState('');
  const [reEnteredPassword, setReEnteredPassword] = useState('');
  const [profileImage, setProfileImage] = useState(null);
  const [showPassword, setShowPassword] = useState(false);

  const handleSignup = async (e) => {
    e.preventDefault();

    if (reEnteredPassword === password) {
      const newUser = {
        name,
        email,
        phoneNumber,
        password,
        role: 3 // Static role value
      };

      try {
        await axios.post("http://localhost:8080/api/auth/register", newUser);
        alert("Registration Successful!");
        setName('');
        setEmail('');
        setPhoneNumber('');
        setPassword('');
        setReEnteredPassword('');
        setProfileImage(null);
      } catch (err) {
        console.error(err);
      }
    } else {
      alert("Passwords do not match");
    }
  };

  const handleFileChange = (e) => {
    setProfileImage(e.target.files[0]);
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
                <h2 className="mb-5">Sign up</h2>
                <form onSubmit={handleSignup}>
                  <div className="form-outline mb-4">
                    <Input
                      type="text"
                      id="name"
                      placeholder="Full Name"
                      fullWidth
                      value={name}
                      onChange={(e) => setName(e.target.value)}
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
                  </div>

                  <div className="form-outline mb-4">
                    <Button
                      variant="contained"
                      component="label"
                      fullWidth
                      style={{
                        marginBottom: '1rem',
                        backgroundColor: '#1976d2', // Customize the color if needed
                        color: 'white',
                        textTransform: 'capitalize',
                      }}
                    >
                      {profileImage ? profileImage.name : 'Upload Profile Picture'}
                      <input
                        type="file"
                        hidden
                        accept="image/*"
                        onChange={handleFileChange}
                      />
                    </Button>
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

