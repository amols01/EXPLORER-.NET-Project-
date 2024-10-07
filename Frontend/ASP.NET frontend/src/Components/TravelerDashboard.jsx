import React from 'react';
import '../style_sheets/Traveler.css';

const Traveler = () => {
  return (
    <div className="traveler">

      {/* Upper Flex Section */}
      <div className="upper-flex-section">
        <div className="upper-flex-left">
          <h2 className="guide-heading">Book our Guide Services</h2>
        </div>
        <div className="upper-flex-right">
          <p className="travel-info">
            Discover amazing places with our expert guides. Experience the beauty and culture of the destination with ease and comfort.
          </p>
          <button className="booking-button">Booking</button>
        </div>
      </div>

      {/* Feedback Cards Section */}
      <section className="feedback-cards-section">
        <h2 className="heading-traveler">Feedback Cards</h2>
        <div className="feedback-cards">
          <div className="feedback-card">
            <img src="https://i.pinimg.com/originals/85/0b/13/850b13fb8be7e90942696a2d73334ead.jpg" alt="Feedback 1" />
            <h3>Ravi Kumar</h3>
            <p>"Great experience, highly recommend!"</p>
            <p>Rating: 5/5</p>
          </div>

          <div className="feedback-card">
            <img src="https://i.pinimg.com/736x/6d/38/22/6d3822c18ca69ea41d4df66ba5c2b7c0.jpg" alt="Feedback 2" />
            <h3>Anushka</h3>
            <p>"Exceptional experience, highly recommend! Will definitely return soon!"</p>
            <p>Rating: 4/5</p>
          </div>

          <div className="feedback-card">
            <img src="https://i.pinimg.com/736x/61/06/30/610630ad861ee78f5678414bf73917b0.jpg" alt="Feedback 3" />
            <h3>Meera Patel</h3>
            <p>"Wonderful service, will come back again."</p>
            <p>Rating: 4/5</p>
          </div>

          <div className="feedback-card">
            <img src="https://i.pinimg.com/736x/25/c6/07/25c607ad8536bcca67314a8e845d8315.jpg" alt="Feedback 4" />
            <h3>Arjun Singh</h3>
            <p>"A memorable journey, very satisfying."</p>
            <p>Rating: 4.5/5</p>
          </div>
        </div>
      </section>
    </div>
  );
};

export default Traveler;
