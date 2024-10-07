
import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { IconButton, Button, Input, AppBar, Toolbar, Typography } from '@mui/material';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import styles from '../style_sheets/Login.module.css'; // Import the CSS module
import Background_AdminRegistration from '../Assets/Background_AdminRegistration.png'; // Import the background image

const AdminRegistration = () => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [password, setPassword] = useState('');
  const [reEnteredPassword, setReEnteredPassword] = useState('');
  const [showPassword, setShowPassword] = useState(false);
  const role = 1; // Admin role is statically set to 1

  const handleAdminSignup = async (e) => {
    e.preventDefault();

    if (reEnteredPassword === password) {
      const newAdmin = {
        name: name,
        email,
        phoneNumber,
        password,
        role, // Sending the static role
      };

      try {
        await axios.post("http://localhost:8080/api/auth/register", newAdmin);
        alert("Admin Registration Successful!");
        // Clear fields after successful registration
        setName('');
        setEmail('');
        setPhoneNumber('');
        setPassword('');
        setReEnteredPassword('');
      } catch (err) {
        console.error(err);
        alert("An error occurred during registration.");
      }
    } else {
      alert("Passwords do not match");
    }
  };

  return (
    <div>
      {/* AppBar */}
      <AppBar
        position="fixed"
        sx={{
          width: '100%',
          backgroundColor: '#1976d2',
          boxShadow: '0px 2px 5px rgba(0,0,0,0.2)',
        }}
      >
        <Toolbar>
          <Typography variant="h6" noWrap sx={{ flexGrow: 1 }}>
            Admin Registration
          </Typography>
          <Button color="inherit" component={Link} to="/admin-dashboard">
            Dashboard
          </Button>
          <Button color="inherit" component={Link} to="/logout">
            Logout
          </Button>
        </Toolbar>
      </AppBar>

      {/* Main Content */}
      <div
        className={styles.gradientForm}
        style={{
          backgroundImage: `url(${Background_AdminRegistration})`,
          backgroundSize: 'cover',
          backgroundPosition: 'center',
          height: '100vh',
          overflow: 'auto',
          paddingTop: '64px',
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
                  <h2 className="mb-5">Welcome to Admin Registration</h2>
                  <form onSubmit={handleAdminSignup}>
                    <div className="form-outline mb-4">
                      <Input
                        type="text"
                        id="name"
                        placeholder="Full Name"
                        fullWidth
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required
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
                        required
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
                        required
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
                        required
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
                        required
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

                    <div className="d-flex align-items-center justify-content-center pb-4">
                      <p className="mb-0 me-2">Already have an account?</p>
                      <Link to="/admin-login">Sign in</Link>
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AdminRegistration;

