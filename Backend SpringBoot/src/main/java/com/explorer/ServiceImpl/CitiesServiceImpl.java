package com.explorer.ServiceImpl;

import com.explorer.Models.Cities;
import com.explorer.Repositories.CitiesRepository;
import com.explorer.Services.CitiesService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class CitiesServiceImpl implements CitiesService {

    @Autowired
    private CitiesRepository citiesRepository;

    @Override
    public List<Cities> getAllCities() {
        return citiesRepository.findAll();
    }

    @Override
    public Optional<Cities> getCityById(int id) {
        return citiesRepository.findById(id);
    }

    @Override
    public Cities addCity(Cities city) {
        return citiesRepository.save(city);
    }

    @Override
    public Cities updateCity(int id, Cities city) {
        Optional<Cities> existingCity = citiesRepository.findById(id);
        if (existingCity.isPresent()) {
            Cities updatedCity = existingCity.get();
            updatedCity.setCity(city.getCity());
            updatedCity.setState(city.getState());
            return citiesRepository.save(updatedCity);
        } else {
            throw new IllegalArgumentException("City with ID " + id + " not found.");
        }
    }

    @Override
    public void deleteCity(int id) {
        if (citiesRepository.existsById(id)) {
            citiesRepository.deleteById(id);
        } else {
            throw new IllegalArgumentException("City with ID " + id + " not found.");
        }
    }
}