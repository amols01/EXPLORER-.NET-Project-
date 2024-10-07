

// AuthService.js
import axios from 'axios';
import { AUTH_API } from './constants';

export const login = (credentials) => {
    return axios.post(AUTH_API.LOGIN, credentials);
};

export const registerUser = (userData) => {
    return axios.post(AUTH_API.REGISTER, userData);
};

export const registerGuide = (guideData) => {
    return axios.post(AUTH_API.REGISTER_GUIDE, guideData);
};
