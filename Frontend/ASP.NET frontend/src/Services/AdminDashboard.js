// apiService.js
import axios from 'axios';

const API_BASE_URL = 'http://localhost:7155/admin';

const getAuthHeaders = () => ({
  headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
});

export const fetchGuides = async () => {
  return axios.get(`${API_BASE_URL}/guides`, getAuthHeaders());
};

export const fetchFeedbacks = async () => {
  return axios.get(`${API_BASE_URL}/feedbacks`, getAuthHeaders());
};

export const fetchBookingHistory = async () => {
  return axios.get(`${API_BASE_URL}/bookings`, getAuthHeaders());
};

export const fetchCities = async () => {
  return axios.get(`https://localhost:7155/api/City`, getAuthHeaders());
};

export const fetchPlaces = async () => {
  return axios.get(`https://localhost:7155/api/Location`, getAuthHeaders());
};

export const fetchUsers = async () => {
  return axios.get(`${API_BASE_URL}/users`, getAuthHeaders());
};

export const fetchCurrentBookings = async () => {
  return axios.get(`${API_BASE_URL}/current-bookings`, getAuthHeaders());
};

export const addCity = async (newCity) => {
  return axios.post(`${API_BASE_URL}/cities`, newCity, getAuthHeaders());
};

export const addPlace = async (placeData) => {
  return axios.post(`${API_BASE_URL}/places/add`, placeData, getAuthHeaders());
};

export const deleteCity = async (cityId) => {
  return axios.delete(`${API_BASE_URL}/cities/${cityId}`, getAuthHeaders());
};

export const deletePlace = async (id) => {
  return axios.delete(`${API_BASE_URL}/places/${id}`, getAuthHeaders());
};

export const fetchGuideDetails = async (guideId) => {
  return axios.get(`${API_BASE_URL}/guides/${guideId}`, getAuthHeaders());
};
