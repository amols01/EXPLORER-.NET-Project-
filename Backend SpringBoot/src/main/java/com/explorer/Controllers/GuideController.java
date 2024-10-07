package com.explorer.Controllers;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import com.explorer.Models.Guide;
import com.explorer.Models.GuidePlaces;
import com.explorer.Models.Place;
import com.explorer.Models.UserGuideBookings;
import com.explorer.Services.GuideService;
import com.explorer.Services.PlaceService;

@RestController
@RequestMapping("/guide")
@PreAuthorize("hasRole('Guide')")
public class GuideController {

	@Autowired
	private GuideService guideService;

	@Autowired
	private PlaceService placeService;

	
	@GetMapping("/{guideId}")
	public ResponseEntity<Guide> getGuideById(@PathVariable int guideId) {
		Guide guide = guideService.viewGuideById(guideId);
		if (guide != null) {
			return ResponseEntity.ok(guide);
		} else {
			return ResponseEntity.notFound().build();
		}
	}

	@GetMapping("/{guideId}/places")
	public ResponseEntity<List<GuidePlaces>> getPlacesByGuideId(@PathVariable int guideId) {
		List<GuidePlaces> places = guideService.viewPlaces(guideId);
		return ResponseEntity.ok(places);
	}

	@PostMapping("/places/add")
	public Place addPlace(@RequestBody Place place) {
	    return placeService.addPlace(place);
	}


	@PutMapping("/places")
	public ResponseEntity<Place> updatePlace(@PathVariable("id") int placeId, @RequestBody Place place) {
	    // Set the placeId
	    place.setPlaceId(placeId);

	    // Update place
	    Place updatedPlace = placeService.updatePlace(place);
	    return ResponseEntity.ok(updatedPlace);
	}
	@DeleteMapping("/places/{gpId}")
	public ResponseEntity<Void> deletePlace(@PathVariable int gpId) {
		guideService.deletePlace(gpId);
		return ResponseEntity.ok().build();
	}

	@GetMapping("/{guideId}/history")
	public ResponseEntity<List<UserGuideBookings>> getTourHistory(@PathVariable int guideId) {
		List<UserGuideBookings> history = guideService.viewTourHistory(guideId);
		return ResponseEntity.ok(history);
	}

	@PutMapping("/places/{gpId}/fee")
	public ResponseEntity<Void> setGuideFee(@PathVariable int gpId, @RequestParam BigDecimal fee) {
		guideService.setGuideFee(gpId, fee);
		return ResponseEntity.ok().build();
	}

	@GetMapping("/{guideId}/totalPayment")
	public ResponseEntity<BigDecimal> getTotalPayment(@PathVariable int guideId) {
		BigDecimal totalPayment = guideService.getTotalPayment(guideId);
		return ResponseEntity.ok(totalPayment);
	}

//    @PutMapping("/bookings/{bookingId}/status")
//    public ResponseEntity<Void> setBookingStatus(@PathVariable int bookingId, @RequestParam boolean status) {
//        guideService.setBookingStatus(bookingId, status);
//        return ResponseEntity.ok().build();
//    }
}
