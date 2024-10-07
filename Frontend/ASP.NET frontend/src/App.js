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
import GuideBooking from './Components/GuideBooking';
import TravelerDashboard from './Components/TravelerDashboard';


function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/services" element={<Services />} />
        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<Signup />} />
        <Route path="/explore" element={<Explore />} /> 
        <Route path="/guide-login" element={<GuideLogin />} />
        <Route path="/guide-dashboard" element={<GuideDashboard />} />
        <Route path="/guide-registration" element={<GuideRegistration />} />
        <Route path="/admin-login" element={<AdminLogin />} />
        <Route path="/admin-dashboard" element={<AdminDashboard />} />
        <Route path="/admin-registration" element={<AdminRegistration />} />
        <Route path="/help" element={<Help />} />
        <Route path="/guide-booking" element={<GuideBooking />} />
        <Route path="/traveler-dashboard" element={<TravelerDashboard />} />
        
      </Routes>
      <Footer/>
    </Router>
  );
}

export default App;
