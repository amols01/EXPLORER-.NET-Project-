
import React from 'react';
import '../style_sheets/About.css'; 

const teamData = [
  { 
    name: 'Amol Sonawane', 
    image: '/images/amol.jpeg', 
    role: 'Project Lead and Developer', 
    info: 'Specializes in front-end development and JavaScript frameworks.' 
  },
  { 
    name: 'Sumit Nikam', 
    image: '/images/sumit.jpg', 
    role: 'Back-End Developer', 
    info: 'Expert in UI/UX design with a keen eye for aesthetics.' 
  },
  { 
    name: 'Hemendra Mahajan', 
    image: '/images/hemendra.jpg', 
    role: 'Back-End Developer', 
    info: 'Manages the project timelines and ensures team collaboration.' 
  },
  { 
    name: 'Aniket Chalake', 
    image: '/images/aniket.jpg', 
    role: 'Front-End Developer', 
    info: 'Ensures quality and bug-free delivery through rigorous testing.' 
  },
  { 
    name: 'Girish Patil', 
    image: '/images/girish.jpeg', 
    role: 'Front-End Developer', 
    info: 'Provides technical support and maintains project documentation.' 
  },
];

const placesData = [
  { 
    name: 'Pune', 
    image: '/images/pune.jpg', 
    rating: '4.5', 
    info: 'Cultural capital of Maharashtra known for its history and education.' 
  },
  { 
    name: 'Mumbai', 
    image: '/images/mumbai.jpg', 
    rating: '4.8', 
    info: 'The bustling financial hub with iconic landmarks and vibrant life.' 
  },
  { 
    name: 'Nashik', 
    image: '/images/nashik.jpg', 
    rating: '4.6', 
    info: 'Famous for vineyards and pilgrimage sites.' 
  },
];

const feedbackData = [
  { 
    name: 'Rahul Sharma', 
    image: '/images/rahul.jpg', 
    feedback: 'A seamless travel experience with top-notch service.' 
  },
  { 
    name: 'S.K.Priya', 
    image: '/images/priya.jpg', 
    feedback: 'The best travel planner I have ever used, highly recommended!' 
  },
  { 
    name: 'Amit Patil', 
    image: '/images/amit.jpg', 
    feedback: 'Excellent guidance and wonderful travel destinations.' 
  },
];

const About = () => {
  return (
    <div className="about-page-container">
      <div className="overlay-background"></div>
      <h1>Bhatkanti - Soul Explorer</h1>
      <p className="welcome-message">
        Welcome to Bhatkanti - Soul Explore, your ultimate travel companion for exploring the hidden gems of Maharashtra.
        Our mission is to provide a seamless travel experience with customized itineraries, expert guidance, and a user-friendly platform.
      </p>

      <section className="team-wrapper">
        <h2>Meet Our Team</h2>
        <div className="team-profile-cards">
          {teamData.map((member, index) => (
            <div className="profile-card" key={index}>
              <img src={member.image} alt={member.name} />
              <h3>{member.name}</h3>
              <p>{member.role}</p>
              <p className="profile-info">{member.info}</p>
            </div>
          ))}
        </div>
      </section>

      <section className="places-wrapper">
        <h2>Best Destinations</h2>
        <div className="places-cards">
          {placesData.map((place, index) => (
            <div className="place-card" key={index}>
              <img src={place.image} alt={place.name} />
              <h3>{place.name}</h3>
              <p>{place.info}</p>
              <p className="place-rating">Rating: {place.rating}</p>
            </div>
          ))}
        </div>
      </section>

      <section className="feedback-wrapper">
        <h2>What People Say About Us</h2>
        <div className="feedback-cards">
          {feedbackData.map((testimonial, index) => (
            <div className="feedback-card" key={index}>
              <img src={testimonial.image} alt={testimonial.name} />
              <h3>{testimonial.name}</h3>
              <p>{testimonial.feedback}</p>
            </div>
          ))}
        </div>
      </section>

      {/* Video Section */}
      <section className="video-wrapper">
        <h2>Our Journey in Action</h2>
        <div className="video-content">
          <iframe width="700" height="500" src="https://www.youtube.com/embed/nyA3teAJkK0?si=Op3ymiK_UqQC_lvh" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>
        </div>
      </section>
    </div>
  );
};

export default About;