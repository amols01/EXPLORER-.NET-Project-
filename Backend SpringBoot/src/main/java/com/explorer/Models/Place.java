package com.explorer.Models;

import jakarta.persistence.*;

@Entity
@Table(name = "place")
public class Place {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int placeId;

    @Column(length = 255, nullable = false)
    private String placeName;

    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "city_id")
    private Cities city;

    @Column(nullable = false)
    private String image;
    
    @Column(length = 255)
    private String address;

    private String description;

    @Column(length = 255)
    private String nearestPS;

    public Place(int id) {
        this.placeId = id;
    }
	public Place(String image,int placeId, String placeName, Cities city, String address, String description, String nearestPS) {
		super();
		this.placeId = placeId;
		this.placeName = placeName;
		this.city = city;
		this.address = address;
		this.description = description;
		this.nearestPS = nearestPS;
		this.image = image;
	}
	
	public Place() {
		
	}

	
	public String getImage() {
		return image;
	}
	public void setImage(String image) {
		this.image = image;
	}
	public int getPlaceId() {
		return placeId;
	}

	public void setPlaceId(int placeId) {
		this.placeId = placeId;
	}

	public String getPlaceName() {
		return placeName;
	}

	public void setPlaceName(String placeName) {
		this.placeName = placeName;
	}

	public Cities getCity() {
		return city;
	}

	public void setCity(Cities city) {
		this.city = city;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getNearestPS() {
		return nearestPS;
	}

	public void setNearestPS(String nearestPS) {
		this.nearestPS = nearestPS;
	}
  
}

