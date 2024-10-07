package com.explorer.Models;

import jakarta.persistence.*;
import java.math.BigDecimal;


@Entity
@Table(name = "guide_places")
public class GuidePlaces {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int gpId;

    @ManyToOne
    @JoinColumn(name = "guide_id")
    private Guide guide;

    @ManyToOne
    @JoinColumn(name = "place_id")
    private Place place;

    @Column(nullable = true)
    private BigDecimal guideFee;

	public GuidePlaces(int gpId, Guide guide, Place place, BigDecimal guideFee) {
		super();
		this.gpId = gpId;
		this.guide = guide;
		this.place = place;
		this.guideFee = guideFee;
	}

	
	public GuidePlaces() {
		
	}
	
	public int getGpId() {
		return gpId;
	}

	public void setGpId(int gpId) {
		this.gpId = gpId;
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

	public BigDecimal getGuideFee() {
		return guideFee;
	}

	public void setGuideFee(BigDecimal guideFee) {
		this.guideFee = guideFee;
	}

    
	
}

