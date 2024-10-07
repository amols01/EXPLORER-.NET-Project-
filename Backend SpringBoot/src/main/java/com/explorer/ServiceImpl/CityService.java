package com.explorer.ServiceImpl;

import org.springframework.stereotype.Service;

import com.explorer.Models.Cities;
import com.explorer.Models.MStates;

import jakarta.persistence.EntityManager;
import jakarta.persistence.PersistenceContext;
import jakarta.transaction.Transactional;


@Service
public class CityService {
	@PersistenceContext
    private EntityManager entityManager;

    @Transactional
    public void saveOrUpdateCity(Cities city) {
        if (city.getCityId() == 0) {
            entityManager.persist(city);
        } else {
            // Existing entity
            entityManager.merge(city);
        }
    }
    
    @Transactional
    public Cities findCityById(int cityId) {
        return entityManager.find(Cities.class, cityId);
    }
    
    @Transactional
    public void updateCity(int cityId, String newCityName, int stateId) {
        Cities city = entityManager.find(Cities.class, cityId);
        MStates state = entityManager.find(MStates.class, stateId);
        if (city != null && state != null) {
            city.setCity(newCityName);
            city.setState(state);
            entityManager.merge(city);
        }
    }

}
