package com.explorer.Controllers;

public class AuthResponse {
	private String jwt;
    private String role;

    public AuthResponse(String jwt, String role) {
        this.jwt = jwt;
        this.role = role;
    }

    public String getJwt() {
        return jwt;
    }

    public String getRole() {
        return role;
    }

}