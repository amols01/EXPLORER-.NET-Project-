
// import React, { useState, useEffect } from 'react';
// import { useNavigate } from 'react-router-dom';
// import { MenuItem, FormControl, Select, Card, CardContent, CardMedia, Button, Typography, CircularProgress } from '@mui/material';
// import axios from 'axios';
// import styleExplore from '../style_sheets/Explore.module.css'; // Import the CSS module

// const locations = {
//   Mumbai: [
//     { id: 1, img: 'https://via.placeholder.com/150', description: 'Marine Drive - A popular promenade in Mumbai.' },
//     { id: 2, img: 'https://via.placeholder.com/150', description: 'Gateway of India - Historic monument and popular tourist spot.' },
//   ],
//   Pune: [
//     { id: 1, img: 'https://via.placeholder.com/150', description: 'Shaniwarwada - Historical fortification in Pune.' },
//     { id: 2, img: 'https://via.placeholder.com/150', description: 'Osho Ashram - Meditation center and spiritual retreat.' },
//   ],
//   Nashik: [
//     { id: 1, img: 'https://via.placeholder.com/150', description: 'Sula Vineyard - Famous for wine tasting and vineyard tours.' },
//     { id: 2, img: 'https://via.placeholder.com/150', description: 'Pandav Leni - Ancient Buddhist caves and sculptures.' },
//   ],
// };

// const API_KEY = 'YOUR_OPENWEATHERMAP_API_KEY'; // Replace with your OpenWeatherMap API key

// const Explore = () => {
//   const [city, setCity] = useState('');
//   const [weather, setWeather] = useState(null);
//   const [loading, setLoading] = useState(false);
//   const navigate = useNavigate();

//   const handleCityChange = (event) => {
//     setCity(event.target.value);
//   };

//   const handleKnowMoreClick = () => {
//     navigate('/login');
//   };

//   useEffect(() => {
//     if (city) {
//       setLoading(true);
//       axios.get(`https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${API_KEY}&units=metric`)
//         .then(response => {
//           setWeather(response.data);
//           setLoading(false);
//         })
//         .catch(error => {
//           console.error('Error fetching weather data:', error);
//           setLoading(false);
//         });
//     }
//   }, [city]);

//   return (
//     <div className={styleExplore.container}>
//       <div className={styleExplore.dropdownContainer}>
//         <FormControl fullWidth>
//           <Select
//             value={city}
//             onChange={handleCityChange}
//             displayEmpty
//             renderValue={(selected) => (selected ? selected : 'Select a City')}
//           >
//             <MenuItem value="Mumbai">Mumbai</MenuItem>
//             <MenuItem value="Pune">Pune</MenuItem>
//             <MenuItem value="Nashik">Nashik</MenuItem>
//           </Select>
//         </FormControl>
//       </div>
//       {loading && <CircularProgress />}
//       {weather && (
//         <div className={styleExplore.weatherInfo}>
//           <Typography variant="h6">{weather.name}</Typography>
//           <Typography variant="body1">Temperature: {weather.main.temp}°C</Typography>
//           <Typography variant="body1">Weather: {weather.weather[0].description}</Typography>
//         </div>
//       )}
//       <div className={styleExplore.cardsContainer}>
//         {city && locations[city].map((location) => (
//           <Card key={location.id} className={styleExplore.card}>
//             <CardMedia
//               component="img"
//               alt="Location Image"
//               height="140"
//               image={location.img}
//             />
//             <CardContent>
//               <Typography variant="body2" color="textSecondary">
//                 {location.description}
//               </Typography>
//               <Button
//                 variant="contained"
//                 color="primary"
//                 onClick={handleKnowMoreClick}
//                 style={{ marginTop: '10px' }}
//               >
//                 Know More
//               </Button>
//             </CardContent>
//           </Card>
//         ))}
//       </div>
//     </div>
//   );
// };

// export default Explore;

import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { MenuItem, FormControl, Select, Card, CardContent, CardMedia, Button, Typography, CircularProgress } from '@mui/material';
import axios from 'axios';
import styleExplore from '../style_sheets/Explore.module.css'; // Import the CSS module

const API_BASE_URL = 'http://localhost:8080'; // Replace with your backend base URL

const Explore = () => {
  const [city, setCity] = useState('');
  const [locations, setLocations] = useState([]);
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleCityChange = (event) => {
    const selectedCity = event.target.value;
    setCity(selectedCity);
  };

  const handleKnowMoreClick = () => {
    navigate('/login');
  };

  useEffect(() => {
    if (city) {
      setLoading(true);

      // Fetch location data from the backend
      axios.get(`${API_BASE_URL}/api/traveler/city/1`)
        .then(response => {
          setLocations(response.data);
          console.log(response.data);
          setLoading(false);
        })
        .catch(error => {
          console.error('Error fetching location data:', error);
          setLocations([]);
          setLoading(false);
        });
    }
  }, [city]);

  return (
    <div className={styleExplore.container}>
      <div className={styleExplore.dropdownContainer}>
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
      {loading && <CircularProgress />}
      <div className={styleExplore.cardsContainer}>
        {locations.map((location) => (
          <Card key={location.id} className={styleExplore.card}>
            <CardMedia
              component="img"
              alt="Location Image"
              height="140"
              image={location.img}
            />
            <CardContent>
              <Typography variant="body2" color="textSecondary">
                {location.description}
              </Typography>
              <Button
                variant="contained"
                color="primary"
                onClick={handleKnowMoreClick}
                style={{ marginTop: '10px' }}
              >
                Know More
              </Button>
            </CardContent>
          </Card>
        ))}
      </div>
    </div>
  );
};

export default Explore;
