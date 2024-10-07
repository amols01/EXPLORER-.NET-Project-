package com.explorer.Controllers;

public class PlaceDTO {
	private String image;
	private String placeName;
	private int cityId;
	
	private String address;
	private String description;
	private String nearestPS;

	public String getImage() {
		return image;
	}

	public void setImage(String image) {
		this.image = image;
	}

	public String getPlaceName() {
		return placeName;
	}

	public void setPlaceName(String placeName) {
		this.placeName = placeName;
	}

	public int getCityId() {
		return cityId;
	}

	public void setCityId(int cityId) {
		this.cityId = cityId;
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
