package com.explorer.Services;

import java.util.List;
import java.util.Optional;

import com.explorer.Models.Place;

public interface PlaceService {
	List<Place> getAllPlaces();

	Optional<Place> getPlaceById(int placeId);

	//public Place addPlace(String image, String placeName, int cityId, String address, String description, String nearestPS);

	public Place addPlace(Place place);
	
	Place updatePlace(Place place);
	public List<Place> getPlacesByCityId(int cityId);

	void deletePlace(int placeId);
}