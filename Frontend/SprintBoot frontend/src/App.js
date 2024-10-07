import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './Components/Navbar';
import Home from './Components/Home';
import About from './Components/About';
import Services from './Components/Services';
import Login from './Components/Login';
import Signup from './Components/Signup';
import Explore from './Components/Explore'; // Import the Explore component
import { Footer } from './Components/Footer';
import GuideLogin from './Components/GuideLogin';
import GuideDashboard from './Components/GuideDashboard';
import GuideRegistration from './Components/GuideRegistration';
import AdminLogin from './Components/AdminLogin';
import AdminDashboard from './Components/AdminDashboard';
import AdminRegistration from './Components/AdminRegistration';
import Help from './Components/Help';
import TravelerDashboard from './Components/TravelerDashboard';
import GuideFeedback from './Components/GuideFeedback';

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/services" element={<Services />} />
        <Route path="/login" element={<Login />} />

        <Route path="/guide-feedback" element={<GuideFeedback />} />
        
        <Route path="/signup" element={<Signup />} />
        <Route path="/traveler-dashboard" element={<TravelerDashboard />} />
        <Route path="/explore" element={<Explore />} /> 
        <Route path="/guide-login" element={<GuideLogin />} />
        <Route path="/guide-dashboard" element={<GuideDashboard />} />
        <Route path="/guide-registration" element={<GuideRegistration />} />
        <Route path="/admin-login" element={<AdminLogin />} />
        <Route path="/admin-dashboard" element={<AdminDashboard />} />
        <Route path="/admin-registration" element={<AdminRegistration />} />
        <Route path="/help" element={<Help />} />
      </Routes>
      <Footer/>
    </Router>
  );
}

export default App;


// import { Routes, Route, Router } from 'react-router-dom';
// import ProtectedRoute from './Components/ProtectedRoute'; // Adjust the path as needed

// // Import your components
// import Navbar from './Components/Navbar';
// import Home from './Components/Home';
// import About from './Components/About';
// import Services from './Components/Services';
// import Login from './Components/Login';
// import Signup from './Components/Signup';
// import Explore from './Components/Explore'; // Import the Explore component
// import { Footer } from './Components/Footer';
// import GuideLogin from './Components/GuideLogin';
// import GuideDashboard from './Components/GuideDashboard';
// import GuideRegistration from './Components/GuideRegistration';
// import AdminLogin from './Components/AdminLogin';
// import AdminDashboard from './Components/AdminDashboard';
// import AdminRegistration from './Components/AdminRegistration';
// import Help from './Components/Help';
// import TravelerDashboard from './Components/TravelerDashboard';

// const App = () => {
//   return (

//     <Router>
//     <Navbar />
//     <Routes>
//       <Route path="/" element={<Home />} />
//       <Route path="/about" element={<About />} />
//       <Route path="/services" element={<Services />} />
//       <Route path="/login" element={<Login />} />
//       <Route path="/signup" element={<Signup />} />

//       {/* Protected Routes */}
//       <Route path="/traveler-dashboard" element={<ProtectedRoute element={<TravelerDashboard />} />} />
//       <Route path="/explore" element={<ProtectedRoute element={<Explore />} />} /> 
//       <Route path="/guide-login" element={<GuideLogin />} />
//       <Route path="/guide-dashboard" element={<ProtectedRoute element={<GuideDashboard />} requiredRole="guide" />} />
//       <Route path="/guide-registration" element={<ProtectedRoute element={<GuideRegistration />} requiredRole="guide" />} />
//       <Route path="/admin-login" element={<AdminLogin />} />
//       <Route path="/admin-dashboard" element={<ProtectedRoute element={<AdminDashboard />} requiredRole="admin" />} />
//       <Route path="/admin-registration" element={<ProtectedRoute element={<AdminRegistration />} requiredRole="admin" />} />
//       <Route path="/help" element={<Help />} />

//       {/* Fallback Route for Unauthorized Access */}
//       <Route path="/not-authorized" element={<div>Not Authorized</div>} />
//     </Routes>
//     <Footer/>
// </Router>
//   );
// };

// export default App;

