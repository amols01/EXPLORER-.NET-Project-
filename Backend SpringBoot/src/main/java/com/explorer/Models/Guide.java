package com.explorer.Models;

import java.math.BigDecimal;

import jakarta.persistence.*;

@Entity
@Table(name = "guide")
public class Guide {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int guideId;

	@ManyToOne(cascade = CascadeType.ALL)
	@JoinColumn(name = "user_id")
	private Users user;

	
	public enum BookingStatus {
		Pending, Confirmed, InProgress, Completed, Cancelled
	}
	
	@Column(length = 12, nullable = false)
	private String aadharNumber;

	@Column(length = 10)
	private String panNumber;

	@Column(length = 20, nullable = false)
	private String accountNumber;

	@Column(length = 255)
	private String address;

	@Column(nullable = true)
	private Double guideFee;

	@Column(length = 255)
	private String guideFeedback;

	@Column(length = 5)
	private Integer guideRating = 0;


	public Guide(int guideId, Double guideFee, String guideFeedback, Users user, String aadharNumber,
			String panNumber, String accountNumber, String address, Integer guideRating) {
		super();
		this.guideId = guideId;
		this.user = user;
		this.guideFee = guideFee;
		this.aadharNumber = aadharNumber;
		this.panNumber = panNumber;
		this.accountNumber = accountNumber;
		this.address = address;
		this.guideFeedback = guideFeedback;
		this.guideRating = guideRating;
	}

	public Guide() {

	}

	public int getGuideId() {
		return guideId;
	}

	public Double getGuideFee() {
		return guideFee;
	}

	public void setGuideFee(double guideFee) {
		this.guideFee = guideFee;
	}

	public String getGuideFeedback() {
		return guideFeedback;
	}

	public void setGuideFeedback(String guideFeedback) {
		this.guideFeedback = guideFeedback;
	}

	public Integer getGuideRating() {
		return guideRating;
	}

	public void setGuideRating(Integer guideRating) {
		this.guideRating = guideRating;
	}

	public void setGuideId(int guideId) {
		this.guideId = guideId;
	}

	public Users getUser() {
		return user;
	}

	public void setUser(Users user) {
		this.user = user;
	}

	public String getAadharNumber() {
		return aadharNumber;
	}

	public void setAadharNumber(String aadharNumber) {
		this.aadharNumber = aadharNumber;
	}

	public String getPanNumber() {
		return panNumber;
	}

	public void setPanNumber(String panNumber) {
		this.panNumber = panNumber;
	}

	public String getAccountNumber() {
		return accountNumber;
	}

	public void setAccountNumber(String accountNumber) {
		this.accountNumber = accountNumber;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

}