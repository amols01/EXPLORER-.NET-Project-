// import React, { useState, useEffect } from 'react';
// import { Container, TextField, Button, Box, MenuItem, Typography, Grid, Card, CardContent, CardMedia } from '@mui/material';

// const GuideBooking = () => {
//   const [cities, setCities] = useState([]);
//   const [places, setPlaces] = useState([]);
//   const [guides, setGuides] = useState([]);
//   const [reviews, setReviews] = useState([]);
//   const [bookingData, setBookingData] = useState({
//     fullName: '',
//     email: '',
//     phoneNumber: '',
//     city: '',
//     place: '',
//     guide: '',
//   });

//   useEffect(() => {
//     // Fetch cities from the backend
//     fetchCities();

//     // Fetch reviews from the backend
//     fetchReviews();
//   }, []);

//   useEffect(() => {
//     if (bookingData.city) {
//       // Fetch places when a city is selected
//       fetchPlaces(bookingData.city);
//     }
//   }, [bookingData.city]);

//   useEffect(() => {
//     if (bookingData.place) {
//       // Fetch guides when a place is selected
//       fetchGuides(bookingData.place);
//     }
//   }, [bookingData.place]);

//   const fetchCities = async () => {
//     // Replace with actual API call
//     const response = await fetch('/api/cities');
//     const data = await response.json();
//     setCities(data);
//   };

//   const fetchPlaces = async (city) => {
//     // Replace with actual API call
//     const response = await fetch(`/api/places?city=${city}`);
//     const data = await response.json();
//     setPlaces(data);
//   };

//   const fetchGuides = async (place) => {
//     // Replace with actual API call
//     const response = await fetch(`/api/guides?place=${place}`);
//     const data = await response.json();
//     setGuides(data);
//   };

//   const fetchReviews = async () => {
//     // Replace with actual API call
//     const response = await fetch('/api/reviews');
//     const data = await response.json();
//     setReviews(data);
//   };

//   const handleInputChange = (e) => {
//     const { name, value } = e.target;
//     setBookingData({ ...bookingData, [name]: value });
//   };

//   const handleSubmit = (e) => {
//     e.preventDefault();
//     console.log('Booking data submitted:', bookingData);
//     // Add the logic to submit the data to the backend
//   };

//   return (
//     <Container maxWidth="md" sx={{ mt: 4 }}>
//       <Typography variant="h4" gutterBottom>
//         Book a Guide
//       </Typography>
//       <Box component="form" onSubmit={handleSubmit} sx={{ mb: 5 }}>
//         <TextField
//           label="Full Name"
//           variant="outlined"
//           fullWidth
//           required
//           name="fullName"
//           value={bookingData.fullName}
//           onChange={handleInputChange}
//           sx={{ mb: 2 }}
//         />
//         <TextField
//           label="Email"
//           variant="outlined"
//           fullWidth
//           required
//           name="email"
//           value={bookingData.email}
//           onChange={handleInputChange}
//           sx={{ mb: 2 }}
//         />
//         <TextField
//           label="Phone Number"
//           variant="outlined"
//           fullWidth
//           required
//           name="phoneNumber"
//           value={bookingData.phoneNumber}
//           onChange={handleInputChange}
//           sx={{ mb: 2 }}
//         />
//         <TextField
//           select
//           label="City"
//           variant="outlined"
//           fullWidth
//           required
//           name="city"
//           value={bookingData.city}
//           onChange={handleInputChange}
//           sx={{ mb: 2 }}
//         >
//           {cities.map((city) => (
//             <MenuItem key={city.id} value={city.name}>
//               {city.name}
//             </MenuItem>
//           ))}
//         </TextField>
//         <TextField
//           select
//           label="Place"
//           variant="outlined"
//           fullWidth
//           required
//           name="place"
//           value={bookingData.place}
//           onChange={handleInputChange}
//           sx={{ mb: 2 }}
//           disabled={!bookingData.city}
//         >
//           {places.map((place) => (
//             <MenuItem key={place.id} value={place.name}>
//               {place.name}
//             </MenuItem>
//           ))}
//         </TextField>
//         <TextField
//           select
//           label="Select Guide"
//           variant="outlined"
//           fullWidth
//           required
//           name="guide"
//           value={bookingData.guide}
//           onChange={handleInputChange}
//           sx={{ mb: 2 }}
//           disabled={!bookingData.place}
//         >
//           {guides.map((guide) => (
//             <MenuItem key={guide.id} value={guide.name}>
//               {guide.name}
//             </MenuItem>
//           ))}
//         </TextField>
//         <Button type="submit" variant="contained" color="primary" fullWidth>
//           Book Now
//         </Button>
//       </Box>

//       {/* Reviews Section */}
//       <Typography variant="h5" gutterBottom>
//         Reviews of Our Guides
//       </Typography>
//       <Grid container spacing={3}>
//         {reviews.map((review) => (
//           <Grid item xs={12} sm={6} md={4} key={review.id}>
//             <Card>
//               <CardMedia
//                 component="img"
//                 height="140"
//                 image={review.image} // Assuming review has an image field
//                 alt={review.guideName}
//               />
//               <CardContent>
//                 <Typography variant="h6" gutterBottom>
//                   {review.guideName}
//                 </Typography>
//                 <Typography variant="body2" color="textSecondary">
//                   {review.comment}
//                 </Typography>
//               </CardContent>
//             </Card>
//           </Grid>
//         ))}
//       </Grid>
//     </Container>
//   );
// };

// export default GuideBooking;


import React, { useState, useEffect } from 'react';
import { Container, TextField, Button, Box, MenuItem, Typography, Grid, Card, CardContent, CardMedia } from '@mui/material';
import axios from 'axios';

const GuideBooking = () => {
  const [cities, setCities] = useState([]);
  const [places, setPlaces] = useState([]);
  const [guides, setGuides] = useState([]);
  const [reviews, setReviews] = useState([]);
  const [bookingData, setBookingData] = useState({
    fullName: '',
    email: '',
    phoneNumber: '',
    city: '',
    place: '',
    guide: '',
    bookingDate: '',
    bookingStartTime: '',
    bookingEndTime: ''
  });

  useEffect(() => {
    fetchCities();
    fetchReviews();
  }, []);

  useEffect(() => {
    if (bookingData.city) {
      fetchPlaces(bookingData.city);
    }
  }, [bookingData.city]);

  useEffect(() => {
    if (bookingData.place) {
      fetchGuides(bookingData.place);
    }
  }, [bookingData.place]);

  const fetchCities = async () => {
    const response = await fetch('/api/cities');
    const data = await response.json();
    setCities(data);
  };

  const fetchPlaces = async (city) => {
    const response = await fetch(`/api/places?city=${city}`);
    const data = await response.json();
    setPlaces(data);
  };

  const fetchGuides = async (place) => {
    const response = await fetch(`/api/guides?place=${place}`);
    const data = await response.json();
    setGuides(data);
  };

  const fetchReviews = async () => {
    const response = await fetch('/api/reviews');
    const data = await response.json();
    setReviews(data);
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setBookingData({ ...bookingData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post(`https://localhost:7155/api/user/book
`, {
        userId: 1, // Replace with actual userId if dynamic
        guideId: guides.find(guide => guide.name === bookingData.guide)?.id, // Ensure guideId is set correctly
        location: bookingData.place,
        bookingDate: bookingData.bookingDate,
        bookingStartTime: bookingData.bookingStartTime,
        bookingEndTime: bookingData.bookingEndTime
      });
      console.log('Booking successful:', response.data);
    } catch (error) {
      console.error('Error while booking:', error);
    }
  };

  return (
    <Container maxWidth="md" sx={{ mt: 4 }}>
      <Typography variant="h4" gutterBottom>
        Book a Guide
      </Typography>
      <Box component="form" onSubmit={handleSubmit} sx={{ mb: 5 }}>
        <TextField
          label="Full Name"
          variant="outlined"
          fullWidth
          required
          name="fullName"
          value={bookingData.fullName}
          onChange={handleInputChange}
          sx={{ mb: 2 }}
        />
        <TextField
          label="Email"
          variant="outlined"
          fullWidth
          required
          name="email"
          value={bookingData.email}
          onChange={handleInputChange}
          sx={{ mb: 2 }}
        />
        <TextField
          label="Phone Number"
          variant="outlined"
          fullWidth
          required
          name="phoneNumber"
          value={bookingData.phoneNumber}
          onChange={handleInputChange}
          sx={{ mb: 2 }}
        />
        <TextField
          select
          label="City"
          variant="outlined"
          fullWidth
          required
          name="city"
          value={bookingData.city}
          onChange={handleInputChange}
          sx={{ mb: 2 }}
        >
          {cities.map((city) => (
            <MenuItem key={city.id} value={city.name}>
              {city.name}
            </MenuItem>
          ))}
        </TextField>
        <TextField
          select
          label="Place"
          variant="outlined"
          fullWidth
          required
          name="place"
          value={bookingData.place}
          onChange={handleInputChange}
          sx={{ mb: 2 }}
          disabled={!bookingData.city}
        >
          {places.map((place) => (
            <MenuItem key={place.id} value={place.name}>
              {place.name}
            </MenuItem>
          ))}
        </TextField>
        <TextField
          select
          label="Select Guide"
          variant="outlined"
          fullWidth
          required
          name="guide"
          value={bookingData.guide}
          onChange={handleInputChange}
          sx={{ mb: 2 }}
          disabled={!bookingData.place}
        >
          {guides.map((guide) => (
            <MenuItem key={guide.id} value={guide.name}>
              {guide.name}
            </MenuItem>
          ))}
        </TextField>
        <TextField
          label="Booking Date"
          type="datetime-local"
          InputLabelProps={{
            shrink: true,
          }}
          variant="outlined"
          fullWidth
          required
          name="bookingDate"
          value={bookingData.bookingDate}
          onChange={handleInputChange}
          sx={{ mb: 2 }}
        />
        <TextField
          label="Start Time"
          type="datetime-local"
          InputLabelProps={{
            shrink: true,
          }}
          variant="outlined"
          fullWidth
          required
          name="bookingStartTime"
          value={bookingData.bookingStartTime}
          onChange={handleInputChange}
          sx={{ mb: 2 }}
        />
        <TextField
          label="End Time"
          type="datetime-local"
          InputLabelProps={{
            shrink: true,
          }}
          variant="outlined"
          fullWidth
          required
          name="bookingEndTime"
          value={bookingData.bookingEndTime}
          onChange={handleInputChange}
          sx={{ mb: 2 }}
        />
        <Button type="submit" variant="contained" color="primary" fullWidth>
          Book Now
        </Button>
      </Box>

      {/* Reviews Section */}
      <Typography variant="h5" gutterBottom>
        Reviews of Our Guides
      </Typography>
      <Grid container spacing={3}>
        {reviews.map((review) => (
          <Grid item xs={12} sm={6} md={4} key={review.id}>
            <Card>
              <CardMedia
                component="img"
                height="140"
                image={review.image} // Assuming review has an image field
                alt={review.guideName}
              />
              <CardContent>
                <Typography variant="h6" gutterBottom>
                  {review.guideName}
                </Typography>
                <Typography variant="body2" color="textSecondary">
                  {review.comment}
                </Typography>
              </CardContent>
            </Card>
          </Grid>
        ))}
      </Grid>
    </Container>
  );
};

export default GuideBooking;

