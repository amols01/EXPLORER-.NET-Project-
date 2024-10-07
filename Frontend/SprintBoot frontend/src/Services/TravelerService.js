import axios from "axios";


export const registerUser = async (newUser) => {
  try {
    const response = await axios.post("https://localhost:7155/api/user/register", newUser);
    alert("Registration Successful!");
    return response.data;
  } catch (err) {
    console.error(err);
    alert("Registration Failed. Please try again.");
    throw err; // Re-throw the error if you want to handle it further up the chain
  }
};







export const loginUser = async (userEnteredInfo) => {
  try {
    const response = await axios.post('https://localhost:7155/api/user/login', userEnteredInfo, {
      headers: {
        'Content-Type': 'application/json'
      }
    });
    return response.data;
  } catch (error) {
    console.error("Error during login:", error.response?.data || error.message); // Improved logging
    throw error;
  }
};
