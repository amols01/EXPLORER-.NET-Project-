package com.explorer.Models;

import jakarta.persistence.*;
import java.time.LocalDateTime;

@Entity
@Table(name = "help")
public class Help {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int helpId;

    @ManyToOne
    @JoinColumn(name = "user_id")
    private Users user;

    @Column(length = 255)
    private String email;

    @Column(length = 20)
    private String phoneNumber;

    private String query;
    private String answer;

    @Column(columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")
    private LocalDateTime timestamp;

	public Help(int helpId, Users user, String email, String phoneNumber, String query, String answer,
			LocalDateTime timestamp) {
		super();
		this.helpId = helpId;
		this.user = user;
		this.email = email;
		this.phoneNumber = phoneNumber;
		this.query = query;
		this.answer = answer;
		this.timestamp = timestamp;
	}
	
	
	public Help() {
		
	}

	public int getHelpId() {
		return helpId;
	}

	public void setHelpId(int helpId) {
		this.helpId = helpId;
	}

	public Users getUser() {
		return user;
	}

	public void setUser(Users user) {
		this.user = user;
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

	public String getQuery() {
		return query;
	}

	public void setQuery(String query) {
		this.query = query;
	}

	public String getAnswer() {
		return answer;
	}

	public void setAnswer(String answer) {
		this.answer = answer;
	}

	public LocalDateTime getTimestamp() {
		return timestamp;
	}

	public void setTimestamp(LocalDateTime timestamp) {
		this.timestamp = timestamp;
	}

    
	
}    
    
    
    
    
