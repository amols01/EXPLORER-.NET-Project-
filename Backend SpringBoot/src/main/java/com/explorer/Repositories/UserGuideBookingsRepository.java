package com.explorer.Repositories;

import java.util.List;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;

import com.explorer.Models.UserGuideBookings;

import jakarta.transaction.Transactional;

public interface UserGuideBookingsRepository extends JpaRepository<UserGuideBookings, Integer> {
	@Transactional
	@Procedure(procedureName = "findAllByGuide_GuideId")
	List<UserGuideBookings> findAllByGuide_GuideId(@Param("guideId") int guideId);

	@Query("SELECT ugb FROM UserGuideBookings ugb WHERE ugb.guide.guideId = :guideId")
	List<UserGuideBookings> findBookingByGuideId(@Param("guideId") int guideId);

	List<UserGuideBookings> findByUserUserId(int userId);
}