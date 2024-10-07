package com.explorer.Repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.explorer.Models.Cities;

public interface CitiesRepository extends JpaRepository<Cities, Integer>{

}
