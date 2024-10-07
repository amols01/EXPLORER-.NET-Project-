package com.explorer.Repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.query.Procedure;

import com.explorer.Models.GuidePlaces;

import jakarta.transaction.Transactional;

public interface GuidePlacesRepository extends JpaRepository<GuidePlaces, Integer> {
	
	@Transactional
	@Procedure(procedureName = "findAllByGuide_GuideId")
	List<GuidePlaces> findAllByGuide_GuideId(int guideId);
}
