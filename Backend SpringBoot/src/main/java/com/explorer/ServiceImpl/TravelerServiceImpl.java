package com.explorer.ServiceImpl;

import com.explorer.Models.*;
import com.explorer.Repositories.*;
import com.explorer.Services.TravelerService;

import jakarta.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class TravelerServiceImpl implements TravelerService {

	@Autowired
	private UsersRepository userRepository;

	@Autowired
	private PlaceRepository placeRepository;

	@Autowired
	private UserGuideBookingsRepository userGuideBookingsRepository;

	@Autowired
	private WishlistRepository wishlistRepository;

	@Autowired
	private GuideRepository guideRepository;

	@Override
	public Users registerTraveller(Users user) {
		return userRepository.save(user);
	}

//    @Override
//    public Optional<Users> loginTraveller(String email, String password) {
//        Optional<Users> user = userRepository.findByEmail(email);
//        if (user != null && user.getPassword().equals(password)) {
//            return user;
//        }
//        return null; // Or throw an exception if needed
//    }

	@Override
	public List<Place> viewAllLocations() {
		return placeRepository.findAll();
	}

	@Override
	public UserGuideBookings bookGuide(UserGuideBookings booking) {
		return userGuideBookingsRepository.save(booking);
	}

	@Override
	public Wishlist addToWishlist(Wishlist wishlist) {
		return wishlistRepository.save(wishlist);
	}

	@Override
	public void giveFeedback(int guideId, String feedback) {
		Guide guide = guideRepository.findById(guideId).orElseThrow(() -> new RuntimeException("Guide not found"));
		// Assuming there's a field in the Guide entity for feedback
		// guide.setFeedback(feedback);
		guideRepository.save(guide);
	}

	@Override
	@Transactional
	public List<UserGuideBookings> getBookingsByTraveller(int travellerId) {
		return userGuideBookingsRepository.findByUserUserId(travellerId);
	}

	@Override
	public UserGuideBookings giveGuideFeedback(int bookingId, String feedback, int rating) {
		UserGuideBookings booking = userGuideBookingsRepository.findById(bookingId)
				.orElseThrow(() -> new RuntimeException("Booking not found"));

		booking.setGuideFeedback(feedback);
		booking.setGuideRating(rating);
		booking.setStatus(UserGuideBookings.BookingStatus.Completed); 
																		

		return userGuideBookingsRepository.save(booking);
	}
}