

// src/Components/PrivateRoute.js
import React from 'react';
import { Navigate, useLocation } from 'react-router-dom';

const PrivateRoute = ({ element, isAuthenticated, redirectPath = '/login' }) => {
  const location = useLocation();

  if (!isAuthenticated) {
    // Redirect to the login page if not authenticated
    return <Navigate to={redirectPath} state={{ from: location }} replace />;
  }

  return element;
};

export default PrivateRoute;
