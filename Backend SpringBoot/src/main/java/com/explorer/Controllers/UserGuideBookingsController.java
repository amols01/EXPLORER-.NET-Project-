package com.explorer.Controllers;

import com.explorer.Models.Bill;
import com.explorer.Models.Guide;
import com.explorer.Models.GuideFeedbacks;
import com.explorer.Models.UserGuideBookings;
import com.explorer.Models.Users;
import com.explorer.Repositories.BillRepository;
import com.explorer.Repositories.GuideFeedbackRepository;
import com.explorer.Repositories.GuideRepository;
import com.explorer.Repositories.UserGuideBookingsRepository;
import com.explorer.Repositories.UsersRepository;
import com.explorer.Services.UserGuideBookingsService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@PreAuthorize("permitAll()")
@RequestMapping("/bookings")
public class UserGuideBookingsController {

    @Autowired
    private UserGuideBookingsService bookingsService;
   

    @Autowired
    private GuideFeedbackRepository guideFeedbackRepository;
    
    @Autowired
    private UsersRepository userRepository;
    
    @Autowired
    private GuideRepository guideRepository;
    
    @Autowired
    private UserGuideBookingsRepository userGuideBookingsRepository;
    
    @Autowired
    private BillRepository billRepository;
    
    @PostMapping("/book")
    public ResponseEntity<?> bookGuide(@RequestBody UserGuideBookings request) {
        // Retrieve the User entity
    	System.out.println("User ID: " + request.getUser().getUserId());
    	System.out.println("Guide ID: " + request.getGuide().getGuideId());
    	System.out.println("Bill ID: " + request.getBill().getBillId());

        Optional<Users> optionalUser = userRepository.findById(request.getUser().getUserId());
        if (!optionalUser.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND)
                                 .body("User not found");
        }
        Users user = optionalUser.get();

        // Retrieve the Guide entity
        Optional<Guide> optionalGuide = guideRepository.findById(request.getGuide().getGuideId());
        if (!optionalGuide.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND)
                                 .body("Guide not found");
        }
        Guide guide = optionalGuide.get();

        // Retrieve the Bill entity
        Optional<Bill> optionalBill = billRepository.findById(request.getBill().getBillId());
        if (!optionalBill.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND)
                                 .body("Bill not found");
        }
        Bill bill = optionalBill.get();
      

        GuideFeedbacks guideFeedback = new GuideFeedbacks();
        guideFeedback.setGuideFeedback(request.getGuideFeedback());
        guideFeedback.setGuideRating(request.getGuideRating());
        guideFeedback.setUser(user);
        guideFeedback.setGuide(guide);
        guideFeedbackRepository.save(guideFeedback);
        // Create a new UserGuideBookings object
        UserGuideBookings booking = new UserGuideBookings();
        booking.setUser(user); // Set the user entity
        booking.setGuide(guide); // Set the guide entity
        booking.setDateFrom(request.getDateFrom());
        booking.setDateTo(request.getDateTo());
        booking.setTimeFrom(request.getTimeFrom());
        booking.setTimeTo(request.getTimeTo());
        booking.setStatus(request.getStatus());
        booking.setGuideFeedback(request.getGuideFeedback());
        booking.setGuideRating(request.getGuideRating());
        booking.setBill(bill); // Set the bill entity

        // Save the booking to the repository
        UserGuideBookings savedBooking = userGuideBookingsRepository.save(booking);
        return ResponseEntity.ok(savedBooking);
    }
    @PutMapping("/update")
    public ResponseEntity<UserGuideBookings> updateBooking(@RequestBody UserGuideBookings booking) {
        try {
            UserGuideBookings updated = bookingsService.updateBooking(booking);
            return ResponseEntity.ok(updated);
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(null);
        }
    }

    @DeleteMapping("/cancel/{bookingId}")
    public ResponseEntity<Void> cancelBooking(@PathVariable int bookingId) {
        try {
            bookingsService.cancelBooking(bookingId);
            return ResponseEntity.status(HttpStatus.NO_CONTENT).build();
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @GetMapping("/user/{userId}")
    public ResponseEntity<List<UserGuideBookings>> getBookingsByUser(@PathVariable int userId) {
        try {
            List<UserGuideBookings> bookings = bookingsService.getBookingsByUser(userId);
            return ResponseEntity.ok(bookings);
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(null);
        }
    }

    @GetMapping("/guide/{guideId}")
    public ResponseEntity<List<UserGuideBookings>> findBookingByGuideId(@PathVariable int guideId) {
        try {
            List<UserGuideBookings> bookings = bookingsService.findBookingByGuideId(guideId);
            System.out.println(bookings);
            return ResponseEntity.ok(bookings);
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(null);
        }
    }
}
