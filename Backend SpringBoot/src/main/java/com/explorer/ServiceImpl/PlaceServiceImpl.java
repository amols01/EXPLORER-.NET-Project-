package com.explorer.ServiceImpl;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.explorer.Models.Cities;
import com.explorer.Models.MStates;
import com.explorer.Models.Place;
import com.explorer.Repositories.CitiesRepository;
import com.explorer.Repositories.PlaceRepository;
import com.explorer.Services.PlaceService;

import jakarta.transaction.Transactional;

@Service
public class PlaceServiceImpl implements PlaceService {
	@Autowired
	
	private PlaceRepository placeRepository;

	@Autowired
	private CitiesRepository citiesRepository;
	
	@Override
	public List<Place> getAllPlaces() {
		return placeRepository.findAll();
	}

	@Override
	public Optional<Place> getPlaceById(int placeId) {
		return placeRepository.findById(placeId);
	}

	public List<Place> getPlacesByCityId(int cityId) {
        return placeRepository.findByCityCityId(cityId);
    }
	@Override
	public Place updatePlace(Place place) {
	    // Fetch the existing Place entity from the repository
	    Place existingPlace = placeRepository.findById(place.getPlaceId())
	            .orElseThrow(() -> new IllegalArgumentException("Invalid place ID: " + place.getPlaceId()));
	    
	    // Fetch the City entity to ensure it is valid
	    Cities city = citiesRepository.findById(place.getCity().getCityId())
	            .orElseThrow(() -> new IllegalArgumentException("Invalid city ID: " + place.getCity().getCityId()));
	    
	    // Set the city to ensure the Place entity has a valid Cities object
	    existingPlace.setCity(city);
	    
	    // Update other fields
	    existingPlace.setPlaceName(place.getPlaceName());
	    existingPlace.setAddress(place.getAddress());
	    existingPlace.setDescription(place.getDescription());
	    existingPlace.setNearestPS(place.getNearestPS());
	    existingPlace.setImage(place.getImage());
	    
	    // Save and return the updated Place entity
	    return placeRepository.save(existingPlace);
	}

	@Override
	public void deletePlace(int placeId) {
		placeRepository.deleteById(placeId);
	}

	@Override
	public Place addPlace(Place place) {
		Cities city = citiesRepository.findById(place.getCity().getCityId())
		        .orElseThrow(() -> new IllegalArgumentException("Invalid city ID: " + place.getCity().getCityId()));
		    // Set the city to ensure the Place entity has a valid Cities object
		    place.setCity(city);
		    // Save and return the Place entity
		    return placeRepository.save(place);
	}
}
