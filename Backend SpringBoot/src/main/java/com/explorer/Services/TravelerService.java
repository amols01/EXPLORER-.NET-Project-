package com.explorer.Services;

import com.explorer.Models.*;

import java.util.List;
import java.util.Optional;

public interface TravelerService {
	Users registerTraveller(Users user);

	// Optional<Users> loginTraveller(String email, String password);
	List<Place> viewAllLocations();

	UserGuideBookings bookGuide(UserGuideBookings booking);

	Wishlist addToWishlist(Wishlist wishlist);

	void giveFeedback(int guideId, String feedback);

	// Method to get all bookings for a specific traveler
	List<UserGuideBookings> getBookingsByTraveller(int travellerId);

	// Method to give feedback on a guide
	UserGuideBookings giveGuideFeedback(int bookingId, String feedback, int rating);
}