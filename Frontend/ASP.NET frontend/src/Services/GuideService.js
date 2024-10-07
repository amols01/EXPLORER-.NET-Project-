import axios from "axios";



export const registerGuide = async (guideData) => {
  try {
    const response = await axios.post("https://localhost:7155/api/Guide/register", guideData);
    return response.data;
  } catch (error) {
    throw error;
  }
};





export const loginUser = async (credentials) => {
  try {
    const response = await axios.post('https://localhost:7155/api/user/login', credentials);
    console.log(credentials);
    return response.data;
  } catch (error) {
    console.error('Login failed', error);
    throw error;
  }
};
