package com.explorer.Services;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import com.explorer.Models.Guide;
import com.explorer.Models.GuidePlaces;
import com.explorer.Models.UserGuideBookings;
import com.explorer.Models.Users;

public interface GuideService {

	void registerGuide(Users user);

	Guide viewGuideById(int guideId);

	List<GuidePlaces> viewPlaces(int guideId);

	void addPlace(GuidePlaces guidePlaces);

	void updatePlace(GuidePlaces guidePlaces);

	List<?> getCompletedGuides();
	
	void deletePlace(int gpId);

//	@Query("SELECT COALESCE(SUM(bpd.amount), 0) FROM BookingPaymentDetails bpd WHERE bpd.guide = :guide")
//    BigDecimal getTotalEarnings(@Param("guide") Guide guide);
//
//    // Example query to get tour history for a guide
//    @Query("SELECT b FROM Booking b WHERE b.guide = :guide")
//    List<Booking> getTourHistory(@Param("guide") Guide guide);
	
	List<UserGuideBookings> viewTourHistory(int guideId);

	void setGuideFee(int gpId, BigDecimal fee);

	BigDecimal getTotalPayment(int guideId);
	// void setBookingStatus(int bookingId, boolean status);
}
