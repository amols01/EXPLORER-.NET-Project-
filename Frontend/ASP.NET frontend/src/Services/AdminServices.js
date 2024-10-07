import axios from "axios";


//const API_URL = 'https://localhost:7155/api/Admin/register';

export const registerAdmin = async (adminData) => {
  try {
    const response = await axios.post('https://localhost:7155/api/Admin/register', adminData);
    return response.data;
  } catch (error) {
    console.error('Error registering admin:', error);
    throw error; // Rethrow the error to be handled by the caller
  }
};




//const API_URL = 'https://localhost:7155/api/Admin/login';

export const loginAdmin = async (credentials) => {
  try {
    const response = await axios.post('https://localhost:7155/api/Admin/login', credentials);
    return response.data; // Return the response data
  } catch (error) {
    throw new Error(error.response ? error.response.data.message : 'An error occurred');
  }
};