package com.explorer.Services;

import java.util.List;

import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.multipart.MultipartFile;

import com.explorer.Models.BookingPlaceGuide;
import com.explorer.Models.Guide;
import com.explorer.Models.GuideFeedbacks;
import com.explorer.Models.Place;
import com.explorer.Models.PlaceImages;
import com.explorer.Models.Users;

public interface AdminService {
	List<Users> findAllUsers();
	@Transactional
	List<Users> findAllAdmins();

	@Transactional
	List<Users> findAllGuides();

//	GuideFeedbacks updateFeedback(Long feedbackId, GuideFeedbacks feedbackDetails);

//	void deleteFeedback(int feedbackId);

//	Guide verifyGuide(Long guideId);

//	Users approveGuideBooking(int bookingId);

	List<BookingPlaceGuide> findAllBookings();

	Place updateLocation(int locationId, Place locationDetails);

	void deleteLocation(int locationId);

	PlaceImages addImageToLocation(int locationId, MultipartFile image);
}
