package com.explorer.Models;

import jakarta.persistence.*;
import java.time.LocalDateTime;

@Entity
@Table(name = "place_feedback")
public class PlaceFeedbacks {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int placeFeedbackId;

    @ManyToOne
    @JoinColumn(name = "user_id")
    private Users user;

    @ManyToOne
    @JoinColumn(name = "place_id")
    private Place place;

    @Column(columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")
    private LocalDateTime timestamp;

    @Column(nullable = false)
    private String placeFeedback;

    private int placeRating;

	public PlaceFeedbacks(int placeFeedbackId, Users user, Place place, LocalDateTime timestamp, String placeFeedback,
			int placeRating) {
		super();
		this.placeFeedbackId = placeFeedbackId;
		this.user = user;
		this.place = place;
		this.timestamp = timestamp;
		this.placeFeedback = placeFeedback;
		this.placeRating = placeRating;
	}
	
	
	public PlaceFeedbacks() {
		
	}

	public int getPlaceFeedbackId() {
		return placeFeedbackId;
	}

	public void setPlaceFeedbackId(int placeFeedbackId) {
		this.placeFeedbackId = placeFeedbackId;
	}

	public Users getUser() {
		return user;
	}

	public void setUser(Users user) {
		this.user = user;
	}

	public Place getPlace() {
		return place;
	}

	public void setPlace(Place place) {
		this.place = place;
	}

	public LocalDateTime getTimestamp() {
		return timestamp;
	}

	public void setTimestamp(LocalDateTime timestamp) {
		this.timestamp = timestamp;
	}

	public String getPlaceFeedback() {
		return placeFeedback;
	}

	public void setPlaceFeedback(String placeFeedback) {
		this.placeFeedback = placeFeedback;
	}

	public int getPlaceRating() {
		return placeRating;
	}

	public void setPlaceRating(int placeRating) {
		this.placeRating = placeRating;
	}

    
    
    
    
    
    
    
    
}

