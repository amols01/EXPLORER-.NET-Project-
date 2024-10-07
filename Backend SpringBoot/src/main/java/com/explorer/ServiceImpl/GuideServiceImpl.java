package com.explorer.ServiceImpl;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.explorer.Models.BookingPaymentDetails;
import com.explorer.Models.Guide;
import com.explorer.Models.GuidePlaces;
import com.explorer.Models.UserGuideBookings;
import com.explorer.Models.Users;
import com.explorer.Repositories.BookingPaymentDetailsRepository;
import com.explorer.Repositories.GuidePlacesRepository;
import com.explorer.Repositories.GuideRepository;
import com.explorer.Repositories.UserGuideBookingsRepository;
import com.explorer.Services.GuideService;

import jakarta.transaction.Transactional;

@Service
public class GuideServiceImpl implements GuideService {
	@Autowired
	private GuideRepository guideRepository;

	@Autowired
	private GuidePlacesRepository guidePlacesRepository;

	@Autowired
	private UserGuideBookingsRepository userGuideBookingsRepository;

	@Autowired
	private BookingPaymentDetailsRepository bookingPaymentDetailsRepository;

	@Override
	public void registerGuide(Users user) {
		// Check if the user has the role of Guide
		if (user.getRole() != null && user.getRole().getRoleId() == 2) { // Assuming roleId=2 corresponds to Guide
			// Create new Guide record
			Guide guide = new Guide();
			guide.setUser(user);
			// Set other properties of Guide as needed
			guideRepository.save(guide);
		}
	}

	@Override
	public Guide viewGuideById(int guideId) {
		return guideRepository.findById(guideId).orElse(null);
	}

//    @Override
//    public List<GuidePlaces> viewPlaces(int guideId) {
//        return guidePlacesRepository.findAllByGuide_GuideId(guideId);
//    }

	@Override
	public void addPlace(GuidePlaces guidePlaces) {
		guidePlacesRepository.save(guidePlaces);
	}

	@Override
	public void updatePlace(GuidePlaces guidePlaces) {
		guidePlacesRepository.save(guidePlaces);
	}

	@Override
	public void deletePlace(int gpId) {
		guidePlacesRepository.deleteById(gpId);
	}

	@Override
	@Transactional
	public List<UserGuideBookings> viewTourHistory(int guideId) {
		return userGuideBookingsRepository.findAllByGuide_GuideId(guideId);
	}

	@Override
	public void setGuideFee(int gpId, BigDecimal fee) {
		GuidePlaces guidePlaces = guidePlacesRepository.findById(gpId).orElse(null);
		if (guidePlaces != null) {
			guidePlaces.setGuideFee(fee);
			guidePlacesRepository.save(guidePlaces);
		}
	}

	@Override
	@Transactional
	public BigDecimal getTotalPayment(int guideId) {
		List<BookingPaymentDetails> payments = bookingPaymentDetailsRepository.findAllByBooking_Guide_GuideId(guideId);
		return payments.stream().map(BookingPaymentDetails::getAmount) // Assumes there is a method to get the amount
				.reduce(BigDecimal.ZERO, BigDecimal::add);
	}

//	@Override
//	public void setBookingStatus(int bookingId, BookingStatus status) {
//		UserGuideBookings booking = userGuideBookingsRepository.findById(bookingId).orElse(null);
//		if (booking != null) {
//			booking.setStatus(UserGuideBookings.BookingStatus.status);
//			userGuideBookingsRepository.save(booking);
//		}
//	}

	@Override
	@Transactional
	public List<GuidePlaces> viewPlaces(int guideId) {
		return guidePlacesRepository.findAllByGuide_GuideId(guideId);
	}

	@Override
	public List<?> getCompletedGuides() {
        return guideRepository.getCompletedGuides();
    }
}
