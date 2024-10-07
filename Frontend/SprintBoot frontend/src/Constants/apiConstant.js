// src/constants/apiConstants.js
// export const API_BASE_URL = 'http://localhost:8080';

// // Auth Endpoints
// export const LOGIN_URL = `${API_BASE_URL}/api/auth/login`;
// export const REGISTER_URL = `${API_BASE_URL}/api/auth/register`;
// export const REGISTER_GUIDE_URL = `${API_BASE_URL}/api/auth/register/guide`;

// // Traveler Endpoints
// export const TRAVELER_BOOKINGS_URL = (travelerId) => `${API_BASE_URL}/api/traveler/${travelerId}/bookings`;
// export const TRAVELER_LOCATIONS_URL = `${API_BASE_URL}/api/traveler/locations`;

// // Admin Endpoints
// export const ADMIN_USERS_URL = `${API_BASE_URL}/admin/users`;
// export const ADMIN_GUIDES_URL = `${API_BASE_URL}/admin/guides`;
// export const ADMIN_PLACES_URL = `${API_BASE_URL}/admin/places`;
// export const ADMIN_PLACE_DETAILS_URL = (id) => `${API_BASE_URL}/admin/places/${id}`;
// export const ADMIN_ADD_PLACE_URL = `${API_BASE_URL}/admin/places/add`;
// export const ADMIN_BOOKINGS_URL = `${API_BASE_URL}/admin/bookings`;

// // Guide Endpoints
// export const GUIDE_DETAILS_URL = (guideId) => `${API_BASE_URL}/guide/${guideId}`;


// constants.js

export const API_BASE_URL = 'http://localhost:8080';

export const TRAVELER_API = {
    BOOKINGS: `${API_BASE_URL}/api/traveler/1/bookings`,
    LOCATIONS: `${API_BASE_URL}/api/traveler/locations`,
};

export const ADMIN_API = {
    USERS: `${API_BASE_URL}/admin/users`,
    GUIDES: `${API_BASE_URL}/admin/guides`,
    PLACES: {
        LIST: `${API_BASE_URL}/admin/places`,
        ADD: `${API_BASE_URL}/admin/places/add`,
        UPDATE: (id) => `${API_BASE_URL}/admin/places/${id}`,
        DELETE: (id) => `${API_BASE_URL}/admin/places/${id}`,
    },
    BOOKINGS: `${API_BASE_URL}/admin/bookings`,
};

export const AUTH_API = {
    LOGIN: `${API_BASE_URL}/api/auth/login`,
    REGISTER: `${API_BASE_URL}/api/auth/register`,
    REGISTER_GUIDE: `${API_BASE_URL}/api/auth/register/guide`,
};

export const GUIDE_API = {
    DETAILS: (guideId) => `${API_BASE_URL}/guide/${guideId}`,
};
