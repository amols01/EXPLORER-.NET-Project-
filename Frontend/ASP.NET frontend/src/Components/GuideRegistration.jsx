// import React, { useState } from 'react';
// import { Link } from 'react-router-dom';
// import axios from 'axios';
// import { IconButton, Button, Input } from '@mui/material';
// import Visibility from '@mui/icons-material/Visibility';
// import VisibilityOff from '@mui/icons-material/VisibilityOff';
// import styles from '../style_sheets/Login.module.css'; // Import the CSS module
// import Background_GuideRegistration from '../Assets/Background_GuideRegistration.png'; // Import the background image

// const Guide_Registration = () => {
//   const [guideName, setGuideName] = useState('');
//   const [email, setEmail] = useState('');
//   const [phoneNumber, setPhoneNumber] = useState('');
//   const [password, setPassword] = useState('');
//   const [reEnteredPassword, setReEnteredPassword] = useState('');
//   const [profileImage, setProfileImage] = useState(null);
//   const [showPassword, setShowPassword] = useState(false);

//   const handleGuideSignup = async (e) => {
//     e.preventDefault();

//     if (reEnteredPassword === password) {
//       const newGuide = {
//         guideName,
//         email,
//         phoneNumber,
//         password,
//       };

//       try {
//         await axios.post("http://localhost:8070/guide/new", newGuide);
//         alert("Guide Registration Successful!");
//         setGuideName('');
//         setEmail('');
//         setPhoneNumber('');
//         setPassword('');
//         setReEnteredPassword('');
//         setProfileImage(null);
//       } catch (err) {
//         console.error(err);
//       }
//     } else {
//       alert("Passwords do not match");
//     }
//   };

//   const handleFileChange = (e) => {
//     setProfileImage(e.target.files[0]);
//   };

//   return (
//     <div
//       className={styles.gradientForm}
//       style={{
//         backgroundImage: `url(${Background_GuideRegistration})`,
//         backgroundSize: 'cover',
//         backgroundPosition: 'center',
//         height: '100vh',
//         overflow: 'auto', // Ensures background image covers the page while scrolling
//       }}
//     >
//       <div className="container py-5 h-100">
//         <div className="row d-flex justify-content-center align-items-center h-100">
//           <div className="col-12 col-md-8 col-lg-6 col-xl-5">
//             <div
//               className="card shadow-2-strong"
//               style={{
//                 borderRadius: "15px",
//                 borderColor: "white",
//                 boxShadow: "rgba(99, 99, 99, 0.2) 0px 2px 8px 0px",
//                 backgroundColor: "rgba(255, 255, 255, 0.5)", // Set the background color to be semi-transparent
//                 backdropFilter: "blur(10px)", // Add blur effect for a frosted glass look
//               }}
//             >
//               <div className="card-body p-5 text-center">
//                 <h2 className="mb-5">Welcome to Guide Registration</h2>
//                 <form onSubmit={handleGuideSignup}>
//                   <div className="form-outline mb-4">
//                     <Input
//                       type="text"
//                       id="guideName"
//                       placeholder="Full Name"
//                       fullWidth
//                       value={guideName}
//                       onChange={(e) => setGuideName(e.target.value)}
//                       style={{ marginBottom: '1rem' }}
//                     />
//                   </div>

//                   <div className="form-outline mb-4">
//                     <Input
//                       type="email"
//                       id="email"
//                       placeholder="Email"
//                       fullWidth
//                       value={email}
//                       onChange={(e) => setEmail(e.target.value)}
//                       style={{ marginBottom: '1rem' }}
//                     />
//                   </div>

//                   <div className="form-outline mb-4">
//                     <Input
//                       type="text"
//                       id="phoneNumber"
//                       placeholder="Phone Number"
//                       fullWidth
//                       value={phoneNumber}
//                       onChange={(e) => setPhoneNumber(e.target.value)}
//                       style={{ marginBottom: '1rem' }}
//                     />
//                   </div>

//                   <div className="form-outline mb-4">
//                     <Button
//                       variant="contained"
//                       component="label"
//                       fullWidth
//                       style={{
//                         marginBottom: '1rem',
//                         backgroundColor: '#1976d2', // Customize the color if needed
//                         color: 'white',
//                         textTransform: 'capitalize',
//                       }}
//                     >
//                       {profileImage ? profileImage.name : 'Upload Profile Picture'}
//                       <input
//                         type="file"
//                         hidden
//                         accept="image/*"
//                         onChange={handleFileChange}
//                       />
//                     </Button>
//                   </div>

//                   <div className="form-outline mb-4 position-relative">
//                     <Input
//                       type={showPassword ? 'text' : 'password'}
//                       id="password"
//                       placeholder="Password"
//                       fullWidth
//                       value={password}
//                       onChange={(e) => setPassword(e.target.value)}
//                       style={{ marginBottom: '1rem' }}
//                       autoComplete="off"
//                     />
//                     <IconButton
//                       onClick={() => setShowPassword(!showPassword)}
//                       style={{
//                         position: 'absolute',
//                         right: 10,
//                         top: '50%',
//                         transform: 'translateY(-50%)',
//                         color: '#000',
//                       }}
//                     >
//                       {showPassword ? <VisibilityOff /> : <Visibility />}
//                     </IconButton>
//                   </div>

//                   <div className="form-outline mb-4 position-relative">
//                     <Input
//                       type={showPassword ? 'text' : 'password'}
//                       id="reEnteredPassword"
//                       placeholder="Confirm Password"
//                       fullWidth
//                       value={reEnteredPassword}
//                       onChange={(e) => setReEnteredPassword(e.target.value)}
//                       style={{ marginBottom: '1rem' }}
//                       autoComplete="off"
//                     />
//                     <IconButton
//                       onClick={() => setShowPassword(!showPassword)}
//                       style={{
//                         position: 'absolute',
//                         right: 10,
//                         top: '50%',
//                         transform: 'translateY(-50%)',
//                         color: '#000',
//                       }}
//                     >
//                       {showPassword ? <VisibilityOff /> : <Visibility />}
//                     </IconButton>
//                   </div>

//                   <div
//                     className="form-check d-flex justify-content-start mb-4"
//                     style={{ marginTop: "25px" }}
//                   >
//                     <input
//                       className="form-check-input"
//                       type="checkbox"
//                       value=""
//                       id="form1Example3"
//                     />
//                     <label
//                       className="form-check-label"
//                       htmlFor="form1Example3"
//                       style={{ marginLeft: "10px", color: "#585555" }}
//                     >
//                       Agree to terms & conditions
//                     </label>
//                   </div>

//                   <Button
//                     type="submit"
//                     variant="contained"
//                     color="primary"
//                     style={{ marginTop: "15px", width: "fit-content" }}
//                   >
//                     Register
//                   </Button>

//                   <hr className="my-4" style={{ opacity: "0.15" }} />

//                   <div className="d-flex align-items-center justify-content-center pb-4">
//                     <p className="mb-0 me-2">Already have an account?</p>
//                     <Link to="/guide-login">Sign in</Link>
//                   </div>
//                 </form>
//               </div>
//             </div>
//           </div>
//         </div>
//       </div>
//     </div>
//   );
// };

// export default Guide_Registration;


import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { IconButton, Button, Input } from '@mui/material';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import styles from '../style_sheets/Login.module.css'; // Import the CSS module
import Background_GuideRegistration from '../Assets/Background_GuideRegistration.png'; // Import the background image
import { registerGuide } from '../Services/GuideService.js'; // Import the API call function

const Guide_Registration = () => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [password, setPassword] = useState('');
  const [reEnteredPassword, setReEnteredPassword] = useState('');
  //const [profileImage, setProfileImage] = useState(null);
  const [showPassword, setShowPassword] = useState(false);

  // Regular expressions for validation
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  const phoneNumberRegex = /^\d{10}$/;
  const passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@])[A-Za-z\d@]{8,}$/; // At least 8 characters, at least one letter and one number

  const handleGuideSignup = async (e) => {
    e.preventDefault();

    // Validation
    if (!emailRegex.test(email)) {
      alert("Invalid email format.");
      return;
    }

    if (!phoneNumberRegex.test(phoneNumber)) {
      alert("Phone number must be 10 digits.");
      return;
    }

    if (!passwordRegex.test(password)) {
      alert("Password must be at least 8 characters long, and include at least one letter and one number.");
      return;
    }

    if (reEnteredPassword !== password) {
      alert("Passwords do not match.");
      return;
    }

    const newGuide = {
      name,
      email,
      phoneNumber,
      password,
      // Add other required fields here
    };

    try {
      await registerGuide(newGuide);
      alert("Guide Registration Successful!");
      setName('');
      setEmail('');
      setPhoneNumber('');
      setPassword('');
      setReEnteredPassword('');
     // setProfileImage(null);
    } catch (err) {
      console.error(err);
      alert("Registration failed. Please try again.");
    }
  };

  // const handleFileChange = (e) => {
  //   setProfileImage(e.target.files[0]);
  // };

  return (
    <div
      className={styles.gradientForm}
      style={{
        backgroundImage: `url(${Background_GuideRegistration})`,
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
                backgroundColor: "rgba(255, 255, 255, 0.5)", // Set the background color to be semi-transparent
                backdropFilter: "blur(10px)", // Add blur effect for a frosted glass look
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
                      required
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
                      required
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
                      required
                    />
                  </div>

                  {/* <div className="form-outline mb-4">
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
                  </div> */}

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
                      required
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
                      required
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
                    <Link to="/guide-login">Sign in</Link>
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
