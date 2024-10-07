package com.explorer.Models;

import jakarta.persistence.*;

@Entity
@Table(name = "place_feedback_images")
public class PlaceFeedbackImage {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int feedbackImageId;

    @ManyToOne
    @JoinColumn(name = "place_feedback_id")
    private PlaceFeedbacks placeFeedback;

    @ManyToOne
    @JoinColumn(name = "image_id")
    private Images image;

	public PlaceFeedbackImage(int feedbackImageId, PlaceFeedbacks placeFeedback, Images image) {
		super();
		this.feedbackImageId = feedbackImageId;
		this.placeFeedback = placeFeedback;
		this.image = image;
	}
	
	
	public PlaceFeedbackImage() {
		
	}

	public int getFeedbackImageId() {
		return feedbackImageId;
	}

	public void setFeedbackImageId(int feedbackImageId) {
		this.feedbackImageId = feedbackImageId;
	}

	public PlaceFeedbacks getPlaceFeedback() {
		return placeFeedback;
	}

	public void setPlaceFeedback(PlaceFeedbacks placeFeedback) {
		this.placeFeedback = placeFeedback;
	}

	public Images getImage() {
		return image;
	}

	public void setImage(Images image) {
		this.image = image;
	}

    
    
    
    
}
