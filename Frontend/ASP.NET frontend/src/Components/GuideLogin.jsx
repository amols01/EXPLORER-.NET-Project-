// import React, { useState } from 'react';
// import { useNavigate, Link } from 'react-router-dom'; // Import Link
// import Background_GuideLogin from '../Assets/Background_GuideLogin.png'; // Import the background image

// const Guide_Login = (props) => {
//   const navigate = useNavigate(); // Updated hook for navigation
//   const initialUserEnteredInfo = {
//     user_name: "",
//     password: ""
//   };

//   const [userEnteredInfo, setUserEnteredInfo] = useState(initialUserEnteredInfo);

//   const handleInputChange = (event) => {
//     const { name, value } = event.target;
//     setUserEnteredInfo({ ...userEnteredInfo, [name]: value });
//   };

//   const findUser = (e) => {
//     e.preventDefault();

//     // For now, we'll skip the actual verification logic.
//     // Assuming user details are correct, we'll redirect to Guide_Dashboard.
//     navigate('/guide_dashboard'); // Replace with your actual route
//   };

//   return (
//     <section
//       style={{
//         backgroundImage: `url(${Background_GuideLogin})`,
//         backgroundSize: 'cover',
//         backgroundPosition: 'center',
//         height: '100vh',
//         display: 'flex',
//         justifyContent: 'center',
//         alignItems: 'center'
//       }}
//     >
//       <div
//         style={{
//           backgroundColor: 'rgba(255, 255, 255, 0.8)', // Semi-transparent white background for the form
//           padding: '2rem',
//           borderRadius: '15px',
//           boxShadow: 'rgba(99, 99, 99, 0.2) 0px 2px 8px 0px',
//           width: '100%',
//           maxWidth: '400px',
//           textAlign: 'center'
//         }}
//       >
//         <h2 className="mb-5">Guide Sign in</h2>

//         <div className="form-outline mb-4">
//           <input 
//             type="text" 
//             id="user_name" 
//             className="form-control" 
//             placeholder="Username"
//             value={userEnteredInfo.user_name} 
//             onChange={handleInputChange} 
//             name="user_name" 
//           />
//         </div>

//         <div className="form-outline mb-4">
//           <input 
//             type="password" 
//             id="password" 
//             className="form-control" 
//             placeholder="Password" 
//             value={userEnteredInfo.password} 
//             onChange={handleInputChange} 
//             name="password" 
//           />
//         </div>

//         <div className="form-check d-flex justify-content-start mb-4" style={{ marginTop: '25px' }}>
//           <input className="form-check-input" type="checkbox" value="" id="form1Example3" />
//           <label className="form-check-label" htmlFor="form1Example3" style={{ marginLeft: '10px', color: '#585555' }}>
//             Remember password
//           </label>
//         </div>

//         <button 
//           style={{
//             width: '100px',
//             textDecoration: 'none',
//             color: 'white',
//             fontWeight: '700',
//             backgroundColor: '#4468E2',
//             textAlign: 'center',
//             padding: '7px 30px',
//             borderRadius: '5px',
//             outlineStyle: 'solid',
//             outlineWidth: '2px',
//             marginTop: '15px'
//           }} 
//           type="submit" 
//           onClick={findUser}
//         >
//           Login
//         </button>

//         <hr className="my-4" style={{ opacity: '0.15' }} />

//         <div className="d-flex align-items-center justify-content-center pb-4">
//           <p className="mb-0 me-2">Don't have an account?</p>
//           <Link to="/signup" style={{ textDecoration: 'none', color: '#4468E2' }}>Sign up</Link>
//         </div>
//       </div>
//     </section>
//   );
// };

// export default Guide_Login;


// import React, { useState } from 'react';
// import { useNavigate, Link } from 'react-router-dom'; // Import Link
// import Background_GuideLogin from '../Assets/Background_GuideLogin.png'; // Import the background image
// import { loginUser } from '../Services/GuideService.js'; // Import the API call function

// const Guide_Login = () => {
//   const navigate = useNavigate(); // Updated hook for navigation
//   const initialUserEnteredInfo = {
//     email: "",
//     password: ""
//   };

//   const [userEnteredInfo, setUserEnteredInfo] = useState(initialUserEnteredInfo);
//   const [errorMessage, setErrorMessage] = useState("");

//   // Regular expressions for validation
//   const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
//   const passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@])[A-Za-z\d@]{8,}$/; // At least 8 characters, at least one letter and one number

//   const handleInputChange = (event) => {
//     const { name, value } = event.target;
//     setUserEnteredInfo({ ...userEnteredInfo, [name]: value });
//   };

//   const handleLogin = async (e) => {
//     e.preventDefault();
    
//     // Validation
//     if (!emailRegex.test(userEnteredInfo.email)) {
//       setErrorMessage("Invalid email format.");
//       return;
//     }

//     if (!passwordRegex.test(userEnteredInfo.password)) {
//       setErrorMessage("Password must be at least 8 characters long and include at least one letter and one number.");
//       return;
//     }

//     try {
//       const data = await loginUser(userEnteredInfo);
//       console.log(userEnteredInfo);
//       console.log('Login successful:', data);
//       navigate('/guide-dashboard'); // Replace with your actual route
//     } catch (error) {
//       setErrorMessage("Login failed. Please check your credentials and try again.");
//     }
//   };

//   return (
//     <section
//       style={{
//         backgroundImage: `url(${Background_GuideLogin})`,
//         backgroundSize: 'cover',
//         backgroundPosition: 'center',
//         height: '100vh',
//         display: 'flex',
//         justifyContent: 'center',
//         alignItems: 'center'
//       }}
//     >
//       <div
//         style={{
//           backgroundColor: 'rgba(255, 255, 255, 0.8)', // Semi-transparent white background for the form
//           padding: '2rem',
//           borderRadius: '15px',
//           boxShadow: 'rgba(99, 99, 99, 0.2) 0px 2px 8px 0px',
//           width: '100%',
//           maxWidth: '400px',
//           textAlign: 'center'
//         }}
//       >
//         <h2 className="mb-5">Guide Sign in</h2>

//         {errorMessage && (
//           <div style={{ color: 'red', marginBottom: '1rem' }}>{errorMessage}</div>
//         )}

//         <div className="form-outline mb-4">
//           <input 
//             type="email" 
//             id="email" 
//             className="form-control" 
//             placeholder="Email"
//             value={userEnteredInfo.email} 
//             onChange={handleInputChange} 
//             name="email" 
//             required
//           />
//         </div>

//         <div className="form-outline mb-4">
//           <input 
//             type="password" 
//             id="password" 
//             className="form-control" 
//             placeholder="Password" 
//             value={userEnteredInfo.password} 
//             onChange={handleInputChange} 
//             name="password" 
//             required
//           />
//         </div>

//         <div className="form-check d-flex justify-content-start mb-4" style={{ marginTop: '25px' }}>
//           <input className="form-check-input" type="checkbox" value="" id="form1Example3" />
//           <label className="form-check-label" htmlFor="form1Example3" style={{ marginLeft: '10px', color: '#585555' }}>
//             Remember password
//           </label>
//         </div>

//         <button 
//           style={{
//             width: '100px',
//             textDecoration: 'none',
//             color: 'white',
//             fontWeight: '700',
//             backgroundColor: '#4468E2',
//             textAlign: 'center',
//             padding: '7px 30px',
//             borderRadius: '5px',
//             outlineStyle: 'solid',
//             outlineWidth: '2px',
//             marginTop: '15px'
//           }} 
//           type="submit" 
//           onClick={handleLogin}
//         >
//           Login
//         </button>

//         <hr className="my-4" style={{ opacity: '0.15' }} />

//         <div className="d-flex align-items-center justify-content-center pb-4">
//           <p className="mb-0 me-2">Don't have an account?</p>
//           <Link to="/signup" style={{ textDecoration: 'none', color: '#4468E2' }}>Sign up</Link>
//         </div>
//       </div>
//     </section>
//   );
// };

// export default Guide_Login;


import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom'; // Import Link
import Background_GuideLogin from '../Assets/Background_GuideLogin.png'; // Import the background image
import { loginUser } from '../Services/GuideService.js'; // Import the API call function

const Guide_Login = () => {
  const navigate = useNavigate(); // Updated hook for navigation
  const initialUserEnteredInfo = {
    email: "",
    password: ""
  };

  const [userEnteredInfo, setUserEnteredInfo] = useState(initialUserEnteredInfo);
  const [errorMessage, setErrorMessage] = useState("");

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setUserEnteredInfo({ ...userEnteredInfo, [name]: value });
  };

  const handleLogin = async (e) => {
    e.preventDefault();

    try {
      const data = await loginUser(userEnteredInfo);
      console.log(userEnteredInfo);
      console.log('Login successful:', data);
      navigate('/guide-dashboard'); // Replace with your actual route
    } catch (error) {
      setErrorMessage("Login failed. Please check your credentials and try again.");
    }
  };

  return (
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
          backgroundColor: 'rgba(255, 255, 255, 0.8)', // Semi-transparent white background for the form
          padding: '2rem',
          borderRadius: '15px',
          boxShadow: 'rgba(99, 99, 99, 0.2) 0px 2px 8px 0px',
          width: '100%',
          maxWidth: '400px',
          textAlign: 'center'
        }}
      >
        <h2 className="mb-5">Guide Sign in</h2>

        {errorMessage && (
          <div style={{ color: 'red', marginBottom: '1rem' }}>{errorMessage}</div>
        )}

        <div className="form-outline mb-4">
          <input 
            type="email" 
            id="email" 
            className="form-control" 
            placeholder="Email"
            value={userEnteredInfo.email} 
            onChange={handleInputChange} 
            name="email" 
            required
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
            required
          />
        </div>

        <div className="form-check d-flex justify-content-start mb-4" style={{ marginTop: '25px' }}>
          <input className="form-check-input" type="checkbox" value="" id="form1Example3" />
          <label className="form-check-label" htmlFor="form1Example3" style={{ marginLeft: '10px', color: '#585555' }}>
            Remember password
          </label>
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
          onClick={handleLogin}
        >
          Login
        </button>

        <hr className="my-4" style={{ opacity: '0.15' }} />

        <div className="d-flex align-items-center justify-content-center pb-4">
          <p className="mb-0 me-2">Don't have an account?</p>
          <Link to="/signup" style={{ textDecoration: 'none', color: '#4468E2' }}>Sign up</Link>
        </div>
      </div>
    </section>
  );
};

export default Guide_Login;
