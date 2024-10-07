package com.explorer.Controllers;

import com.explorer.Models.*;
import com.explorer.Services.AdminService;
import com.explorer.Services.CitiesService;
import com.explorer.Services.GuideFeedbackService;
import com.explorer.Services.GuideService;
import com.explorer.Services.PlaceService;
import com.explorer.Services.TravelerService;
import com.explorer.Services.UserGuideBookingsService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Lazy;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/traveler")
@PreAuthorize("hasRole('Traveler')")
public class TravelerController {

    @Autowired
    private TravelerService travelerService;
    
    @Autowired
    private CitiesService citiesService;
    
    @Autowired
    AdminService adminService;
    
    @Autowired
    GuideService guideService;
    
    @Autowired
    private PlaceService placeService;

    @Autowired
    private GuideFeedbackService guideFeedbackService;

    @Autowired
    @Lazy
    private UserGuideBookingsService userGuideBookingsService;

    @PostMapping("/register")
    public ResponseEntity<Users> registerTraveller(@RequestBody Users user) {
        Users registeredUser = travelerService.registerTraveller(user);
        return ResponseEntity.ok(registeredUser);
    }

//    @PostMapping("/login")
//    public ResponseEntity<Users> loginTraveller(@RequestParam String email, @RequestParam String password) {
//        Users user = travelerService.loginTraveller(email, password);
//        if (user != null) {
//            return ResponseEntity.ok(user);
//        }
//        return ResponseEntity.status(401).build(); // Unauthorized
//    }
// Endpoint to get all bookings for a traveler
    @GetMapping("/{travellerId}/bookings")
    public ResponseEntity<List<UserGuideBookings>> getBookings(@PathVariable int travellerId) {
        List<UserGuideBookings> bookings = travelerService.getBookingsByTraveller(travellerId);
        return ResponseEntity.ok(bookings);
    }

    @PostMapping("/submit-feedback/{guideId}")
    public ResponseEntity<String> submitFeedback(@PathVariable int guideId, @RequestBody GuideFeedbacks feedback) {
        guideFeedbackService.submitFeedback(guideId, feedback);
        return ResponseEntity.ok("Feedback submitted successfully");
    }

    @GetMapping("/me")
    public ResponseEntity<Users> getCurrentUser() {
        Users currentUser = guideFeedbackService.getCurrentUser();
        return ResponseEntity.ok(currentUser);
    }

    
    @GetMapping("/guides")
	public List<Users> getAllGuides() {
		return adminService.findAllGuides();
	}
    
    @GetMapping("/places")
    public List<Place> getAllPlaces() {
        return placeService.getAllPlaces();
    }

    @GetMapping("/locations")
    public ResponseEntity<List<Place>> viewAllLocations() {
        List<Place> locations = travelerService.viewAllLocations();
        return ResponseEntity.ok(locations);
    }
    
    @GetMapping("/completed")
    public List<?> getCompletedGuides() {
        return guideService.getCompletedGuides();
    }

    @PostMapping("/book-guide")
    public ResponseEntity<UserGuideBookings> bookGuide(@RequestBody UserGuideBookings booking) {
        UserGuideBookings bookedGuide = travelerService.bookGuide(booking);
        return ResponseEntity.ok(bookedGuide);
    }

    @PostMapping("/wishlist")
    public ResponseEntity<Wishlist> addToWishlist(@RequestBody Wishlist wishlist) {
        Wishlist savedWishlist = travelerService.addToWishlist(wishlist);
        return ResponseEntity.ok(savedWishlist);
    }
    
    @GetMapping("/city")
    public List<Cities> getAllCities() {
        return citiesService.getAllCities();
    }

    @GetMapping("/city/place/{cityId}")
    public ResponseEntity<List<Place>> getPlacesByCityId(@PathVariable int cityId) {
        List<Place> places = placeService.getPlacesByCityId(cityId);
        return ResponseEntity.ok(places);
    }
    
    @GetMapping("/city/{id}")
    public ResponseEntity<Cities> getCityById(@PathVariable int id) {
        Optional<Cities> city = citiesService.getCityById(id);
        return city.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }


//    @PostMapping("/feedback/{bookingId}")
//    public ResponseEntity<String> giveFeedback(@PathVariable int bookingId,
//                                               @RequestParam String feedback,
//                                               @RequestParam int rating) {
//        Optional<UserGuideBookings> bookingOpt = userGuideBookingsService.getBookingById(bookingId);
//
//        if (bookingOpt.isPresent()) {
//            UserGuideBookings booking = bookingOpt.get();
//
//            // Check if the booking status is 'Completed'
//            if (booking.getStatus() == UserGuideBookings.BookingStatus.Completed) {
//                booking.setGuideFeedback(feedback);
//                booking.setGuideRating(rating);
//                
//                // Save the updated booking
//                userGuideBookingsService.saveBooking(booking);
//                return ResponseEntity.ok("Feedback and rating submitted successfully.");
//            } else {
//                return ResponseEntity.badRequest().body("Feedback can only be given for completed bookings.");
//            }
//        } else {
//            return ResponseEntity.badRequest().body("Booking not found.");
//        }
//    }
}