
import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { MenuItem, FormControl, Select, Card, CardContent, CardMedia, Button, Typography, CircularProgress, Box } from '@mui/material';
import axios from 'axios';
import '../style_sheets/TravelerDashboard.css'; // Import CSS

const API_KEY = 'bdffb4c737704d16b15211821241608'; // Replace with your API key

const TravelerDashboard = () => {
  const [wishlist, setWishlist] = useState([]);
  const [city, setCity] = useState('');
  const [locations, setLocations] = useState([]);
  const [weather, setWeather] = useState(null);
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleCityChange = (event) => {
    const cityId = event.target.value;
    setCity(cityId);
    if (cityId) {
      setLoading(true);
      const token = localStorage.getItem('token');
      
      // Fetch weather data
      axios.get(`http://api.weatherapi.com/v1/current.json?key=${API_KEY}&q=${cityId}&aqi=no`)
        .then(response => {
          setWeather(response.data.current);
        })
        .catch(error => {
          console.error('Error fetching weather data:', error);
          setWeather(null); // Clear weather data on error
        });

      // Fetch location data
      axios.get(`http://localhost:8080/api/traveler/locations`, {
        headers: {
          'Authorization': `Bearer ${token}`
        }
      })
        .then(response => {
          setLocations(response.data);
        })
        .catch(error => {
          console.error('Error fetching location data:', error);
          setLocations([]); // Clear locations on error
        })
        .finally(() => {
          setLoading(false);
        });
    }
  };

  const handleFeedbackClick = () => {
    navigate('/guide-feedback');
  };

  const handleViewWishlistClick = () => {
    navigate('/wishlist');
  };

  return (
    <div className="traveler-page">
      {/* Wishlist Button on the Page */}
      <Box sx={{ display: 'flex', justifyContent: 'flex-end', padding: 2 }}>
        <Button variant="contained" color="secondary" onClick={handleViewWishlistClick}>
          View Wishlist
        </Button>
      </Box>

      {/* City Selection Dropdown on Top */}
      <div className="dropdown-container">
        <FormControl fullWidth>
          <Select
            value={city}
            onChange={handleCityChange}
            displayEmpty
            renderValue={(selected) => (selected ? selected : 'Select a City')}
          >
            <MenuItem value="Mumbai">Mumbai</MenuItem>
            <MenuItem value="Pune">Pune</MenuItem>
            <MenuItem value="Nashik">Nashik</MenuItem>
          </Select>
        </FormControl>
      </div>

      {/* Weather Information */}
      <Box sx={{ display: 'flex', justifyContent: 'flex-end', padding: 2 }}>
        {loading && <CircularProgress />}
        {weather && (
          <Box className="weather-info" sx={{ textAlign: 'right' }}>
            <Typography variant="h6">{city}</Typography>
            <img src={`http:${weather.condition.icon}`} alt={weather.condition.text} style={{ width: '50px', height: '50px' }} />
            <Typography variant="body1">Temperature: {weather.temp_c}°C</Typography>
            <Typography variant="body1">Weather: {weather.condition.text}</Typography>
          </Box>
        )}
      </Box>

      {/* Upper Flex Section */}
      <div className="upper-flex-section">
        <div className="upper-flex-left">
          <h2 className="guide-heading">Book our Guide Services</h2>
        </div>
        <div className="upper-flex-right">
          <p className="travel-info">
            Discover amazing places with our expert guides. Experience the beauty and culture of the destination with ease and comfort.
          </p>
        </div>
      </div>

      {/* Location Cards */}
      <div className="cards-container">
  {loading && <CircularProgress />}
  {!loading && locations.length === 0 && <Typography>No locations available for this city.</Typography>}
  {locations.length > 0 && locations.map((location) => (
    <Card key={location.placeId} className="location-card">
      <CardMedia
        component="img"
        alt={location.placeName}
        height="140"
        image={location.image}
      />
      <CardContent>
        <Typography variant="h6" component="div">
          {location.placeName}
        </Typography>
        <Typography variant="body2" color="textSecondary">
          {location.description}
        </Typography>
        <Typography variant="body2" color="textSecondary">
          Address: {location.address}
        </Typography>
        <Typography variant="body2" color="textSecondary">
          Nearest Police Station: {location.nearestPS}
        </Typography>
        {/* <Button
          variant="contained"
          color="primary"
          onClick={handleFeedbacklick}
          style={{ marginTop: '10px' }}
        >
          Add to Wishlist
        </Button> */}
        <Button
          variant="outlined"
          color="secondary"
          onClick={handleFeedbackClick}
          style={{ marginTop: '10px' }}
        >
          Give Guide Feedback
        </Button>
      </CardContent>
    </Card>
        ))}
      </div>
    </div>
  );
};

export default TravelerDashboard;
