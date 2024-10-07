package com.explorer.Models;

import jakarta.persistence.*;

@Entity
@Table(name = "m_states")
public class MStates {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int stateId;

    @Column(length = 100, nullable = false)
    private String state;

	public MStates(int stateId, String state) {
		super();
		this.stateId = stateId;
		this.state = state;
	}
	
	public MStates() {
		
	}

	public int getStateId() {
		return stateId;
	}

	public void setStateId(int stateId) {
		this.stateId = stateId;
	}

	public String getState() {
		return state;
	}

	public void setState(String state) {
		this.state = state;
	}

    
    
    
    
    
    
  
}

