package com.explorer.ServiceImpl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.RequestBody;

import com.explorer.Models.Cities;
import com.explorer.Models.Place;
import com.explorer.Models.Cities;
import com.explorer.Models.Users;
import com.explorer.Models.Wishlist;
import com.explorer.Repositories.CitiesRepository;
import com.explorer.Repositories.PlaceRepository;
import com.explorer.Repositories.UsersRepository;
import com.explorer.Repositories.WishlistRepository;
import com.explorer.Services.WishlistService;

@Service
public class WishlistServiceImpl implements WishlistService {
	@Autowired
	private WishlistRepository wishlistRepository;

	@Autowired
	private UsersRepository usersRepository;

	@Autowired
	CitiesRepository citiesRepository;
	
	@Autowired
	PlaceRepository placeRepository;

	public Wishlist updateWishlist(int wishlistId, Wishlist wishlist) {
		Wishlist existingWishlist = wishlistRepository.findById(wishlistId)
				.orElseThrow(() -> new IllegalArgumentException("Invalid wishlist ID: " + wishlistId));

		existingWishlist.setUser(wishlist.getUser());
		existingWishlist.setCity(wishlist.getCity());
		existingWishlist.setPlace(wishlist.getPlace());
		existingWishlist.setTimestamp(wishlist.getTimestamp());

		return wishlistRepository.save(existingWishlist);
	}

	public void deleteFromWishlist(int wishlistId) {
		wishlistRepository.deleteById(wishlistId);
	}

	public List<Wishlist> getWishlistByUserId(int userId) {
		return wishlistRepository.findAll().stream().filter(wishlist -> wishlist.getUser().getUserId() == userId)
				.toList();
	}


	public Wishlist addWishlist(@RequestBody Wishlist wishlist) {
        
        wishlist.setUser(usersRepository.findById(wishlist.getUser().getUserId())
            .orElseThrow(() -> new IllegalArgumentException("Invalid user ID: " + wishlist.getUser().getUserId())));
        
        wishlist.setCity(citiesRepository.findById(wishlist.getCity().getCityId())
            .orElseThrow(() -> new IllegalArgumentException("Invalid city ID: " + wishlist.getCity().getCityId())));
        
        wishlist.setPlace(placeRepository.findById(wishlist.getPlace().getPlaceId())
            .orElseThrow(() -> new IllegalArgumentException("Invalid place ID: " + wishlist.getPlace().getPlaceId())));
        
        return wishlistRepository.save(wishlist);
    }

	
}
