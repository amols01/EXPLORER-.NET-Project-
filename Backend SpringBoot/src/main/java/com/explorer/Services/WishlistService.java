package com.explorer.Services;

import java.util.List;

import com.explorer.Models.Wishlist;

public interface WishlistService {

	Wishlist addWishlist(Wishlist wishlist);
    Wishlist updateWishlist(int wishlistId, Wishlist wishlist);
    void deleteFromWishlist(int wishlistId);
    List<Wishlist> getWishlistByUserId(int userId);
}
