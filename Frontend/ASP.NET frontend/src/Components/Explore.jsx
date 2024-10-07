

// import React, { useState, useEffect } from 'react';
// import { useNavigate } from 'react-router-dom';
// import { MenuItem, FormControl, Select, Card, CardContent, CardMedia, Button, Typography, CircularProgress, Grid, Paper } from '@mui/material';
// import axios from 'axios';
// import styleExplore from '../style_sheets/Explore.module.css'; // Import the CSS module

// const API_KEY = 'bdffb4c737704d16b15211821241608'; // Replace with your WeatherAPI.com API key

// const Explore = () => {
//   const [city, setCity] = useState('');
//   const [locations, setLocations] = useState([]);
//   const [loading, setLoading] = useState(false);
//   const [weather, setWeather] = useState(null); // State for weather data
//   const navigate = useNavigate();

//   const handleCityChange = (event) => {
//     const selectedCity = event.target.value;
//     setCity(selectedCity);
//   };

//   const handleKnowMoreClick = () => {
//     navigate('/login');
//   };

//   useEffect(() => {
//     if (city) {
//       setLoading(true);

//       // Fetch location data from the backend based on the selected city
//       axios.get(`https://localhost:7155/api/Location?city=${city}`)
//         .then(response => {
//           console.log('Response from backend:', response.data);

//           // Adjust based on the actual structure of the response
//           if (response.data && response.data.city && response.data.city.locations && Array.isArray(response.data.city.locations.$values)) {
//             setLocations(response.data.city.locations.$values);
//           } else {
//             console.error('Expected an array, but got:', response.data);
//             setLocations([]); // Set locations to an empty array if the expected property is not an array
//           }

//           setLoading(false);
//         })
//         .catch(error => {
//           console.error('Error fetching location data:', error);
//           setLocations([]);
//           setLoading(false);
//         });

//       // Fetch weather data from WeatherAPI.com
//       axios.get(`http://api.weatherapi.com/v1/current.json?key=${API_KEY}&q=${city}&aqi=no`)
//         .then(response => {
//           setWeather(response.data);
//           console.log('Weather data:', response.data);
//         })
//         .catch(error => {
//           console.error('Error fetching weather data:', error);
//           setWeather(null);
//         });
//     }
//   }, [city]);

//   return (
//     <Grid container spacing={3} className={styleExplore.container}>
//       <Grid item xs={12} sm={8}>
//         <div className={styleExplore.dropdownContainer}>
//           <FormControl fullWidth>
//             <Select
//               value={city}
//               onChange={handleCityChange}
//               displayEmpty
//               renderValue={(selected) => (selected ? selected : 'Select a City')}
//             >
//               <MenuItem value="Mumbai">Mumbai</MenuItem>
//               <MenuItem value="Pune">Pune</MenuItem>
//               <MenuItem value="Nashik">Nashik</MenuItem>
//             </Select>
//           </FormControl>
//         </div>
//         {loading && <CircularProgress />}
//         <div className={styleExplore.cardsContainer}>
//           {Array.isArray(locations) && locations.length > 0 ? (
//             locations.map((location) => (
//               <Card key={location.placeId} className={styleExplore.card}>
//                 <CardMedia
//                   component="img"
//                   alt="Location Image"
//                   height="140"
//                   image={location.image} // Ensure the API returns the correct image URL
//                 />
//                 <CardContent>
//                   <Typography variant="body2" color="textSecondary">
//                     {location.description}
//                   </Typography>
//                   <Button
//                     variant="contained"
//                     color="primary"
//                     onClick={handleKnowMoreClick}
//                     style={{ marginTop: '10px' }}
//                   >
//                     Know More
//                   </Button>
//                 </CardContent>
//               </Card>
//             ))
//           ) : (
//             <Typography variant="body2" color="textSecondary">
//               No locations available for this city.
//             </Typography>
//           )}
//         </div>
//       </Grid>

//       <Grid item xs={12} sm={4}>
//         {weather && (
//           <Paper elevation={3} className={styleExplore.weatherContainer}>
//             <Typography variant="h6" align="center" gutterBottom>
//               Weather in {city}
//             </Typography>
//             <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
//               <img src={weather.current.condition.icon} alt="Weather Icon" />
//               <Typography variant="body1" align="center" style={{ marginLeft: '10px' }}>
//                 {weather.current.condition.text}
//               </Typography>
//             </div>
//             <Typography variant="body1" align="center">
//               Temperature: {weather.current.temp_c}°C
//             </Typography>
//             <Typography variant="body1" align="center">
//               Humidity: {weather.current.humidity}%
//             </Typography>
//           </Paper>
//         )}
//       </Grid>
//     </Grid>
//   );
// };

// export default Explore;


import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { MenuItem, FormControl, Select, Card, CardContent, CardMedia, Button, Typography, CircularProgress, Grid, Paper } from '@mui/material';
import axios from 'axios';
import styleExplore from '../style_sheets/Explore.module.css'; // Import the CSS module

const API_KEY = 'bdffb4c737704d16b15211821241608'; // Replace with your WeatherAPI.com API key

const staticLocations = [
  { placeId: 1, image: 'https://media.tacdn.com/media/attractions-splice-spp-674x446/0b/18/a0/dc.jpg', description: 'A popular beach in Mumbai with scenic views and street food.' },
  { placeId: 2, image: 'https://img.veenaworld.com/wp-content/uploads/2021/03/Gateway-of-India-Mumbai-History-and-Heritage.jpeg', description: 'An iconic monument and popular tourist attraction.' },
  { placeId: 3, image: 'https://upload.wikimedia.org/wikipedia/commons/0/0e/Mumbai_03-2016_46_evening_at_Marine_Drive.jpg', description: 'A 3.6 km long boulevard along the coast with stunning sea views.' },
  { placeId: 4, image: 'https://media1.thrillophilia.com/filestore/qj62nh68fativk30jny3i6osrzgw_1524229348_Elephanta_caves.jpg', description: 'Ancient rock-cut temples located on Elephanta Island.' },
  { placeId: 5, image: 'https://thumbs.dreamstime.com/b/historical-shaniwar-wada-palace-pune-maharastra-india-garden-shaniwarwada-fortification-city-maharashtra-built-163963152.jpg', description: 'Historical fortification and palace in Pune.' },
  { placeId: 6, image: 'https://www.fabhotels.com/blog/wp-content/uploads/2019/06/Aga-Khan-Palace_600.jpg', description: 'Historical palace and a monument of Indian freedom struggle.'},
  { placeId: 7, image: 'https://static2.tripoto.com/media/filter/tst/img/1580119/TripDocument/1584183757_1584183738460.jpg', description: 'A hill fortress with historical significance and panoramic views.' },
  { placeId: 8, image: 'https://curlytales.com/wp-content/uploads/2018/02/17884396_10155108013074000_4092140018388982045_n.jpg', description: 'Spiritual center and meditation retreat.' },
  { placeId: 9, image: 'https://dynamic-media-cdn.tripadvisor.com/media/photo-o/1a/3f/8e/3d/a-view-from-the-vineyards.jpg?w=1200&h=-1&s=1', description: 'Famous winery known for its wine tours and tastings.' },
  { placeId: 10, image: 'https://i.pinimg.com/originals/08/fd/09/08fd09114abf74a1f50d0d06b5549e67.jpg', description: 'Ancient temple dedicated to Lord Rama.' },
  { placeId: 11, image: 'https://lh3.googleusercontent.com/proxy/hFrFENGeWkv8dNWiNN0yzRsw0u7M8-JI00d-HsjAMZs7RDHlxwPQG_s0rGl_5O-J6baRl6L7nmrHbxHBJtR2438FwCj5_yWbiX7C5Ti_Wl4CT6sKHNXsqjjBzRyahERPluPRa3ItlUPnJZM', description: 'Cave complex with ancient Buddhist rock-cut temples.' },
  { placeId: 12, image: 'https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEi8U_S1rWkGls7jUW4j9jHPAfXneId8D9ElUZj9sYM_OIWGJsJN4A3qynpicuq4OKBT5C8s4WjExzZRZzaeQPwEBV3CtVSfzlD3bJSAT7K-8nnOcsXBvQAN8ri5MxC0MgKAXchmIdy8fZuKl3FYCGXqlghFTeUb_uZo_oNwo6DMJH-I7zDR-7ptHzWc/s1200/shubham%20water%20park%20nashik%201.jpg', description: 'Popular water park with various water rides and attractions.' },
];

const Explore = () => {
  const [city, setCity] = useState('');
  const [loading, setLoading] = useState(false);
  const [weather, setWeather] = useState(null); // State for weather data
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

      // Fetch weather data from WeatherAPI.com
      axios.get(`http://api.weatherapi.com/v1/current.json?key=${API_KEY}&q=${city}&aqi=no`)
        .then(response => {
          setWeather(response.data);
          console.log('Weather data:', response.data);
        })
        .catch(error => {
          console.error('Error fetching weather data:', error);
          setWeather(null);
        });
    }
  }, [city]);

  return (
    <Grid container spacing={3} className={styleExplore.container}>
      <Grid item xs={12} sm={8}>
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
          {staticLocations.map((location) => (
            <Card key={location.placeId} className={styleExplore.card}>
              <CardMedia
                component="img"
                alt="Location Image"
                height="140"
                image={location.image}
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
      </Grid>

      <Grid item xs={12} sm={4}>
        {weather && (
          <Paper elevation={3} className={styleExplore.weatherContainer}>
            <Typography variant="h6" align="center" gutterBottom>
              Weather in {city}
            </Typography>
            <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
              <img src={weather.current.condition.icon} alt="Weather Icon" />
              <Typography variant="body1" align="center" style={{ marginLeft: '10px' }}>
                {weather.current.condition.text}
              </Typography>
            </div>
            <Typography variant="body1" align="center">
              Temperature: {weather.current.temp_c}°C
            </Typography>
            <Typography variant="body1" align="center">
              Humidity: {weather.current.humidity}%
            </Typography>
          </Paper>
        )}
      </Grid>
    </Grid>
  );
};

export default Explore;
