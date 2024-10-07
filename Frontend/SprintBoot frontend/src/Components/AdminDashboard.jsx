

import React, { useState, useEffect } from 'react';
import { Drawer, List, ListItem, ListItemText, Box, Typography, AppBar, Toolbar, Button, CssBaseline, Card, CardContent, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Dialog, DialogTitle, DialogContent, DialogActions, TextField } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const drawerWidth = 240;

const AdminDashboard = () => {
  const [selectedOption, setSelectedOption] = useState('Guide List');
  const [guides, setGuides] = useState([]);
  const [feedbacks, setFeedbacks] = useState([]);
  const [bookingHistory, setBookingHistory] = useState([]);
  const [cities, setCities] = useState([]);
  const [places, setPlaces] = useState([]);
  const [users, setUsers] = useState([]);
  const [currentBookings, setCurrentBookings] = useState([]);
  const [selectedGuide, setSelectedGuide] = useState(null);
  const [openDialog, setOpenDialog] = useState(false);
  const [openAddCityDialog, setOpenAddCityDialog] = useState(false);
  const [openAddPlaceDialog, setOpenAddPlaceDialog] = useState(false);
  const [newCity, setNewCity] = useState({ name: '', state: '' });
  const [newPlace, setNewPlace] = useState({ placeName: '', cityId: '', description: '' });
  const navigate = useNavigate();

  const menuItems = [
    'Guide List',
    'Feedbacks',
    'Booking History',
    'City',
    'Places',
    'Users',
    'Current Bookings'
  ];

  useEffect(() => {
    const fetchData = async () => {
      const token = localStorage.getItem('token');
      if (!token) return;

      try {
        switch (selectedOption) {
          case 'Guide List':
            const guidesResponse = await axios.get('http://localhost:8080/admin/guides', {
              headers: { Authorization: `Bearer ${token}` }
            });
            setGuides(guidesResponse.data);
            break;

          case 'Feedbacks':
            const feedbacksResponse = await axios.get('http://localhost:8080/admin/feedbacks', {
              headers: { Authorization: `Bearer ${token}` }
            });
            setFeedbacks(feedbacksResponse.data);
            break;

          case 'Booking History':
            const bookingHistoryResponse = await axios.get('http://localhost:8080/admin/bookings', {
              headers: { Authorization: `Bearer ${token}` }
            });
            setBookingHistory(bookingHistoryResponse.data);
            break;

          case 'City':
            const citiesResponse = await axios.get('http://localhost:8080/admin/cities', {
              headers: { Authorization: `Bearer ${token}` }
            });
            setCities(citiesResponse.data);
            break;

          case 'Places':
            const placesResponse = await axios.get('http://localhost:8080/admin/places', {
              headers: { Authorization: `Bearer ${token}` }
            });
            setPlaces(placesResponse.data);
            //console.log(placesResponse.data);
            break;

          case 'Users':
            const usersResponse = await axios.get('http://localhost:8080/admin/users', {
              headers: { Authorization: `Bearer ${token}` }
            });
            setUsers(usersResponse.data);
            break;

          case 'Current Bookings':
            const currentBookingsResponse = await axios.get('http://localhost:8080/admin/current-bookings', {
              headers: { Authorization: `Bearer ${token}` }
            });
            setCurrentBookings(currentBookingsResponse.data);
            break;

          default:
            break;
        }
      } catch (error) {
        console.error('Error fetching data:', error);
        if (error.response && error.response.status === 401) {
          navigate('/login');
        }
      }
    };

    fetchData();
  }, [selectedOption, navigate]);

  const handleMenuClick = (option) => {
    setSelectedOption(option);
  };

  const handleLogout = () => {
    localStorage.removeItem('token');
    navigate('/login');
  };

  const handleRegisterAdmin = () => {
    navigate('/admin-registration');
  };



  // Define the fetchData function
  const fetchData = async () => {
    try {
      const token = localStorage.getItem('token');
      if (!token) return;

      const response = await axios.get('http://localhost:8080/admin/cities', {
        headers: { Authorization: `Bearer ${token}` }
      });
      setCities(response.data);
    } catch (error) {
      console.error('Error fetching cities:', error);
    }
  };

  // Call fetchData when the component mounts
  useEffect(() => {
    fetchData();
  }, []);

  const handleAddCity = async () => {
    try {
      const token = localStorage.getItem('token');
      if (!token) return;

      await axios.post('http://localhost:8080/admin/cities', newCity, {
        headers: { Authorization: `Bearer ${token}` }
      });
      setOpenAddCityDialog(false);
      setNewCity({ name: '', state: '' });
      fetchData(); // Refresh the city list after adding a new city
    } catch (error) {
      console.error('Error adding city:', error);
    }
  };

  const handleAddPlace = async () => {
    try {
      const token = localStorage.getItem('token');
      if (!token) return;

      const placeData = {
        placeName: newPlace.place_Name, // Assuming 'place_Name' is from your state
        city: { cityId: newPlace.cityId }, // Assuming 'city_Id' is from your state
        image: newPlace.image,
        address: newPlace.address,
        description: newPlace.description,
        nearestPS: newPlace.nearestps
      };

      await axios.post('http://localhost:8080/admin/places/add', placeData, {
        headers: { Authorization: `Bearer ${token}` }
      });
      setOpenAddPlaceDialog(false);
      setNewPlace({ address: '', description: '', nearestps: '', place_Name: '', cityId: '', image: '' });
      fetchData(); // Refresh the place list
    } catch (error) {
      console.error('Error adding place:', error);
    }
  };

  const handleDeleteCity = async (cityId) => {
    try {
      const token = localStorage.getItem('token');
      if (!token) return;

      await axios.delete(`http://localhost:8080/admin/cities/${cityId}`, {
        headers: { Authorization: `Bearer ${token}` }
      });
      fetchData(); // Refresh the city list
    } catch (error) {
      console.error('Error deleting city:', error);
    }
  };

  const handleDeletePlace = async (id) => {
    try {
      const token = localStorage.getItem('token');
      if (!token) return;

      await axios.delete(`http://localhost:8080/admin/places/${id}`, {
        headers: { Authorization: `Bearer ${token}` }
      });
      fetchData(); // Refresh the place list
    } catch (error) {
      console.error('Error deleting place:', error);
    }
  };

  const handleDetailsClick = (guideId) => {
    const token = localStorage.getItem('token');
    if (token) {
      axios.get(`http://localhost:8080/admin/guides/${guideId}`, {
        headers: { Authorization: `Bearer ${token}` }
      })
        .then(response => {
          setSelectedGuide(response.data);
          setOpenDialog(true);
        })
        .catch(error => {
          console.error('Error fetching guide details:', error);
        });
    } else {
      console.error('No token found in localStorage');
    }
  };

  const handleCloseDialog = () => {
    setOpenDialog(false);
    setSelectedGuide(null);
  };

  return (
    <>
      <Box sx={{ display: 'flex' }}>
        <CssBaseline />
        
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
              Admin Dashboard
            </Typography>
            
            <Button color="inherit" sx={{ mr: 2 }} onClick={handleRegisterAdmin}>
              Register Admin
            </Button>
            <Button color="inherit" onClick={handleLogout}>
              Logout
            </Button>
          </Toolbar>
        </AppBar>
        
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
                      backgroundColor: '#555',
                    },
                    '&:hover': {
                      backgroundColor: '#333',
                    },
                  }}
                >
                  <ListItemText primary={text} />
                </ListItem>
              ))}
            </List>
          </Box>
        </Drawer>
        
        <Box
          component="main"
          sx={{
            flexGrow: 1,
            backgroundColor: '#4FC3F7',
            p: 3,
            width: `calc(100% - ${drawerWidth}px)`,
          }}
        >
          <Toolbar />
          <Typography variant="h4" gutterBottom>
            {selectedOption}
          </Typography>
          <Box>
            {selectedOption === 'Guide List' && (
              <Card sx={{ mb: 2 }}>
                <CardContent>
                  <Typography variant="h5">Guide List</Typography>
                  {guides.length > 0 ? (
                    <TableContainer component={Paper}>
                      <Table>
                        <TableHead>
                          <TableRow>
                            <TableCell>ID</TableCell>
                            <TableCell>Name</TableCell>
                            <TableCell>Email</TableCell>
                            <TableCell>Phone Number</TableCell>
                            <TableCell>Role</TableCell>
                            <TableCell>Details</TableCell>
                          </TableRow>
                        </TableHead>
                        <TableBody>
                          {guides.map((guide) => (
                            <TableRow key={guide.userId}>
                              <TableCell>{guide.userId}</TableCell>
                              <TableCell>{guide.name}</TableCell>
                              <TableCell>{guide.email}</TableCell>
                              <TableCell>{guide.phoneNumber}</TableCell>
                              <TableCell>{guide.role ? guide.role.role : 'N/A'}</TableCell>
                              <TableCell>
                                <Button variant="contained" color="primary" onClick={() => handleDetailsClick(guide.userId)}>
                                  View Details
                                </Button>
                              </TableCell>
                            </TableRow>
                          ))}
                        </TableBody>
                      </Table>
                    </TableContainer>
                  ) : (
                    <Typography>No guides available</Typography>
                  )}
                </CardContent>
              </Card>
            )}
            {selectedOption === 'Feedbacks' && (
              <Card sx={{ mb: 2 }}>
                <CardContent>
                  <Typography variant="h5">Feedbacks</Typography>
                  {feedbacks.length > 0 ? (
                    <TableContainer component={Paper}>
                      <Table>
                        <TableHead>
                          <TableRow>
                            <TableCell>ID</TableCell>
                            <TableCell>Guide</TableCell>
                            <TableCell>Traveler</TableCell>
                            <TableCell>Rating</TableCell>
                            <TableCell>Comments</TableCell>
                          </TableRow>
                        </TableHead>
                        <TableBody>
                          {feedbacks.map((feedback) => (
                            <TableRow key={feedback.id}>
                              <TableCell>{feedback.id}</TableCell>
                              <TableCell>{feedback.guide}</TableCell>
                              <TableCell>{feedback.traveler}</TableCell>
                              <TableCell>{feedback.rating}</TableCell>
                              <TableCell>{feedback.comments}</TableCell>
                            </TableRow>
                          ))}
                        </TableBody>
                      </Table>
                    </TableContainer>
                  ) : (
                    <Typography>No feedbacks available</Typography>
                  )}
                </CardContent>
              </Card>
            )}
            {selectedOption === 'Booking History' && (
              <Card sx={{ mb: 2 }}>
                <CardContent>
                  <Typography variant="h5">Booking History</Typography>
                  {bookingHistory.length > 0 ? (
                    <TableContainer component={Paper}>
                      <Table>
                        <TableHead>
                          <TableRow>
                            <TableCell>ID</TableCell>
                            <TableCell>Traveler</TableCell>
                            <TableCell>Guide</TableCell>
                            <TableCell>Date</TableCell>
                            <TableCell>Status</TableCell>
                          </TableRow>
                        </TableHead>
                        <TableBody>
                          {bookingHistory.map((booking) => (
                            <TableRow key={booking.id}>
                              <TableCell>{booking.id}</TableCell>
                              <TableCell>{booking.traveler}</TableCell>
                              <TableCell>{booking.guide}</TableCell>
                              <TableCell>{booking.date}</TableCell>
                              <TableCell>{booking.status}</TableCell>
                            </TableRow>
                          ))}
                        </TableBody>
                      </Table>
                    </TableContainer>
                  ) : (
                    <Typography>No booking history available</Typography>
                  )}
                </CardContent>
              </Card>
            )}
            {selectedOption === 'City' && (
              <>
                <Card sx={{ mb: 2 }}>
                  <CardContent>
                    <Typography variant="h5">Cities</Typography>
                    <Button variant="contained" color="primary" onClick={() => setOpenAddCityDialog(true)}>
                      Add City
                    </Button>
                    {cities.length > 0 ? (
                      <TableContainer component={Paper} sx={{ mt: 2 }}>
                        <Table>
                          <TableHead>
                            <TableRow>
                              <TableCell>ID</TableCell>
                              <TableCell>Name</TableCell>
                              <TableCell>State</TableCell>
                              <TableCell>Actions</TableCell>
                            </TableRow>
                          </TableHead>
                          <TableBody>
                            {cities.map((city) => (
                              <TableRow key={city.id}>
                                <TableCell>{city.id}</TableCell>
                                <TableCell>{city.name}</TableCell>
                                <TableCell>{city.state}</TableCell>
                                <TableCell>
                                  <Button variant="contained" color="secondary" onClick={() => handleDeleteCity(city.id)}>
                                    Delete
                                  </Button>
                                </TableCell>
                              </TableRow>
                            ))}
                          </TableBody>
                        </Table>
                      </TableContainer>
                    ) : (
                      <Typography>No cities available</Typography>
                    )}
                  </CardContent>
                </Card>
                <Dialog open={openAddCityDialog} onClose={() => setOpenAddCityDialog(false)}>
                  <DialogTitle>Add City</DialogTitle>
                  <DialogContent>
                    <TextField
                      margin="dense"
                      label="Name"
                      fullWidth
                      variant="outlined"
                      value={newCity.name}
                      onChange={(e) => setNewCity({ ...newCity, name: e.target.value })}
                    />
                    <TextField
                      margin="dense"
                      label="State"
                      fullWidth
                      variant="outlined"
                      value={newCity.state}
                      onChange={(e) => setNewCity({ ...newCity, state: e.target.value })}
                    />
                  </DialogContent>
                  <DialogActions>
                    <Button onClick={() => setOpenAddCityDialog(false)}>Cancel</Button>
                    <Button onClick={handleAddCity}>Add</Button>
                  </DialogActions>
                  
                </Dialog>
              </>
            )}

       {selectedOption === 'Places' && (
    <>
        <Card sx={{ mb: 2 }}>
            <CardContent>
                <Typography variant="h5">Places</Typography>
                <Button variant="contained" color="primary" onClick={() => setOpenAddPlaceDialog(true)}>
                    Add Place
                </Button>
                {places.length > 0 ? (
                    <TableContainer component={Paper} sx={{ mt: 2 }}>
                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell>ID</TableCell>
                                    <TableCell>Address</TableCell>
                                    <TableCell>Description</TableCell>
                                    <TableCell>Nearest Police Station</TableCell>
                                    <TableCell>Place Name</TableCell>
                                    <TableCell>City</TableCell>
                                    <TableCell>State</TableCell>
                                    <TableCell>Images</TableCell>
                                    <TableCell>Actions</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {places.map((place) => (
                                    <TableRow key={place.placeId}>
                                        <TableCell>{place.placeId}</TableCell>
                                        <TableCell>{place.address}</TableCell>
                                        <TableCell>{place.description}</TableCell>
                                        <TableCell>{place.nearestPS}</TableCell>
                                        <TableCell>{place.placeName}</TableCell>
                                        <TableCell>{place.city.city}</TableCell>
                                        <TableCell>{place.city.state.state}</TableCell>
                                        <TableCell>
                                            <img src={place.image} alt={place.placeName} style={{ width: '100px', height: 'auto' }} />
                                        </TableCell>
                                        <TableCell>
                                            <Button variant="contained" color="secondary" onClick={() => handleDeletePlace(place.placeId)}>
                                                Delete
                                            </Button>
                                        </TableCell>
                                    </TableRow>
                                ))}
                            </TableBody>
                        </Table>
                    </TableContainer>
                ) : (
                    <Typography>No places available</Typography>
                )}
                  </CardContent>
                </Card>
                
<Dialog open={openAddPlaceDialog} onClose={() => setOpenAddPlaceDialog(false)}>
      <DialogTitle>Add Place</DialogTitle>
      <DialogContent>
        <TextField
          margin="dense"
          label="Place Name"
          fullWidth
          variant="outlined"
          value={newPlace.placeName}
          onChange={(e) => setNewPlace({ ...newPlace, placeName: e.target.value })}
        />
        <TextField
          margin="dense"
          label="City ID"
          fullWidth
          variant="outlined"
          value={newPlace.cityId}
          onChange={(e) => setNewPlace({ ...newPlace, cityId: e.target.value })}
        />    
        <TextField
          margin="dense"
          label="Image URL"
          fullWidth
          variant="outlined"
          value={newPlace.image}
          onChange={(e) => setNewPlace({ ...newPlace, image: e.target.value })}
        />
        <TextField
          margin="dense"
          label="Address"
          fullWidth
          variant="outlined"
          value={newPlace.address}
          onChange={(e) => setNewPlace({ ...newPlace, address: e.target.value })}
        />
        <TextField
          margin="dense"
          label="Description"
          fullWidth
          variant="outlined"
          value={newPlace.description}
          onChange={(e) => setNewPlace({ ...newPlace, description: e.target.value })}
        />
        <TextField
          margin="dense"
          label="Nearest Police Station"
          fullWidth
          variant="outlined"
          value={newPlace.nearestPS}
          onChange={(e) => setNewPlace({ ...newPlace, nearestPS: e.target.value })}
        />
      </DialogContent>
      <DialogActions>
        <Button onClick={() => setOpenAddPlaceDialog(false)}>Cancel</Button>
        <Button onClick={handleAddPlace}>Add</Button>
      </DialogActions>
    </Dialog>
    </>
  )}
      {selectedOption === 'Users' && (
        <Card sx={{ mb: 2 }}>
          <CardContent>
            <Typography variant="h5">Users</Typography>
            {users.length > 0 ? (
              <TableContainer component={Paper}>
                <Table>
                  <TableHead>
                    <TableRow>
                      <TableCell>ID</TableCell>
                      <TableCell>Name</TableCell>
                      <TableCell>Email</TableCell>
                      <TableCell>Phone Number</TableCell>
                      <TableCell>Address</TableCell>
                      <TableCell>Role ID</TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {users.map((user) => (
                      <TableRow key={user.userId}>
                        <TableCell>{user.userId}</TableCell>
                        <TableCell>{user.name}</TableCell>
                        <TableCell>{user.email}</TableCell>
                        <TableCell>{user.phoneNumber}</TableCell>
                        <TableCell>{user.address || 'N/A'}</TableCell>
                        <TableCell>{user.role.roleId}</TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
            ) : (
              <Typography>No users available</Typography>
            )}
          </CardContent>
        </Card>
      )}
            {selectedOption === 'Current Bookings' && (
              <Card sx={{ mb: 2 }}>
                <CardContent>
                  <Typography variant="h5">Current Bookings</Typography>
                  {currentBookings.length > 0 ? (
                    <TableContainer component={Paper}>
                      <Table>
                        <TableHead>
                          <TableRow>
                            <TableCell>ID</TableCell>
                            <TableCell>Traveler</TableCell>
                            <TableCell>Guide</TableCell>
                            <TableCell>Date From</TableCell>
                            <TableCell>Date To</TableCell>
                            <TableCell>Status</TableCell>
                          </TableRow>
                        </TableHead>
                        <TableBody>
                          {currentBookings.map((booking) => (
                            <TableRow key={booking.booking_id}>
                              <TableCell>{booking.booking_id}</TableCell>
                              <TableCell>{booking.traveler}</TableCell>
                              <TableCell>{booking.guide}</TableCell>
                              <TableCell>{booking.date_from}</TableCell>
                              <TableCell>{booking.date_to}</TableCell>
                              <TableCell>{booking.status}</TableCell>
                            </TableRow>
                          ))}
                        </TableBody>
                      </Table>
                    </TableContainer>
                  ) : (
                    <Typography>No current bookings available</Typography>
                  )}
                </CardContent>
              </Card>
            )}
          </Box>
        </Box>
        
        <Dialog open={openDialog} onClose={handleCloseDialog}>
          <DialogTitle>Guide Details</DialogTitle>
          <DialogContent>
            {selectedGuide ? (
              <Box>
                <Typography><strong>ID:</strong> {selectedGuide.userId}</Typography>
                <Typography><strong>Name:</strong> {selectedGuide.name}</Typography>
                <Typography><strong>Email:</strong> {selectedGuide.email}</Typography>
                <Typography><strong>Phone:</strong> {selectedGuide.phoneNumber}</Typography>
                <Typography><strong>Role:</strong> {selectedGuide.role ? selectedGuide.role.role : 'N/A'}</Typography>
                <Typography><strong>About:</strong> {selectedGuide.about}</Typography>
              </Box>
            ) : (
              <Typography>No details available</Typography>
            )}
          </DialogContent>
          <DialogActions>
            <Button onClick={handleCloseDialog}>Close</Button>
          </DialogActions>
        </Dialog>
      </Box>
    </>
  );
};

export default AdminDashboard;
