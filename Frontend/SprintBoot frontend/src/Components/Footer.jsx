
import React from 'react';
import { Container, Row, Col } from 'react-bootstrap';
import { FaFacebook, FaInstagram, FaTwitter, FaYoutube } from 'react-icons/fa';
import '../style_sheets/Footer.css'; // Import the CSS file for the footer styles

export function Footer() {
  return (
    <footer className="footer">
      <Container>
        <Row className="justify-content-between align-items-center">
          <Col md={8} className="text-center">
            <h5 className="footer-title">Follow Us</h5>
            <div className="footer-icons">
              <a
                href="https://www.facebook.com/amtmindia"
                target="_blank"
                rel="noopener noreferrer"
                className="footer-icon"
              >
                <FaFacebook size={30} />
              </a>
              <a
                href="https://www.instagram.com/amtmindia/"
                target="_blank"
                rel="noopener noreferrer"
                className="footer-icon"
              >
                <FaInstagram size={30} />
              </a>
              <a
                href="https://www.youtube.com/channel/UCz64RiyW03lib1S1OwCwPEQ"
                target="_blank"
                rel="noopener noreferrer"
                className="footer-icon"
              >
                <FaYoutube size={30} />
              </a>
              <a
                href="https://www.twitter.com/amtmindia"
                target="_blank"
                rel="noopener noreferrer"
                className="footer-icon"
              >
                <FaTwitter size={30} />
              </a>
            </div>
          </Col>
          <Col md={4} className="text-md-right text-center">
            <div className="footer-contact">
              <p>Contact Us: +91 9988776655 | bhatkantisoulexplorer@bhatkanti.com</p>
            </div>
          </Col>
        </Row>
      </Container>
    </footer>
  );
}