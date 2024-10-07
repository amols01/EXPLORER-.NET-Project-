

// import React, { useState } from 'react';
// import { Link, useNavigate } from 'react-router-dom';
// import { TextField, Button, Typography, Grid, Paper, FormControlLabel, Checkbox } from '@mui/material';
// import { loginUser } from '../Services/TravelerService.js'; // Import the API call function
// import Background_login from '../Assets/Background_login.png';

// const Login = (props) => {
//   const navigate = useNavigate();
//   const [userEnteredInfo, setUserEnteredInfo] = useState({ email: "", password: "" });
//   const [errors, setErrors] = useState({});

//   const handleInputChange = (event) => {
//     const { name, value } = event.target;
//     setUserEnteredInfo({ ...userEnteredInfo, [name]: value });
//   };

//   const validate = () => {
//     const newErrors = {};
    
//     // Email validation
//     if (!userEnteredInfo.email) {
//       newErrors.email = "Email is required";
//     } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(userEnteredInfo.email)) {
//       newErrors.email = "Invalid email format";
//     }

//     // Password validation
//     if (!userEnteredInfo.password) {
//       newErrors.password = "Password is required";
//     } else if (userEnteredInfo.password.length < 8) {
//       newErrors.password = "Password must be at least 8 characters long";
//     } else if (!/[A-Z]/.test(userEnteredInfo.password)) {
//       newErrors.password = "Password must contain at least one uppercase letter";
//     } else if (!/[a-z]/.test(userEnteredInfo.password)) {
//       newErrors.password = "Password must contain at least one lowercase letter";
//     } else if (!/[0-9]/.test(userEnteredInfo.password)) {
//       newErrors.password = "Password must contain at least one number";
//     } else if (!/[!@#$%^&*]/.test(userEnteredInfo.password)) {
//       newErrors.password = "Password must contain at least one special character (!@#$%^&*)";
//     }

//     setErrors(newErrors);
//     return Object.keys(newErrors).length === 0;
//   };

//   const handleSubmit = async (event) => {
//     event.preventDefault();

//     if (validate()) {
//       try {
//         const user = await loginUser(userEnteredInfo); // Call the API
//         if (user) {
//           props.login(user._id); // Assuming this handles setting user state
//           navigate(`/profile/home/${user._id}`);
//         }
//       } catch (error) {
//         alert("Login failed. Please check your email and password and try again.");
//       }
//     }
//   };

//   return (
//     <Grid container justifyContent="center" alignItems="center" style={{ minHeight: '100vh', backgroundImage: `url(${Background_login})`, backgroundSize: 'cover', backgroundPosition: 'center' }}>
//       <Paper elevation={3} style={{ padding: '2rem', borderRadius: '15px', maxWidth: '400px', width: '100%', backgroundColor: 'rgba(255, 255, 255, 0.8)' }}>
//         <Typography variant="h4" align="center" gutterBottom>Sign in</Typography>
//         <form onSubmit={handleSubmit}>
//           <TextField
//             label="Email"
//             name="email"
//             type="email"
//             value={userEnteredInfo.email}
//             onChange={handleInputChange}
//             fullWidth
//             margin="normal"
//             error={Boolean(errors.email)}
//             helperText={errors.email}
//           />
//           <TextField
//             label="Password"
//             name="password"
//             type="password"
//             value={userEnteredInfo.password}
//             onChange={handleInputChange}
//             fullWidth
//             margin="normal"
//             error={Boolean(errors.password)}
//             helperText={errors.password}
//           />
//           <FormControlLabel
//             control={<Checkbox />}
//             label="Remember me"
//             style={{ marginTop: '1rem' }}
//           />
//           <Button
//             type="submit"
//             variant="contained"
//             color="primary"
//             fullWidth
//             style={{ marginTop: '1rem' }}
//           >
//             Login
//           </Button>
//         </form>
//         <Typography align="center" variant="body2" color="textSecondary" style={{ marginTop: '1rem' }}>
//           Don't have an account? <Link to="/signup">Sign up</Link>
//         </Typography>
//         <Typography align="center" variant="body2" color="textSecondary" style={{ marginTop: '0.5rem' }}>
//           Admin? <Link to="/admin-login">Admin Login</Link>
//         </Typography>
//       </Paper>
//     </Grid>
//   );
// };

// export default Login;



import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { TextField, Button, Typography, Grid, Paper, FormControlLabel, Checkbox } from '@mui/material';
import { loginUser } from '../Services/TravelerService.js'; // Import the API call function
import Background_login from '../Assets/Background_login.png';

const Login = (props) => {
  const navigate = useNavigate();
  const [userEnteredInfo, setUserEnteredInfo] = useState({ email: "", password: "" });
  const [errors, setErrors] = useState({});

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setUserEnteredInfo({ ...userEnteredInfo, [name]: value });
  };

  const validate = () => {
    const newErrors = {};

    // Email validation
    if (!userEnteredInfo.email) {
      newErrors.email = "Email is required";
    }

    // Password validation
    if (!userEnteredInfo.password) {
      newErrors.password = "Password is required";
    } else if (userEnteredInfo.password.length < 8) {
      newErrors.password = "Password must be at least 8 characters long";
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    if (validate()) {
      try {
        const user = await loginUser(userEnteredInfo); // Call the API
        if (user) {
          props.login(user._id); // Assuming this handles setting user state
          navigate(`/profile/home/${user._id}`);
        }
      } catch (error) {
        alert("Login failed. Please check your email and password and try again.");
      }
    }
  };

  return (
    <Grid container justifyContent="center" alignItems="center" style={{ minHeight: '100vh', backgroundImage: `url(${Background_login})`, backgroundSize: 'cover', backgroundPosition: 'center' }}>
      <Paper elevation={3} style={{ padding: '2rem', borderRadius: '15px', maxWidth: '400px', width: '100%', backgroundColor: 'rgba(255, 255, 255, 0.8)' }}>
        <Typography variant="h4" align="center" gutterBottom> Traveler Sign in</Typography>
        <form onSubmit={handleSubmit}>
          <TextField
            label="Email"
            name="email"
            type="email"
            value={userEnteredInfo.email}
            onChange={handleInputChange}
            fullWidth
            margin="normal"
            error={Boolean(errors.email)}
            helperText={errors.email}
          />
          <TextField
            label="Password"
            name="password"
            type="password"
            value={userEnteredInfo.password}
            onChange={handleInputChange}
            fullWidth
            margin="normal"
            error={Boolean(errors.password)}
            helperText={errors.password}
          />
          <FormControlLabel
            control={<Checkbox />}
            label="Remember me"
            style={{ marginTop: '1rem' }}
          />
          <Button
            type="submit"
            variant="contained"
            color="primary"
            fullWidth
            style={{ marginTop: '1rem' }}
          >
            Login
          </Button>
        </form>
        <Typography align="center" variant="body2" color="textSecondary" style={{ marginTop: '1rem' }}>
          Don't have an account? <Link to="/signup">Sign up</Link>
        </Typography>
        <Typography align="center" variant="body2" color="textSecondary" style={{ marginTop: '0.5rem' }}>
          Admin? <Link to="/admin-login">Admin Login</Link>
        </Typography>
      </Paper>
    </Grid>
  );
};

export default Login;
