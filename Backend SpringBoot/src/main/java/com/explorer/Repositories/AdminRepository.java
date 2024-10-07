package com.explorer.Repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import com.explorer.Models.BookingPlaceGuide;
import com.explorer.Models.Images;
import com.explorer.Models.PlaceImages;
import com.explorer.Models.Users;


@Repository
public interface AdminRepository extends JpaRepository<Users, Integer> {

	@Procedure(procedureName = "findAllAdmins")
    List<Users> findAllAdmins();

    // Call stored procedure to find all guides
	@Transactional
    @Procedure(procedureName = "findAllGuides")
    List<Users> findAllGuides();

    // Call stored procedure to find all travelers
	@Transactional
    @Procedure(procedureName = "findAllTravelers")
    List<Users> findAllTravelers();

//	@Modifying
//	@Transactional
//	@Query("UPDATE Guide_Feedback f SET f.guide_feedback = :content WHERE f.guide_feedback_id = :feedbackId")
//	void updateFeedback(@Param("feedbackId") Long feedbackId, @Param("content") String content);

//	@Modifying
//	@Transactional
//	@Query("DELETE FROM Feedback f WHERE f.id = :feedbackId")
//	void deleteFeedback(@Param("feedbackId") int feedbackId);

//    @Modifying
//    @Transactional
//    @Query("UPDATE Users u SET u.verified = true WHERE u.id = :guideId AND u.role = 'Guide'")
//    void verifyGuide(@Param("guideId") Long guideId);

//	@Modifying
//	@Transactional
//	@Query("UPDATE BookingPlaceGuide b SET b.approved = true WHERE b.id = :bookingId")
//	Users approveGuideBooking(@Param("bookingId") int bookingId);

	@Query("SELECT b FROM BookingPlaceGuide b")
	List<BookingPlaceGuide> findAllBookings();

	@Modifying
	@Transactional
	@Query("UPDATE Place l SET l.placeName = :placeName, l.description = :description WHERE l.placeId = :placeId")
	void updateLocation(@Param("placeId") int placeId, @Param("placeName") String placeName, @Param("description") String description);

	@Modifying
	@Transactional
	@Query("DELETE FROM Place l WHERE l.placeId = :placeId")
	void deleteLocation(@Param("placeId") int placeId);

	@Modifying
	@Transactional
	@Query("UPDATE PlaceImages l SET l.image = :image WHERE l.place.placeId = :placeId")
	PlaceImages addImageToLocation(@Param("placeId") int placeId, @Param("image") Images image);
//	@Modifying
//	@Transactional
//	@Query("INSERT INTO Users u (name, email, password, role) VALUES (:name, :email, :password, 'Admin')")
//	void registerAdmin(@Param("name") String name, @Param("email") String email, @Param("password") String password);
}