import React from 'react';
import { Container, Row, Col, Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
// import { useAuth } from '../hooks/useAuth'; // Custom hook to check login status

// Import images from src/Assets
import guideImage from '../Assets/GuideImage.png'; // Replace with your actual image path
import registerImage from '../Assets/RegisterImage.png'; // Replace with your actual image path

const Services = () => {
  const navigate = useNavigate();
  // const { isLoggedIn } = useAuth(); // Replace with your auth logic

  const handleBookGuide = () => {
    // if (isLoggedIn) {
    navigate('/booking'); // Redirect to booking page if logged in
    // } else {
    //   navigate('/login'); // Redirect to login page if not logged in
    // }
  };

  const handleRegisterGuide = () => {
    navigate('/guide-registration'); // Redirect to signup page for guide registration
  };

  return (
    <Container fluid className="services-container">
      {/* First Section */}
      <Row className="my-5 align-items-center">
        <Col md={6} className="text-center text-md-start">
          <h2>Book a Guide</h2>
          <p>Experience a personalized journey with our professional guides. Enjoy exclusive benefits, reliable service, and secure interactions through our platform. Let us make your travel experience memorable with our trusted guides.</p>
          <Button variant="primary" onClick={handleBookGuide}>Book a Guide</Button>
        </Col>
        <Col md={6}>
          <img src={guideImage} alt="Guide" className="img-fluid" />
        </Col>
      </Row>

      {/* Second Section */}
      <Row className="my-5 align-items-center">
        <Col md={6}>
          <img src={registerImage} alt="Register as a Guide" className="img-fluid" />
        </Col>
        <Col md={6} className="text-center text-md-start">
          <h2>Become a Guide</h2>
          <p>Join our team of expert guides and share your knowledge with travelers. Register with us and become a part of our community. It's simple and rewarding to be a guide on our platform.</p>
          <Button variant="primary" onClick={handleRegisterGuide}>Register as a Guide</Button>
        </Col>
      </Row>
    </Container>
  );
};

export default Services;
