import React, { useState } from 'react';
import { TextField, Button, Container, Box, Typography, Grid } from '@mui/material';
import HelpImage from '../Assets/HelpImage.png'; // Replace with your image path

const Help = () => {
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [query, setQuery] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!email || !phoneNumber) {
      alert('Email and Phone Number are mandatory.');
      return;
    }

    const queryData = {
      email,
      phoneNumber,
      query,
    };

    console.log('Submitted query:', queryData);

    // Clear the form after submission
    setEmail('');
    setPhoneNumber('');
    setQuery('');
  };

  return (
    <Box
      sx={{
        backgroundColor: '#d3d3d3', // Light grey background for the entire page
        minHeight: '100vh',
        display: 'flex',
        alignItems: 'center',
      }}
    >
      <Container maxWidth="lg" sx={{ mt: 8 }}>
        <Grid container spacing={4} alignItems="center">
          <Grid item xs={12} md={6}>
            <Box
              component="form"
              onSubmit={handleSubmit}
              sx={{
                backgroundColor: 'rgba(255, 255, 255, 0.5)', // Frosty effect background
                backdropFilter: 'blur(10px)', // Blur effect for frosty look
                padding: '2rem',
                borderRadius: '15px',
                boxShadow: 'rgba(99, 99, 99, 0.2) 0px 2px 8px 0px',
                height: '100%', // Ensures the height matches the image box
              }}
            >
              <Typography variant="h4" gutterBottom>
                Submit Your Query
              </Typography>
              <TextField
                label="Email"
                variant="outlined"
                fullWidth
                required
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                sx={{ mb: 3 }}
              />
              <TextField
                label="Phone Number"
                variant="outlined"
                fullWidth
                required
                value={phoneNumber}
                onChange={(e) => setPhoneNumber(e.target.value)}
                sx={{ mb: 3 }}
              />
              <TextField
                label="Query"
                variant="outlined"
                multiline
                rows={6} // Increased rows for a bigger query box
                fullWidth
                value={query}
                onChange={(e) => setQuery(e.target.value)}
                sx={{ mb: 3 }}
              />
              <Button type="submit" variant="contained" color="primary" fullWidth>
                Submit Query
              </Button>
            </Box>
          </Grid>
          <Grid item xs={12} md={6} sx={{ textAlign: 'center' }}>
            <Typography variant="h5" sx={{ mb: 4, mt: 4 }}>
              Ask your query here, Our people at BHATKANTI will get back to you as soon as possible.
            </Typography>
            <Box sx={{ display: 'flex', justifyContent: 'center', height: '100%' }}>
              <img
                src={HelpImage}
                alt="Help"
                style={{ maxWidth: '100%', borderRadius: '15px', boxShadow: 'rgba(99, 99, 99, 0.2) 0px 2px 8px 0px', height: '100%', marginBottom: '40px' }}
              />
            </Box>
          </Grid>
        </Grid>
      </Container>
    </Box>
  );
};

export default Help;
