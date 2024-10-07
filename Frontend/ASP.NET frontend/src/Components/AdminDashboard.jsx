// import React, { useState } from 'react';
// import { Drawer, List, ListItem, ListItemText, Box, Typography, AppBar, Toolbar, Button, CssBaseline } from '@mui/material';
// import { useNavigate } from 'react-router-dom'; // Import navigate for routing

// const drawerWidth = 240;

// const AdminDashboard = () => {
//   const [selectedOption, setSelectedOption] = useState('Guide List');
//   const navigate = useNavigate();

//   const menuItems = [
//     'Guide List',
//     'Feedbacks',
//     'Booking History',
//     'City',
//     'Places',
//     'Users',
//     'Current Bookings'
//   ];

//   const handleMenuClick = (option) => {
//     setSelectedOption(option);
//   };

//   const handleLogout = () => {
//     // Add logout logic here
//     console.log("Logged out");
//     navigate('/');
//   };

//   const handleRegisterAdmin = () => {
//     navigate('/admin-registration'); // Navigate to Register Admin page
//   };

//   return (
//     <>
//       <Box sx={{ display: 'flex' }}>
//         <CssBaseline />
        
//         {/* AppBar */}
//         <AppBar
//           position="fixed"
//           sx={{
//             width: `calc(100% - ${drawerWidth}px)`,
//             ml: `${drawerWidth}px`,
//             backgroundColor: '#1E88E5',
//           }}
//         >
//           <Toolbar>
//             <Typography variant="h6" noWrap sx={{ flexGrow: 1 }}>
//               Admin Dashboard
//             </Typography>
            
//             <Button color="inherit" sx={{ mr: 2 }} onClick={handleRegisterAdmin}>
//               Register Admin
//             </Button>
//             <Button color="inherit" onClick={handleLogout}>
//               Logout
//             </Button>
//           </Toolbar>
//         </AppBar>
        
//         {/* Drawer (Sidebar) */}
//         <Drawer
//           variant="permanent"
//           sx={{
//             width: drawerWidth,
//             flexShrink: 0,
//             [`& .MuiDrawer-paper`]: { width: drawerWidth, boxSizing: 'border-box', backgroundColor: 'black', color: 'white' },
//           }}
//         >
//           <Toolbar />
//           <Box sx={{ overflow: 'auto' }}>
//             <List>
//               {menuItems.map((text) => (
//                 <ListItem 
//                   button 
//                   key={text} 
//                   selected={selectedOption === text}
//                   onClick={() => handleMenuClick(text)}
//                   sx={{
//                     '&.Mui-selected': {
//                       backgroundColor: '#555',
//                     },
//                     '&:hover': {
//                       backgroundColor: '#333',
//                     },
//                   }}
//                 >
//                   <ListItemText primary={text} />
//                 </ListItem>
//               ))}
//             </List>
//           </Box>
//         </Drawer>
        
//         {/* Main Content Area */}
//         <Box
//           component="main"
//           sx={{
//             flexGrow: 1,
//             backgroundColor: '#4FC3F7',
//             p: 3,
//             width: `calc(100% - ${drawerWidth}px)`,
//           }}
//         >
//           <Toolbar />
//           <Typography variant="h4" gutterBottom>
//             {selectedOption}
//           </Typography>
//           <Box>
//             {/* Placeholder for different content */}
//             {selectedOption === 'Guide List' && <Typography>Display list of guides here</Typography>}
//             {selectedOption === 'Feedbacks' && <Typography>Display, edit, and delete feedbacks here</Typography>}
//             {selectedOption === 'Booking History' && <Typography>Display all booking history here</Typography>}
//             {selectedOption === 'City' && <Typography>Manage cities/states here</Typography>}
//             {selectedOption === 'Places' && <Typography>Manage places and add images here</Typography>}
//             {selectedOption === 'Users' && <Typography>Display and manage user list here</Typography>}
//             {selectedOption === 'Current Bookings' && <Typography>Manage current bookings here</Typography>}
//           </Box>
//         </Box>
//       </Box>
//     </>
//   );
// };

// export default AdminDashboard;


import React, { useState, useEffect } from 'react';
import {
  Drawer, List, ListItem, ListItemText, Box, Typography, AppBar, Toolbar, Button, CssBaseline, Card, CardContent,
  Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Dialog, DialogTitle, DialogContent, DialogActions, TextField
} from '@mui/material';
import { useNavigate } from 'react-router-dom';
import {
  fetchGuides, fetchFeedbacks, fetchBookingHistory, fetchCities, fetchPlaces, fetchUsers, fetchCurrentBookings,
  addCity, addPlace, deleteCity, deletePlace, fetchGuideDetails
} from '../Services/AdminDashboard.js'; // Import the API service functions

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
            const guidesResponse = await fetchGuides();
            setGuides(guidesResponse.data);
            break;

          case 'Feedbacks':
            const feedbacksResponse = await fetchFeedbacks();
            setFeedbacks(feedbacksResponse.data);
            break;

          case 'Booking History':
            const bookingHistoryResponse = await fetchBookingHistory();
            setBookingHistory(bookingHistoryResponse.data);
            break;

          case 'City':
            const citiesResponse = await fetchCities();
            setCities(citiesResponse.data);
            break;

          case 'Places':
            const placesResponse = await fetchPlaces();
            setPlaces(placesResponse.data);
            break;

          case 'Users':
            const usersResponse = await fetchUsers();
            setUsers(usersResponse.data);
            break;

          case 'Current Bookings':
            const currentBookingsResponse = await fetchCurrentBookings();
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

  const handleAddCity = async () => {
    try {
      await addCity(newCity);
      setOpenAddCityDialog(false);
      setNewCity({ name: '', state: '' });
      fetchCities(); // Refresh the city list after adding a new city
    } catch (error) {
      console.error('Error adding city:', error);
    }
  };

  const handleAddPlace = async () => {
    try {
      const placeData = {
        placeName: newPlace.placeName,
        city: { cityId: newPlace.cityId },
        image: newPlace.image,
        address: newPlace.address,
        description: newPlace.description,
        nearestPS: newPlace.nearestps
      };

      await addPlace(placeData);
      setOpenAddPlaceDialog(false);
      setNewPlace({ placeName: '', cityId: '', description: '', image: '', address: '', nearestps: '' });
      fetchPlaces(); // Refresh the place list
    } catch (error) {
      console.error('Error adding place:', error);
    }
  };

  const handleDeleteCity = async (cityId) => {
    try {
      await deleteCity(cityId);
      fetchCities(); // Refresh the city list
    } catch (error) {
      console.error('Error deleting city:', error);
    }
  };

  const handleDeletePlace = async (id) => {
    try {
      await deletePlace(id);
      fetchPlaces(); // Refresh the place list
    } catch (error) {
      console.error('Error deleting place:', error);
    }
  };

  const handleDetailsClick = async (guideId) => {
    try {
      const response = await fetchGuideDetails(guideId);
      setSelectedGuide(response.data);
      setOpenDialog(true);
    } catch (error) {
      console.error('Error fetching guide details:', error);
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
                              <TableCell>Action</TableCell>
                            </TableRow>
                          </TableHead>
                          <TableBody>
                            {cities.map((city) => (
                              <TableRow key={city.id}>
                                <TableCell>{city.id}</TableCell>
                                <TableCell>{city.name}</TableCell>
                                <TableCell>{city.state}</TableCell>
                                <TableCell>
                                  <Button variant="contained" color="error" onClick={() => handleDeleteCity(city.id)}>
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
                      autoFocus
                      margin="dense"
                      label="City Name"
                      type="text"
                      fullWidth
                      variant="standard"
                      value={newCity.name}
                      onChange={(e) => setNewCity({ ...newCity, name: e.target.value })}
                    />
                    <TextField
                      margin="dense"
                      label="State"
                      type="text"
                      fullWidth
                      variant="standard"
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
                              <TableCell>Place Name</TableCell>
                              <TableCell>City</TableCell>
                              <TableCell>Description</TableCell>
                              <TableCell>Action</TableCell>
                            </TableRow>
                          </TableHead>
                          <TableBody>
                            {places.map((place) => (
                              <TableRow key={place.id}>
                                <TableCell>{place.id}</TableCell>
                                <TableCell>{place.placeName}</TableCell>
                                <TableCell>{place.city.name}</TableCell>
                                <TableCell>{place.description}</TableCell>
                                <TableCell>
                                  <Button variant="contained" color="error" onClick={() => handleDeletePlace(place.id)}>
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
                      autoFocus
                      margin="dense"
                      label="Place Name"
                      type="text"
                      fullWidth
                      variant="standard"
                      value={newPlace.placeName}
                      onChange={(e) => setNewPlace({ ...newPlace, placeName: e.target.value })}
                    />
                    <TextField
                      margin="dense"
                      label="City ID"
                      type="text"
                      fullWidth
                      variant="standard"
                      value={newPlace.cityId}
                      onChange={(e) => setNewPlace({ ...newPlace, cityId: e.target.value })}
                    />
                    <TextField
                      margin="dense"
                      label="Image URL"
                      type="text"
                      fullWidth
                      variant="standard"
                      value={newPlace.image}
                      onChange={(e) => setNewPlace({ ...newPlace, image: e.target.value })}
                    />
                    <TextField
                      margin="dense"
                      label="Address"
                      type="text"
                      fullWidth
                      variant="standard"
                      value={newPlace.address}
                      onChange={(e) => setNewPlace({ ...newPlace, address: e.target.value })}
                    />
                    <TextField
                      margin="dense"
                      label="Description"
                      type="text"
                      fullWidth
                      variant="standard"
                      value={newPlace.description}
                      onChange={(e) => setNewPlace({ ...newPlace, description: e.target.value })}
                    />
                    <TextField
                      margin="dense"
                      label="Nearest Police Station"
                      type="text"
                      fullWidth
                      variant="standard"
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
                            <TableCell>Role</TableCell>
                          </TableRow>
                        </TableHead>
                        <TableBody>
                          {users.map((user) => (
                            <TableRow key={user.id}>
                              <TableCell>{user.id}</TableCell>
                              <TableCell>{user.name}</TableCell>
                              <TableCell>{user.email}</TableCell>
                              <TableCell>{user.role ? user.role.name : 'N/A'}</TableCell>
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
                            <TableCell>Date</TableCell>
                            <TableCell>Status</TableCell>
                          </TableRow>
                        </TableHead>
                        <TableBody>
                          {currentBookings.map((booking) => (
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
            {/* Guide details form or info */}
            {selectedGuide && (
              <>
                <Typography variant="h6">Name: {selectedGuide.name}</Typography>
                <Typography>Email: {selectedGuide.email}</Typography>
                <Typography>Phone Number: {selectedGuide.phoneNumber}</Typography>
                <Typography>Role: {selectedGuide.role ? selectedGuide.role.name : 'N/A'}</Typography>
                {/* More details */}
              </>
            )}
          </DialogContent>
          <DialogActions>
            <Button onClick={handleCloseDialog}>Close</Button>
          </DialogActions>
        </Dialog>
      </Box>
    </>
  );
}

export default AdminDashboard;

