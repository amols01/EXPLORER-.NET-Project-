package com.explorer.Models;

import jakarta.persistence.*;
import java.time.LocalDateTime;

@Entity
@Table(name = "images")
public class Images {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int imageId;

    @ManyToOne
    @JoinColumn(name = "user_id")
    private Users user;

    @Lob
    private byte[] image;


    // Constructor that takes a byte array
    public Images(byte[] imageData) {
        this.image = imageData;
    }
    @Column(columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")
    private LocalDateTime imageTimestamp;

    @Column(length = 255)
    private String imageDescription;

	public Images(int imageId, Users user, byte[] image, LocalDateTime imageTimestamp, String imageDescription) {
		super();
		this.imageId = imageId;
		this.user = user;
		this.image = image;
		this.imageTimestamp = imageTimestamp;
		this.imageDescription = imageDescription;
	}
	
	public Images() {
		
	}

	public int getImageId() {
		return imageId;
	}

	public void setImageId(int imageId) {
		this.imageId = imageId;
	}

	public Users getUser() {
		return user;
	}

	public void setUser(Users user) {
		this.user = user;
	}

	public byte[] getImage() {
		return image;
	}

	public void setImage(byte[] image) {
		this.image = image;
	}

	public LocalDateTime getImageTimestamp() {
		return imageTimestamp;
	}

	public void setImageTimestamp(LocalDateTime imageTimestamp) {
		this.imageTimestamp = imageTimestamp;
	}

	public String getImageDescription() {
		return imageDescription;
	}

	public void setImageDescription(String imageDescription) {
		this.imageDescription = imageDescription;
	}

    
	
}

