package com.explorer.Services;

import java.util.List;
import java.util.Optional;

import com.explorer.Models.Cities;

public interface CitiesService {
	List<Cities> getAllCities();
    Optional<Cities> getCityById(int id);
    Cities addCity(Cities city);
    Cities updateCity(int id, Cities city);
    void deleteCity(int id);
}
