package com.explorer.Models;

import jakarta.persistence.*;

@Entity
@Table(name = "city")
public class Cities {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int cityId;

    @Column(length = 100, nullable = false)
    private String city;

    @ManyToOne
    @JoinColumn(name = "state_id")
    private MStates state;

	public Cities(int cityId, String city, MStates state) {
		super();
		this.cityId = cityId;
		this.city = city;
		this.state = state;
	}

	public Cities() {
		
	}
	
	
	public int getCityId() {
		return cityId;
	}

	public void setCityId(int cityId) {
		this.cityId = cityId;
	}

	public String getCity() {
		return city;
	}

	public void setCity(String city) {
		this.city = city;
	}

	public MStates getState() {
		return state;
	}

	public void setState(MStates state) {
		this.state = state;
	}   
	
}

