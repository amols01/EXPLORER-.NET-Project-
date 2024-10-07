package com.explorer.Repositories;

import java.math.BigDecimal;
import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;

import com.explorer.Models.BookingPaymentDetails;
import com.explorer.Models.Guide;
import com.explorer.Models.UserGuideBookings;
import com.explorer.Models.Users;

import jakarta.transaction.Transactional;

public interface GuideRepository extends JpaRepository<Guide, Integer> {

	@Transactional
	@Procedure(procedureName = "findAllByGuide_GuideIdList")
	List<Guide> findAllByGuide_GuideIdList(@Param("guideId") int guideId);

	@Transactional
	@Procedure(procedureName = "findAllByGuide_GuideId")
	List<UserGuideBookings> findAllByGuide_GuideId(@Param("guideId") int guideId);

	@Transactional
	@Procedure(procedureName = "findAllByGuide_GuideId")
	List<Guide> findAllByGuide_GuideIdForGuide(@Param("guideId") int guideId);

//	@Transactional
//	@Procedure(procedureName = "findAllByGuide_GuideId")
//	Guide findAllByGuide_GuideIdForGuideId(@Param("guideId") int guideId);

	
	@Transactional
	@Query(value = "CALL GetCompletedGuides()", nativeQuery = true)
	List<?> getCompletedGuides();

	@Transactional
	@Procedure(procedureName = "findAllByBooking_Guide_GuideId")
	List<BookingPaymentDetails> findAllByBooking_Guide_GuideId(@Param("guideId") int guideId);

	Optional<Guide> findByAadharNumber(String aadharNumber);

	Optional<Guide> findByPanNumber(String panNumber);

	Optional<Guide> findByAccountNumber(String accountNumber);

	@Modifying
	@Transactional
	@Procedure(procedureName = "setGuideFee")
	void setGuideFee(@Param("gpId") int gpId, @Param("fee") BigDecimal fee);

	@Modifying
	@Transactional
	@Procedure(procedureName = "setBookingStatus")
	void setBookingStatus(@Param("bookingId") int bookingId, @Param("status") boolean status);

	@Procedure(procedureName = "findTotalPaymentByGuideId")
	BigDecimal findTotalPaymentByGuideId(@Param("guideId") int guideId, @Param("totalPayment") BigDecimal totalPayment);

	@Transactional
	@Procedure(procedureName = "findAllByGuide_GuideId")
	Guide findAllByGuide_GuideIdForGuideId(int guideId);
}