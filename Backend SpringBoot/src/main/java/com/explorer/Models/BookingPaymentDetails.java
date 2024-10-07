package com.explorer.Models;

import jakarta.persistence.*;

import java.math.BigDecimal;
import java.time.LocalDateTime;

@Entity
@Table(name = "bookingpaymentdetails")
public class BookingPaymentDetails {

	@Id
	@Column(length = 14)
	private String paymentId;

	@ManyToOne
	@JoinColumn(name = "booking_id")
	private UserGuideBookings booking;

	private LocalDateTime transactionDate;

	@Column(columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")
	private LocalDateTime timestamp;

	@Column(length = 100)
	private String bankTransactionCode;

	@Enumerated(EnumType.STRING)
	@Column(length = 50)
	private TransactionMode transactionMode;

	@Enumerated(EnumType.STRING)
	@Column(length = 20)
	private PaymentStatus status;

	@Column(length = 255)
	private String remarks;

	@Column(precision = 10, scale = 2) // Assuming up to 10 digits, with 2 decimal places
	private BigDecimal amount;

	// Enum types for TransactionMode and PaymentStatus
	public enum TransactionMode {
		UPI, NETBANKING, CARDS
	}

	public enum PaymentStatus {
		SUCCESS, FAILURE
	}

	public BookingPaymentDetails(String paymentId, UserGuideBookings booking, LocalDateTime transactionDate,
			LocalDateTime timestamp, String bankTransactionCode, TransactionMode transactionMode, PaymentStatus status,
			String remarks, BigDecimal amount) {
		super();
		this.paymentId = paymentId;
		this.booking = booking;
		this.transactionDate = transactionDate;
		this.timestamp = timestamp;
		this.bankTransactionCode = bankTransactionCode;
		this.transactionMode = transactionMode;
		this.status = status;
		this.remarks = remarks;
		this.amount = amount;
	}

	public BookingPaymentDetails() {

	}

	public String getPaymentId() {
		return paymentId;
	}

	public void setPaymentId(String paymentId) {
		this.paymentId = paymentId;
	}

	public UserGuideBookings getBooking() {
		return booking;
	}

	public void setBooking(UserGuideBookings booking) {
		this.booking = booking;
	}

	public LocalDateTime getTransactionDate() {
		return transactionDate;
	}

	public void setTransactionDate(LocalDateTime transactionDate) {
		this.transactionDate = transactionDate;
	}

	public LocalDateTime getTimestamp() {
		return timestamp;
	}

	public void setTimestamp(LocalDateTime timestamp) {
		this.timestamp = timestamp;
	}

	public String getBankTransactionCode() {
		return bankTransactionCode;
	}

	public void setBankTransactionCode(String bankTransactionCode) {
		this.bankTransactionCode = bankTransactionCode;
	}

	public TransactionMode getTransactionMode() {
		return transactionMode;
	}

	public void setTransactionMode(TransactionMode transactionMode) {
		this.transactionMode = transactionMode;
	}

	public PaymentStatus getStatus() {
		return status;
	}

	public void setStatus(PaymentStatus status) {
		this.status = status;
	}

		
	public String getRemarks() {
		return remarks;
	}

	public void setRemarks(String remarks) {
		this.remarks = remarks;
	}

	public BigDecimal getAmount() {
		return amount;
	}

	public void setAmount(BigDecimal amount) {
		this.amount = amount;
	}

}
