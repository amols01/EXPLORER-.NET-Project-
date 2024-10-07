
import React, { useState } from 'react';
import axios from 'axios';

const PlaceFeedback = ({ placeId, userId }) => {
  const [feedback, setFeedback] = useState('');
  const [rating, setRating] = useState(1);
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');

  const handleSubmit = async (event) => {
    event.preventDefault();
    
    // Validate inputs
    if (!feedback || rating < 1 || rating > 5) {
      setError('Please provide valid feedback and rating (1-5).');
      return;
    }

    try {
      const response = await axios.post('/api/place-feedback', {
        placeFeedback: feedback,
        placeRating: rating,
        placeId: placeId,
        userId: userId
      }, {
        headers: {
          'Authorization': `Bearer ${localStorage.getItem('token')}`
        }
      });

      if (response.status === 200) {
        setSuccess('Feedback submitted successfully!');
        setFeedback('');
        setRating(1);
      }
    } catch (err) {
      setError('Error submitting feedback. Please try again.');
    }
  };

  return (
    <div>
      <h2>Submit Your Feedback</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      {success && <div className="alert alert-success">{success}</div>}
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="feedback">Feedback</label>
          <textarea
            id="feedback"
            className="form-control"
            rows="4"
            value={feedback}
            onChange={(e) => setFeedback(e.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="rating">Rating</label>
          <input
            id="rating"
            type="number"
            className="form-control"
            min="1"
            max="5"
            value={rating}
            onChange={(e) => setRating(Number(e.target.value))}
          />
        </div>
        <button type="submit" className="btn btn-primary">Submit Feedback</button>
      </form>
    </div>
  );
};

export default PlaceFeedback;
