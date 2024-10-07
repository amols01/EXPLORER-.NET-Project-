import React, { useState } from 'react';
import { Drawer, List, ListItem, ListItemText, Box, Typography, AppBar, Toolbar, CssBaseline, Button } from '@mui/material';
import { useNavigate } from 'react-router-dom';


const drawerWidth = 240;

const GuideDashboard = () => {
  const [selectedOption, setSelectedOption] = useState('Verification');
  const navigate = useNavigate();

  const menuItems = [
    'Verification',
    'Add Location',
    'Booking History',
    'Current Bookings',
    'Amount Earned',
  ];

  const handleMenuClick = (option) => {
    setSelectedOption(option);
  };

  const handleLogout = () => {
    // Clear any session or authentication tokens (e.g., localStorage)
    //localStorage.removeItem('authToken'); // Adjust according to your storage method

    
    navigate('/'); // Redirect to home page
  };

  return (
    <>
      <Box sx={{ display: 'flex' }}>
        <CssBaseline />
        
        {/* AppBar */}
        <AppBar
          position="fixed"
          sx={{
            width: `calc(100% - ${drawerWidth}px)`,
            ml: `${drawerWidth}px`,
            backgroundColor: '#1E88E5', // Updated color to match your requirement
          }}
        >
          <Toolbar>
            <Typography variant="h6" noWrap sx={{ flexGrow: 1 }}>
              Guide Dashboard
            </Typography>
            
            {/* Navigation Links */}
            <Button color="inherit" sx={{ mr: 2 }}>
              <a href="/help" style={{ color: 'inherit', textDecoration: 'none' }}>Help</a>
            </Button>
            <Button color="inherit" onClick={handleLogout}>
              Logout
            </Button>
          </Toolbar>
        </AppBar>
        
        {/* Drawer (Sidebar) */}
        <Drawer
          variant="permanent"
          sx={{
            width: drawerWidth,
            flexShrink: 0,
            [`& .MuiDrawer-paper`]: { width: drawerWidth, boxSizing: 'border-box', backgroundColor: 'black', color: 'white' },
          }}
        >
          <Toolbar />
          <Box sx={{ overflow: 'auto' }}>
            <List>
              {menuItems.map((text) => (
                <ListItem 
                  button 
                  key={text} 
                  selected={selectedOption === text}
                  onClick={() => handleMenuClick(text)}
                  sx={{
                    '&.Mui-selected': {
                      backgroundColor: '#333',
                    },
                    '&:hover': {
                      backgroundColor: '#444',
                    },
                  }}
                >
                  <ListItemText primary={text} />
                </ListItem>
              ))}
            </List>
          </Box>
        </Drawer>
        
        {/* Main Content Area */}
        <Box
          component="main"
          sx={{
            flexGrow: 1,
            backgroundColor: '#42A5F5',
            p: 3,
            width: `calc(100% - ${drawerWidth}px)`,
          }}
        >
          <Toolbar />
          <Typography variant="h4" gutterBottom>
            {selectedOption}
          </Typography>
          <Box>
            {/* Placeholder for different content */}
            {selectedOption === 'Verification' && <Typography>Verification Content</Typography>}
            {selectedOption === 'Add Location' && <Typography>Add Location Content</Typography>}
            {selectedOption === 'Booking History' && <Typography>Booking History Content</Typography>}
            {selectedOption === 'Current Bookings' && <Typography>Current Bookings Content</Typography>}
            {selectedOption === 'Amount Earned' && <Typography>Amount Earned Content</Typography>}
          </Box>
        </Box>
      </Box>
    </>
  );
};

export default GuideDashboard;
