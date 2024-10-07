
import React, { useState, useEffect } from 'react';
import {
  Drawer, List, ListItem, ListItemText, Box, Typography, AppBar, Toolbar, CssBaseline, Button, TextField,
  Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, ListItemSecondaryAction
} from '@mui/material';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const drawerWidth = 240;

const GuideDashboard = () => {
  const [selectedOption, setSelectedOption] = useState('Verification');
  const [locations, setLocations] = useState([]);
  const [bookingHistory, setBookingHistory] = useState([]);
  const [currentBookings, setCurrentBookings] = useState([]);
  const [amountEarned, setAmountEarned] = useState(0);
  const [openAddLocationDialog, setOpenAddLocationDialog] = useState(false);
  const [newLocation, setNewLocation] = useState({ name: '', description: '' });

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
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    navigate('/');
  };

  // Fetch locations
  const fetchLocations = async () => {
    try {
      const token = localStorage.getItem('token');
      if (!token) return;

      const response = await axios.get('http://localhost:8080/guide/locations', {
        headers: { Authorization: `Bearer ${token}` }
      });
      setLocations(response.data);
    } catch (error) {
      console.error('Error fetching locations:', error);
    }
  };

  // Fetch booking history
  const fetchBookingHistory = async () => {
    try {
      const token = localStorage.getItem('token');
      if (!token) return;

      const response = await axios.get('http://localhost:8080/guide/{guideId}/history', {
        headers: { Authorization: `Bearer ${token}` }
      });
      setBookingHistory(response.data);
    } catch (error) {
      console.error('Error fetching booking history:', error);
    }
  };

  // Fetch current bookings
  const fetchCurrentBookings = async () => {
    try {
      const token = localStorage.getItem('token');
      if (!token) return;

      const response = await axios.get('http://localhost:8080/guide/current-bookings', {
        headers: { Authorization: `Bearer ${token}` }
      });
      setCurrentBookings(response.data);
    } catch (error) {
      console.error('Error fetching current bookings:', error);
    }
  };

  // Fetch amount earned
  const fetchAmountEarned = async () => {
    try {
      const token = localStorage.getItem('token');
      if (!token) return;

      const response = await axios.get('http://localhost:8080/guide/amount-earned', {
        headers: { Authorization: `Bearer ${token}` }
      });
      setAmountEarned(response.data.amount);
    } catch (error) {
      console.error('Error fetching amount earned:', error);
    }
  };

  useEffect(() => {
    if (selectedOption === 'Add Location') {
      fetchLocations();
    } else if (selectedOption === 'Booking History') {
      fetchBookingHistory();
    } else if (selectedOption === 'Current Bookings') {
      fetchCurrentBookings();
    } else if (selectedOption === 'Amount Earned') {
      fetchAmountEarned();
    }
  }, [selectedOption]);

  // Handle adding a new location
  const handleAddLocation = async () => {
    try {
      const token = localStorage.getItem('token');
      if (!token) return;

      await axios.post('http://localhost:8080/guide/locations', newLocation, {
        headers: { Authorization: `Bearer ${token}` }
      });
      setOpenAddLocationDialog(false);
      setNewLocation({ name: '', description: '' });
      fetchLocations(); // Refresh the locations list
    } catch (error) {
      console.error('Error adding location:', error);
    }
  };

  // Handle deleting a location
  const handleDeleteLocation = async (locationId) => {
    try {
      const token = localStorage.getItem('token');
      if (!token) return;

      await axios.delete(`http://localhost:8080/guide/locations/${locationId}`, {
        headers: { Authorization: `Bearer ${token}` }
      });
      fetchLocations(); // Refresh the locations list
    } catch (error) {
      console.error('Error deleting location:', error);
    }
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
            backgroundColor: '#1E88E5',
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
            {selectedOption === 'Verification' && (
              <Typography>Verification Content</Typography>
            )}
            {selectedOption === 'Add Location' && (
              <>
                <Button variant="contained" color="primary" onClick={() => setOpenAddLocationDialog(true)}>
                  Add New Location
                </Button>
                <List>
                  {locations.map((location) => (
                    <ListItem key={location.id}>
                      <ListItemText primary={location.name} secondary={location.description} />
                      <ListItemSecondaryAction>
                        <Button variant="contained" color="secondary" onClick={() => handleDeleteLocation(location.id)}>
                          Delete
                        </Button>
                      </ListItemSecondaryAction>
                    </ListItem>
                  ))}
                </List>
              </>
            )}
            {selectedOption === 'Booking History' && (
              <List>
                {bookingHistory.map((booking) => (
                  <ListItem key={booking.id}>
                    <ListItemText primary={`Booking ID: ${booking.id}`} secondary={`Details: ${booking.details}`} />
                  </ListItem>
                ))}
              </List>
            )}
            {selectedOption === 'Current Bookings' && (
              <List>
                {currentBookings.map((booking) => (
                  <ListItem key={booking.id}>
                    <ListItemText primary={`Booking ID: ${booking.id}`} secondary={`Status: ${booking.status}`} />
                  </ListItem>
                ))}
              </List>
            )}
            {selectedOption === 'Amount Earned' && (
              <Typography variant="h6">
                Total Amount Earned: ${amountEarned}
              </Typography>
            )}
          </Box>
        </Box>
      </Box>

      {/* Add Location Dialog */}
      <Dialog open={openAddLocationDialog} onClose={() => setOpenAddLocationDialog(false)}>
        <DialogTitle>Add New Location</DialogTitle>
        <DialogContent>
          <DialogContentText>
            To add a new location, please enter the name and description here.
          </DialogContentText>
          <TextField
            autoFocus
            margin="dense"
            label="Location Name"
            fullWidth
            variant="standard"
            value={newLocation.name}
            onChange={(e) => setNewLocation({ ...newLocation, name: e.target.value })}
          />
          <TextField
            margin="dense"
            label="Description"
            fullWidth
            variant="standard"
            value={newLocation.description}
            onChange={(e) => setNewLocation({ ...newLocation, description: e.target.value })}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setOpenAddLocationDialog(false)}>Cancel</Button>
          <Button onClick={handleAddLocation}>Add Location</Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export default GuideDashboard;
