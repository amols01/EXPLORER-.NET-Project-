package com.explorer.Models;

import java.util.Optional;

import com.explorer.Utils.CustomRoleDeserializer;
import com.fasterxml.jackson.databind.annotation.JsonDeserialize;

import jakarta.persistence.*;

@Entity
@Table(name = "m_roles")
@JsonDeserialize(using = CustomRoleDeserializer.class)
public class MRoles {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int roleId;

	@Column(length = 50, nullable = false)
	private String role;

	public MRoles(int roleId, String role) {
		super();
		this.roleId = roleId;
		this.role = role;
	}

	public MRoles() {

	}

	public int getRoleId() {
		return roleId;
	}

	public void setRoleId(int roleId) {
		this.roleId = roleId;
	}

	public String getRole() {
		return role;
	}

	public void setRole(String role) {
		this.role = role;
	}
}
