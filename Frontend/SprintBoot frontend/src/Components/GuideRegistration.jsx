
import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';
import { IconButton, Button, Input } from '@mui/material';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import styles from '../style_sheets/Login.module.css';
import Background_GuideRegistration from '../Assets/Background_GuideRegistration.png';

const Guide_Registration = () => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [password, setPassword] = useState('');
  const [reEnteredPassword, setReEnteredPassword] = useState('');
  const [aadharNumber, setAadharNumber] = useState('');
  const [panNumber, setPanNumber] = useState('');
  const [accountNumber, setAccountNumber] = useState('');
  const [address, setAddress] = useState('');
  const [showPassword, setShowPassword] = useState(false);
  const navigate = useNavigate();

  const handleGuideSignup = async (e) => {
    e.preventDefault();
    if (reEnteredPassword === password) {
      const userData = {
        name,
        email,
        phoneNumber,
        password,
        role: 2, // Static role ID for Guide
        address,
        aadharNumber,
        panNumber,
        accountNumber,
      };

      try {
        await axios.post('http://localhost:8080/api/auth/register/guide', userData, {
          headers: {
            'Content-Type': 'application/json',
          },
        });
        alert("Guide Registration Successful!");
        setName('');
        setEmail('');
        setPhoneNumber('');
        setPassword('');
        setReEnteredPassword('');
        setAadharNumber('');
        setPanNumber('');
        setAccountNumber('');
        setAddress('');
        navigate('/guide-dashboard'); // Navigate to the guide dashboard after successful registration
      } catch (err) {
        console.error(err);
        alert("Guide Registration Failed. Please try again.");
      }
    } else {
      alert("Passwords do not match");
    }
  };

  return (
    <div
      className={styles.gradientForm}
      style={{
        backgroundImage: `url(${Background_GuideRegistration})`,
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        height: '100vh',
        overflow: 'auto',
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
                backgroundColor: "rgba(255, 255, 255, 0.5)",
                backdropFilter: "blur(10px)",
              }}
            >
              <div className="card-body p-5 text-center">
                <h2 className="mb-5">Welcome to Guide Registration</h2>
                <form onSubmit={handleGuideSignup}>
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
                    <Input
                      type="text"
                      id="aadharNumber"
                      placeholder="Aadhar Number"
                      fullWidth
                      value={aadharNumber}
                      onChange={(e) => setAadharNumber(e.target.value)}
                      style={{ marginBottom: '1rem' }}
                    />
                  </div>

                  <div className="form-outline mb-4">
                    <Input
                      type="text"
                      id="panNumber"
                      placeholder="PAN Number"
                      fullWidth
                      value={panNumber}
                      onChange={(e) => setPanNumber(e.target.value)}
                      style={{ marginBottom: '1rem' }}
                    />
                  </div>

                  <div className="form-outline mb-4">
                    <Input
                      type="text"
                      id="accountNumber"
                      placeholder="Account Number"
                      fullWidth
                      value={accountNumber}
                      onChange={(e) => setAccountNumber(e.target.value)}
                      style={{ marginBottom: '1rem' }}
                    />
                  </div>

                  <div className="form-outline mb-4">
                    <Input
                      type="text"
                      id="address"
                      placeholder="Address"
                      fullWidth
                      value={address}
                      onChange={(e) => setAddress(e.target.value)}
                      style={{ marginBottom: '1rem' }}
                    />
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

                  <div
                    className="form-check d-flex justify-content-start mb-4"
                    style={{ marginTop: "25px" }}
                  >
                    <input
                      className="form-check-input"
                      type="checkbox"
                      value=""
                      id="form1Example3"
                      required
                    />
                    <label
                      className="form-check-label"
                      htmlFor="form1Example3"
                      style={{ marginLeft: "10px", color: "#585555" }}
                    >
                      Agree to terms & conditions
                    </label>
                  </div>

                  <Button
                    type="submit"
                    variant="contained"
                    color="primary"
                    style={{ marginTop: "15px", width: "fit-content" }}
                  >
                    Register
                  </Button>

                  <hr className="my-4" style={{ opacity: "0.15" }} />

                  <div className="row">
                    <div className="col">
                      <Link
                        to="/guide-login"
                        style={{
                          color: "blue",
                          textDecoration: "none",
                        }}
                      >
                        Already have an account? Login
                      </Link>
                    </div>
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

export default Guide_Registration;
