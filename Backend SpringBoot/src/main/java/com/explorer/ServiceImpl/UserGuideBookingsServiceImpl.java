package com.explorer.ServiceImpl;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.explorer.Models.UserGuideBookings;
import com.explorer.Repositories.UserGuideBookingsRepository;
import com.explorer.Services.UserGuideBookingsService;

@Service
public class UserGuideBookingsServiceImpl implements UserGuideBookingsService{
	@Autowired
    private UserGuideBookingsRepository bookingsRepository;

		
    @Override
    public Optional<UserGuideBookings> getBookingById(int bookingId) {
        return bookingsRepository.findById(bookingId);
    }


	@Override
	public UserGuideBookings bookGuide(UserGuideBookings booking) {
		// TODO Auto-generated method stub
		return bookingsRepository.save(booking);
	}

	@Override
	public UserGuideBookings updateBooking(UserGuideBookings booking) {
		// TODO Auto-generated method stub
		return bookingsRepository.save(booking);
	}

	@Override
	public void cancelBooking(int bookingId) {
		bookingsRepository.deleteById(bookingId);
	}

	@Override
	public List<UserGuideBookings> getBookingsByUser(int userId) {
		// TODO Auto-generated method stub
		return bookingsRepository.findByUserUserId(userId);
	}

	@Override
	public List<UserGuideBookings> getBookingsByGuide(int guideId) {
		return bookingsRepository.findAllByGuide_GuideId(guideId);
	}


	@Override
	public List<UserGuideBookings> findBookingByGuideId(int guideId) {
		return bookingsRepository.findBookingByGuideId(guideId);
	}
}
