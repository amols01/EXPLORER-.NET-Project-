
import React from 'react';
import { Navigate } from 'react-router-dom';

// Mock authentication function - replace with actual authentication logic
const isAuthenticated = () => {
  // Check if the user is authenticated (e.g., check for a token in localStorage)
  return localStorage.getItem('token') !== null;
};

// Mock function to get user role - replace with actual logic
const getUserRole = () => {
  // Retrieve user role from localStorage or other state management
  return localStorage.getItem('role');
};

const ProtectedRoute = ({ element, requiredRole }) => {
  if (!isAuthenticated()) {
    // If user is not authenticated, redirect to the login page
    return <Navigate to="/login" />;
  }

  if (requiredRole && getUserRole() !== requiredRole) {
    // If user doesn't have the required role, redirect to a "not authorized" page
    return <Navigate to="/not-authorized" />;
  }

  // If authenticated and role matches (if required), render the element
  return element;
};

export default ProtectedRoute;
