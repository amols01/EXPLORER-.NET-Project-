package com.explorer.Models;

import jakarta.persistence.*;
import java.time.LocalDateTime;

@Entity
@Table(name = "users")
public class Users {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int userId;

	@Column(length = 100, nullable = false)
	private String name;

	@Column(length = 255, nullable = false,unique = true)
	private String email;

	@Column(length = 20,unique = true,nullable = false)
	private String phoneNumber;

	@Column(length = 100, nullable = false)
	private String password;

	@ManyToOne
	@JoinColumn(name = "role_id")
	private MRoles role;

	@Column(columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")
	private LocalDateTime registrationTimestamp;

	@Column(length = 255, nullable = true)
	private String address;

	public Users(int userId, String name, String email, String phoneNumber, String password, MRoles role,
			LocalDateTime registrationTimestamp, String address) {
		super();
		this.userId = userId;
		this.name = name;
		this.email = email;
		this.phoneNumber = phoneNumber;
		this.password = password;
		this.role = role;
		this.registrationTimestamp = registrationTimestamp;
		this.address = address;
	}

	public Users() {

	}

	public int getUserId() {
		return userId;
	}

	public void setUserId(int userId) {
		this.userId = userId;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getPhoneNumber() {
		return phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public MRoles getRole() {
		return role;
	}

	public void setRole(MRoles role) {
		this.role = role;
	}

	public LocalDateTime getRegistrationTimestamp() {
		return registrationTimestamp;
	}

	public void setRegistrationTimestamp(LocalDateTime registrationTimestamp) {
		this.registrationTimestamp = registrationTimestamp;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

}
