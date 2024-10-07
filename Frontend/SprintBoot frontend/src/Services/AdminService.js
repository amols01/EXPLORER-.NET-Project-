// AdminService.js
import axios from 'axios';
import { ADMIN_API } from './constants';

export const getAllUsers = () => {
    return axios.get(ADMIN_API.USERS);
};

export const getAllGuides = () => {
    return axios.get(ADMIN_API.GUIDES);
};

export const getAllPlaces = () => {
    return axios.get(ADMIN_API.PLACES.LIST);
};

export const addPlace = (placeData) => {
    return axios.post(ADMIN_API.PLACES.ADD, placeData);
};

export const updatePlace = (id, placeData) => {
    return axios.put(ADMIN_API.PLACES.UPDATE(id), placeData);
};

export const deletePlace = (id) => {
    return axios.delete(ADMIN_API.PLACES.DELETE(id));
};

export const getAllBookings = () => {
    return axios.get(ADMIN_API.BOOKINGS);
};
