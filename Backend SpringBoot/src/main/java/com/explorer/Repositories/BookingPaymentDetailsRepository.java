package com.explorer.Repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.explorer.Models.BookingPaymentDetails;

import jakarta.transaction.Transactional;

@Repository
public interface BookingPaymentDetailsRepository extends JpaRepository<BookingPaymentDetails, String> {
	
	@Transactional
	@Procedure(procedureName = "findAllByBooking_Guide_GuideId")
	List<BookingPaymentDetails> findAllByBooking_Guide_GuideId(@Param("guideId") int guideId);
}