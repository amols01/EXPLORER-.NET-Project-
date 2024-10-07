package com.explorer.Services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Service;

import com.explorer.Models.UserGuideBookings;
import com.explorer.Repositories.UserGuideBookingsRepository;

@Service
public interface UserGuideBookingsService {

	public Optional<UserGuideBookings> getBookingById(int bookingId);

	UserGuideBookings bookGuide(UserGuideBookings booking);

	UserGuideBookings updateBooking(UserGuideBookings booking);

	List<UserGuideBookings> findBookingByGuideId(int guideId);
	
	void cancelBooking(int bookingId);

	List<UserGuideBookings> getBookingsByUser(int userId);

	List<UserGuideBookings> getBookingsByGuide(int guideId);
}
