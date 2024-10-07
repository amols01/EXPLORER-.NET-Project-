package com.explorer.Repositories;

import com.explorer.Models.Wishlist;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface WishlistRepository extends JpaRepository<Wishlist, Integer> {
    List<Wishlist> findByUserUserId(int userId);
    
    @Procedure(name = "GetWishlistByUserId")
    List<Wishlist> getWishlistByUserId(@Param("p_user_id") int userId);
}	
