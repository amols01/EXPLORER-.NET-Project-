package com.explorer.Models;

import jakarta.persistence.*;

@Entity
@Table(name = "place_images")
public class PlaceImages {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int placeImageId;

    @ManyToOne
    @JoinColumn(name = "place_id")
    private Place place;

    @ManyToOne
    @JoinColumn(name = "image_id")
    private Images image;

	
    public PlaceImages(int placeImageId, Place place, Images image) {
		super();
		this.placeImageId = placeImageId;
		this.place = place;
		this.image = image;
	}
    
    public PlaceImages() {
    	
    }


    
	public int getPlaceImageId() {
		return placeImageId;
	}


	public void setPlaceImageId(int placeImageId) {
		this.placeImageId = placeImageId;
	}


	public Place getPlace() {
		return place;
	}


	public void setPlace(Place place) {
		this.place = place;
	}


	public Images getImage() {
		return image;
	}


	public void setImage(Images image) {
		this.image = image;
	}

    
    
    
}

