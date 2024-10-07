package com.explorer.Controllers;

import com.explorer.Models.Wishlist;
import com.explorer.Services.WishlistService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/wishlist")
public class WishlistController {

    @Autowired
    private WishlistService wishlistService;

    @PostMapping
    public ResponseEntity<Wishlist> addWishlist(@RequestBody Wishlist wishlist) {
        Wishlist addedWishlist = wishlistService.addWishlist(wishlist);
        return ResponseEntity.ok(addedWishlist);
    }

    @PutMapping("/{id}")
    public ResponseEntity<Wishlist> updateWishlist(@PathVariable("id") int wishlistId, @RequestBody Wishlist wishlist) {
        Wishlist updatedWishlist = wishlistService.updateWishlist(wishlistId, wishlist);
        return ResponseEntity.ok(updatedWishlist);
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteFromWishlist(@PathVariable("id") int wishlistId) {
        wishlistService.deleteFromWishlist(wishlistId);
        return ResponseEntity.noContent().build();
    }

    @GetMapping("/user/{userId}")
    public ResponseEntity<List<Wishlist>> getWishlistByUserId(@PathVariable("userId") int userId) {
        List<Wishlist> wishlist = wishlistService.getWishlistByUserId(userId);
        return ResponseEntity.ok(wishlist);
    }
}
