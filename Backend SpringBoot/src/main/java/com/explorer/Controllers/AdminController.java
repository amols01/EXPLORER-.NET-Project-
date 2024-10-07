package com.explorer.Controllers;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.kafka.KafkaProperties.Admin;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import com.explorer.Models.BookingPaymentDetails;
import com.explorer.Models.BookingPlaceGuide;
import com.explorer.Models.Cities;
import com.explorer.Models.Guide;
import com.explorer.Models.GuideFeedbacks;
import com.explorer.Models.Place;
import com.explorer.Models.PlaceImages;
import com.explorer.Models.Users;
import com.explorer.Repositories.CitiesRepository;
import com.explorer.Services.AdminService;
import com.explorer.Services.CitiesService;
import com.explorer.Services.GuideService;
import com.explorer.Services.PlaceService;

import jakarta.annotation.security.RolesAllowed;

@RestController
@RequestMapping("/admin")
@PreAuthorize("hasRole('Admin')")
public class AdminController {

	@Autowired
    private CitiesService citiesService;
	
	@Autowired
	private GuideService guideService;

	
	@Autowired
	private AdminService adminService;

	@Autowired
	private PlaceService placeService;

	
	@GetMapping("/guide/{guideId}")
	public ResponseEntity<Guide> getGuideById(@PathVariable int guideId) {
		Guide guide = guideService.viewGuideById(guideId);
		if (guide != null) {
			return ResponseEntity.ok(guide);
		} else {
			return ResponseEntity.notFound().build();
		}
	}
	
	@GetMapping("/places")
	public List<Place> getAllPlaces() {
		return placeService.getAllPlaces();
	}

	@GetMapping("/places/{id}")
	public ResponseEntity<Place> getPlaceById(@PathVariable("id") int placeId) {
		Optional<Place> place = placeService.getPlaceById(placeId);
		return place.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
	}

//    @PostMapping("/places/add")
//    public Place addPlace(@RequestParam("image") String image,
//                          @RequestParam("placeName") String placeName,
//                          @RequestParam("cityId") int cityId,
//                          @RequestParam("address") String address,
//                          @RequestParam("description") String description,
//                          @RequestParam("nearestPS") String nearestPS) {
//        return placeService.addPlace(image, placeName, cityId, address, description, nearestPS);
//    }

//    @PostMapping("/places/add")
//    public Place addPlace(@RequestBody PlaceDTO placeDTO) {
//        return placeService.addPlace(placeDTO.getImage(), placeDTO.getPlaceName(), placeDTO.getCityId(), placeDTO.getAddress(), placeDTO.getDescription(), placeDTO.getNearestPS());
//    }
	@PostMapping("/places/add")
	public Place addPlace(@RequestBody Place place) {
		return placeService.addPlace(place);
	}

	

    @GetMapping("/city")
    public List<Cities> getAllCities() {
        return citiesService.getAllCities();
    }

    @GetMapping("/city/{id}")
    public ResponseEntity<Cities> getCityById(@PathVariable int id) {
        Optional<Cities> city = citiesService.getCityById(id);
        return city.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PostMapping("/city/add")
    public Cities addCity(@RequestBody Cities city) {
        return citiesService.addCity(city);
    }

    @PutMapping("/city/update/{id}")
    public ResponseEntity<Cities> updateCity(@PathVariable int id, @RequestBody Cities city) {
        try {
            return ResponseEntity.ok(citiesService.updateCity(id, city));
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @DeleteMapping("/city/delete/{id}")
    public ResponseEntity<Void> deleteCity(@PathVariable int id) {
        try {
            citiesService.deleteCity(id);
            return ResponseEntity.noContent().build();
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }
	
	@PutMapping("/places/{id}")
	public ResponseEntity<Place> updatePlace(@PathVariable("id") int placeId, @RequestBody Place place) {
	    // Set the placeId
	    place.setPlaceId(placeId);

	    // Update place
	    Place updatedPlace = placeService.updatePlace(place);
	    return ResponseEntity.ok(updatedPlace);
	}


	@DeleteMapping("/places/{id}")
	public ResponseEntity<Void> deletePlace(@PathVariable("id") int placeId) {
		placeService.deletePlace(placeId);
		return ResponseEntity.noContent().build();
	}

	@GetMapping("/users")
	public List<Users> getAllUsers() {
		System.out.println("Hello");
		return adminService.findAllUsers();
	}

	@GetMapping("/guides")
	public List<Users> getAllGuides() {
		return adminService.findAllGuides();
	}

	@RolesAllowed("Admin")
	@GetMapping("/admins")
	public List<Users> getAllAdmins() {
		System.out.println(adminService.findAllAdmins());
		return adminService.findAllAdmins();
	}
//    @PutMapping("/feedback/{feedbackId}")
//    public GuideFeedbacks editFeedback(@PathVariable Long feedbackId, @RequestBody GuideFeedbacks feedbackDetails) {
//        return adminService.updateFeedback(feedbackId, feedbackDetails);
//    }

//    @DeleteMapping("/feedback/{feedbackId}")
//    public void deleteFeedback(@PathVariable int feedbackId) {
//        adminService.deleteFeedback(feedbackId);
//    }

//    @PutMapping("/guide/verify/{guideId}")
//    public Guide verifyGuide(@PathVariable Long guideId) {
//        return adminService.verifyGuide(guideId);
//    }

//    @PutMapping("/guide/approve-booking/{bookingId}")
//    public Users approveGuideBooking(@PathVariable int bookingId) {
//        return adminService.approveGuideBooking(bookingId);
//    }

	@GetMapping("/bookings")
	public List<BookingPlaceGuide> getAllBookings() {
		return adminService.findAllBookings();
	}

	@PutMapping("/location/{locationId}")
	public Place editLocation(@PathVariable int locationId, @RequestBody Place locationDetails) {
		return adminService.updateLocation(locationId, locationDetails);
	}

	@DeleteMapping("/location/{locationId}")
	public void deleteLocation(@PathVariable int locationId) {
		adminService.deleteLocation(locationId);
	}

	@PostMapping("/location/{locationId}/add-image")
	public PlaceImages addImageToLocation(@PathVariable int locationId, @RequestParam("image") MultipartFile image) {
		return adminService.addImageToLocation(locationId, image);
	}
}
