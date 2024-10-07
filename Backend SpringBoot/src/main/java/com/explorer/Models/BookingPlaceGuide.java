package com.explorer.Models;

import jakarta.persistence.*;

@Entity
@Table(name = "booking_place_guide")
public class BookingPlaceGuide {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int bookingPlaceId;

    @ManyToOne
    @JoinColumn(name = "booking_id")
    private UserGuideBookings booking;

    @ManyToOne
    @JoinColumn(name = "guide_id")
    private Guide guide;

    @ManyToOne
    @JoinColumn(name = "place_id")
    private Place place;

	public BookingPlaceGuide(int bookingPlaceId, UserGuideBookings booking, Guide guide, Place place) {
		super();
		this.bookingPlaceId = bookingPlaceId;
		this.booking = booking;
		this.guide = guide;
		this.place = place;
	}
	
	public BookingPlaceGuide() {
	
	}
	

	public int getBookingPlaceId() {
		return bookingPlaceId;
	}

	public void setBookingPlaceId(int bookingPlaceId) {
		this.bookingPlaceId = bookingPlaceId;
	}

	public UserGuideBookings getBooking() {
		return booking;
	}

	public void setBooking(UserGuideBookings booking) {
		this.booking = booking;
	}

	public Guide getGuide() {
		return guide;
	}

	public void setGuide(Guide guide) {
		this.guide = guide;
	}

	public Place getPlace() {
		return place;
	}

	public void setPlace(Place place) {
		this.place = place;
	}

    
	
}

