package com.explorer.Models;

import java.time.LocalDateTime;
import java.time.LocalTime;

import com.fasterxml.jackson.annotation.JsonIgnore;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;

@Entity
@Table(name = "userguidebookings")
public class UserGuideBookings {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int bookingId;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "user_id")
	@JsonIgnore
	private Users user;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "guide_id ")
	@JsonIgnore
	private Guide guide;

	private LocalDateTime dateTo;
	private LocalDateTime dateFrom;

	private LocalTime timeFrom;
	private LocalTime timeTo;
	@Column(columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP", insertable = false, updatable = false)
	private LocalDateTime timestamp;

	public enum BookingStatus {
		Pending, Confirmed, InProgress, Completed, Cancelled
	}

	@Enumerated(EnumType.STRING)
    private BookingStatus status;
	
	@ManyToOne
	@JoinColumn(name = "bill_id", referencedColumnName = "billId")
	private Bill bill;
	
	private String guideFeedback;
	
	private int guideRating;

	public UserGuideBookings(int bookingId, Users user, LocalDateTime dateTo, LocalDateTime dateFrom,
			LocalTime timeFrom, LocalTime timeTo, LocalDateTime timestamp, Bill bill) {
		super();
		this.bookingId = bookingId;
		this.user = user;
		this.dateTo = dateTo;
		this.dateFrom = dateFrom;
		this.timeFrom = timeFrom;
		this.timeTo = timeTo;
		this.timestamp = timestamp;
		this.bill = bill;
	}

	public UserGuideBookings() {

	}
	
	

	public Guide getGuide() {
		return guide;
	}

	public void setGuide(Guide guide) {
		this.guide = guide;
	}

	public int getBookingId() {
		return bookingId;
	}

	public void setBookingId(int bookingId) {
		this.bookingId = bookingId;
	}

	public Users getUser() {
		return user;
	}

	public void setUser(Users user) {
		this.user = user;
	}

	public LocalDateTime getDateTo() {
		return dateTo;
	}

	public void setDateTo(LocalDateTime dateTo) {
		this.dateTo = dateTo;
	}

	public LocalDateTime getDateFrom() {
		return dateFrom;
	}

	public void setDateFrom(LocalDateTime dateFrom) {
		this.dateFrom = dateFrom;
	}

	public LocalTime getTimeFrom() {
		return timeFrom;
	}

	public void setTimeFrom(LocalTime timeFrom) {
		this.timeFrom = timeFrom;
	}

	public LocalTime getTimeTo() {
		return timeTo;
	}

	public void setTimeTo(LocalTime timeTo) {
		this.timeTo = timeTo;
	}

	public BookingStatus getStatus() {
		return status;
	}

	public void setStatus(BookingStatus status) {
		this.status = status;
	}

	public LocalDateTime getTimestamp() {
		return timestamp;
	}

	public void setTimestamp(LocalDateTime timestamp) {
		this.timestamp = timestamp;
	}

	public Bill getBill() {
		return bill;
	}

	public String getGuideFeedback() {
		return guideFeedback;
	}

	public void setGuideFeedback(String guideFeedback) {
		this.guideFeedback = guideFeedback;
	}

	public int getGuideRating() {
		return guideRating;
	}

	public void setGuideRating(int guideRating) {
		this.guideRating = guideRating;
	}

	public void setBill(Bill bill) {
		this.bill = bill;
	}
}
