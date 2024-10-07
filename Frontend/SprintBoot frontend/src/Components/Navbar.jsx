import React from 'react';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import { Link } from 'react-router-dom';
import { Box } from '@mui/material';
import logo from '../Assets/logo.svg'; // Assuming the logo is in the src/assets directory

const Navbar = () => {
  return (
    <AppBar
      position="static"
      sx={{
        backgroundColor: '#1E88E5', // Updated color
      }}
    >
      <Toolbar>
        {/* Logo and Brand Name */}
        <Box sx={{ display: 'flex', alignItems: 'center', flexGrow: 1 }}>
          <img
            src={logo}
            alt="Bhatkanti Logo"
            style={{ marginRight: '10px', height: '60px', width: '70px' }}
          />
          <Typography
            variant="h6"
            component="div"
            sx={{ fontWeight: 'bold', fontFamily: 'Angkor, sans-serif' }}
          >
            <Link to="/" style={{ textDecoration: 'none', color: 'white' }}>
              BHATKANTI
            </Link>
          </Typography>
        </Box>

        {/* Navigation Links */}
        <Box sx={{ display: 'flex', alignItems: 'center', flexGrow: 2 }}>
          <Button color="inherit" component={Link} to="/">
            Home
          </Button>
          <Button color="inherit" component={Link} to="/about">
            About Us
          </Button>
          <Button color="inherit" component={Link} to="/services">
            Book a Guide
          </Button>
        </Box>

        {/* Login Link */}
        <Box>
          <Button color="inherit" component={Link} to="/login">
            Login
          </Button>
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Navbar;
