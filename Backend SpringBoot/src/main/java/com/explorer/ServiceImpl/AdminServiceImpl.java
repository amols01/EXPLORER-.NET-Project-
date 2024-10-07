package com.explorer.ServiceImpl;

import java.io.IOException;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.multipart.MultipartFile;

import com.explorer.Models.BookingPlaceGuide;
import com.explorer.Models.Guide;
import com.explorer.Models.GuideFeedbacks;
import com.explorer.Models.Images;
import com.explorer.Models.Place;
import com.explorer.Models.PlaceImages;
import com.explorer.Models.Users;
import com.explorer.Repositories.AdminRepository;
import com.explorer.Services.AdminService;

@Service
public class AdminServiceImpl implements AdminService {

	@Autowired
	private AdminRepository adminRepository;

	@Override
	public List<Users> findAllUsers() {
		return adminRepository.findAll();
	}

	@Override
	public List<Users> findAllAdmins() {
		return adminRepository.findAllAdmins();
	}

	@Override
	public List<Users> findAllGuides() {
		return adminRepository.findAllGuides();
	}

//	@Override
//	public GuideFeedbacks updateFeedback(Long feedbackId, GuideFeedbacks feedbackDetails) {
//		adminRepository.updateFeedback(feedbackId, feedbackDetails.getGuideFeedback());
//		return feedbackDetails; 
//	}

//	@Override
//	public void deleteFeedback(int feedbackId) {
//		adminRepository.deleteFeedback(feedbackId);
//	}

//    @Override
//    public Users verifyGuide(Long guideId) {
//        adminRepository.verifyGuide(guideId);
//        return adminRepository.findById(guideId.intValue()).orElse(null); // Convert Long to Integer
//    }

//	@Override
//	public Users approveGuideBooking(int bookingId) {
//		adminRepository.approveGuideBooking(bookingId);
//		return adminRepository.findById(bookingId).orElse(null); // Convert Long to Integer
//	}

	@Override
	public List<BookingPlaceGuide> findAllBookings() {
		return adminRepository.findAllBookings();
	}

	@Override
	public Place updateLocation(int locationId, Place locationDetails) {
		adminRepository.updateLocation(locationId, locationDetails.getPlaceName(), locationDetails.getDescription());
		return locationDetails; // Return the updated location
	}

	@Override
	public void deleteLocation(int locationId) {
		if (!adminRepository.existsById(locationId)) {
			// Location ID not found, throw an exception
			throw new LocationNotFoundException("Location with ID " + locationId + " does not exist.");
		}
		// Location exists, proceed with deletion
		adminRepository.deleteLocation(locationId);
	}

	@Override
	public PlaceImages addImageToLocation(int locationId, MultipartFile imageFile) {
		// Convert MultipartFile to byte[]
		byte[] imageBytes;
		try {
			imageBytes = imageFile.getBytes();
		} catch (IOException e) {
			throw new RuntimeException("Failed to convert MultipartFile to byte array", e);
		}

		// Create an Images object
		Images image = new Images(imageBytes);

		// Save the image using your repository
		return adminRepository.addImageToLocation(locationId, image);
	}

	public class LocationNotFoundException extends RuntimeException {
		public LocationNotFoundException(String message) {
			super(message);
		}
	}
}