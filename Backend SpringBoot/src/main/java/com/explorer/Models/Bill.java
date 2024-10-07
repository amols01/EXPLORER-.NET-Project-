package com.explorer.Models;

import jakarta.persistence.*;
import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.List;

@Entity
@Table(name = "bill")
public class Bill {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int billId;

    private BigDecimal totalGuideFee;
    private BigDecimal gst;
    private BigDecimal platformFee;
    private BigDecimal totalBillAmount;

    @Column(columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")
    private LocalDateTime timestamp;

    @OneToMany(mappedBy = "bill", cascade = CascadeType.ALL)
    private List<UserGuideBookings> bookings;

	public Bill(int billId, BigDecimal totalGuideFee, BigDecimal gst, BigDecimal platformFee,
			BigDecimal totalBillAmount, LocalDateTime timestamp, List<UserGuideBookings> bookings) {
		super();
		this.billId = billId;
		this.totalGuideFee = totalGuideFee;
		this.gst = gst;
		this.platformFee = platformFee;
		this.totalBillAmount = totalBillAmount;
		this.timestamp = timestamp;
		this.bookings = bookings;
	}
	
	public Bill() {
		
	}

	public int getBillId() {
		return billId;
	}

	public void setBillId(int billId) {
		this.billId = billId;
	}

	public BigDecimal getTotalGuideFee() {
		return totalGuideFee;
	}

	public void setTotalGuideFee(BigDecimal totalGuideFee) {
		this.totalGuideFee = totalGuideFee;
	}

	public BigDecimal getGst() {
		return gst;
	}

	public void setGst(BigDecimal gst) {
		this.gst = gst;
	}

	public BigDecimal getPlatformFee() {
		return platformFee;
	}

	public void setPlatformFee(BigDecimal platformFee) {
		this.platformFee = platformFee;
	}

	public BigDecimal getTotalBillAmount() {
		return totalBillAmount;
	}

	public void setTotalBillAmount(BigDecimal totalBillAmount) {
		this.totalBillAmount = totalBillAmount;
	}

	public LocalDateTime getTimestamp() {
		return timestamp;
	}

	public void setTimestamp(LocalDateTime timestamp) {
		this.timestamp = timestamp;
	}

	public List<UserGuideBookings> getBookings() {
		return bookings;
	}

	public void setBookings(List<UserGuideBookings> bookings) {
		this.bookings = bookings;
	}

    
	
}

