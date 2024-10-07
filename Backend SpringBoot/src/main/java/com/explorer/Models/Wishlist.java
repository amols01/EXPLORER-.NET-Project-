package com.explorer.Models;

import jakarta.persistence.*;
import java.time.LocalDateTime;

@Entity
@Table(name = "wishlist")
public class Wishlist {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int wishlistId;

    @ManyToOne
    @JoinColumn(name = "user_id", referencedColumnName = "userId")
    private Users user;

    @ManyToOne
    @JoinColumn(name = "city_id", referencedColumnName = "cityId")
    private Cities city;

    @ManyToOne
    @JoinColumn(name = "place_id", referencedColumnName = "placeId")
    private Place place;

    @Column(columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")
    private LocalDateTime timestamp = LocalDateTime.now();

	
    public Wishlist(int wishlistId, Users user, Cities city, Place place, LocalDateTime timestamp) {
		super();
		this.wishlistId = wishlistId;
		this.user = user;
		this.city = city;
		this.place = place;
		this.timestamp = timestamp;
	}

   
    public Wishlist() { 
    	
    }


	public int getWishlistId() {
		return wishlistId;
	}


	public void setWishlistId(int wishlistId) {
		this.wishlistId = wishlistId;
	}


	public Users getUser() {
		return user;
	}


	public void setUser(Users user) {
		this.user = user;
	}


	public Cities getCity() {
		return city;
	}


	public void setCity(Cities city) {
		this.city = city;
	}


	public Place getPlace() {
		return place;
	}


	public void setPlace(Place place) {
		this.place = place;
	}


	public LocalDateTime getTimestamp() {
		return timestamp;
	}


	public void setTimestamp(LocalDateTime timestamp) {
		this.timestamp = timestamp;
	}
    
    
    
    
    
    
    
}

