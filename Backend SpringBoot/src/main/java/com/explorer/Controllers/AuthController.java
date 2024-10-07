package com.explorer.Controllers;

import com.explorer.Models.Guide;
import com.explorer.Models.MRoles;
import com.explorer.Models.UserRegistrationRequest;
import com.explorer.Models.Users;
import com.explorer.Repositories.GuideRepository;
import com.explorer.Repositories.RoleRepository;
import com.explorer.Repositories.UsersRepository;
import com.explorer.ServiceImpl.EmailService;
import com.explorer.Utils.JwtUtil;

import java.time.LocalDateTime;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.BadCredentialsException;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/auth")
public class AuthController {

	@Autowired
	private AuthenticationManager authenticationManager;

	@Autowired
    private EmailService emailService;
	
	@Autowired
	private UserDetailsService userDetailsService;

	@Autowired
	private GuideRepository guideRepository;
	@Autowired
	private JwtUtil jwtUtil;

	@Autowired
	private UsersRepository usersRepository;

	@Autowired
	private RoleRepository roleRepository;

	@Autowired
	private PasswordEncoder passwordEncoder;

	@PostMapping("/login")
	public ResponseEntity<?> authenticateUser(@RequestBody AuthRequest loginRequest) {
		try {
			// Authenticate user using email and password
			Authentication authentication = authenticationManager.authenticate(
					new UsernamePasswordAuthenticationToken(loginRequest.getEmail(), loginRequest.getPassword()));

			// Generate JWT token
			String jwt = jwtUtil.generateJwtToken(authentication, loginRequest.getEmail());

			// Get the user's role
			String role = authentication.getAuthorities().iterator().next().getAuthority();

			emailService.sendSimpleEmail(
					loginRequest.getEmail(),
	                "Login Notification",
	                "Dear " + loginRequest.getEmail() + ",\n\nYou have successfully logged in as a " +role+ ".\n\nBest regards,\\n\\nBhatkanti Soul-Explorer,\\nAnd Team"
	        );
			return ResponseEntity.ok(new AuthResponse(jwt, role));
		} catch (Exception e) {
			// Log and return a failure response
			e.printStackTrace();
			return ResponseEntity.status(401).body("Invalid email or password");
		}
	}

	@PostMapping("/register")
	public ResponseEntity<?> registerUser(@RequestBody Users registrationRequest) {
		// Check if the role exists
		MRoles role = roleRepository.findById(registrationRequest.getRole().getRoleId())
				.orElseThrow(() -> new RuntimeException("Role not found"));

		// Create new user
		Users user = new Users();
		user.setName(registrationRequest.getName());
		user.setEmail(registrationRequest.getEmail());
		user.setPhoneNumber(registrationRequest.getPhoneNumber());
		user.setPassword(passwordEncoder.encode(registrationRequest.getPassword()));
		user.setRole(role);
		user.setRegistrationTimestamp(registrationRequest.getRegistrationTimestamp());
		user.setAddress(registrationRequest.getAddress());

		// Check if user already exists
		if (usersRepository.findByEmail(user.getEmail()).isPresent()) {
			return ResponseEntity.status(409).body("Email is already registered");
		}

		if (usersRepository.findByPhoneNumber(user.getPhoneNumber()).isPresent()) {
			return ResponseEntity.status(409).body("Phone number is already registered");
		}

		emailService.sendSimpleEmail(
                user.getEmail(),
                "Welcome to Our Service",
                "Dear " + user.getName() + ",\n\nThank you for registering with us.\n\nBest regards,\n\nBhatkanti Soul-Explorer,\nAnd Team"
        );
		// Save user
		Users savedUser = usersRepository.save(user);
		return ResponseEntity.status(201).body(savedUser);
	}

	@PostMapping("/register/guide")
	public ResponseEntity<?> registerGuide(@RequestBody UserRegistrationRequest registrationRequest) {
		// Check if the role exists
		MRoles role = roleRepository.findById(registrationRequest.getRole())
				.orElseThrow(() -> new RuntimeException("Role not found"));

		// Create new user
		Users user = new Users();
		user.setName(registrationRequest.getName());
		user.setEmail(registrationRequest.getEmail());
		user.setPhoneNumber(registrationRequest.getPhoneNumber());
		user.setPassword(passwordEncoder.encode(registrationRequest.getPassword()));
		user.setRole(role);
		user.setRegistrationTimestamp(LocalDateTime.now());
		user.setAddress(registrationRequest.getAddress());

		// Check if user already exists
		if (usersRepository.findByEmail(user.getEmail()).isPresent()) {
			return ResponseEntity.status(409).body("Email is already registered");
		}

		if (usersRepository.findByPhoneNumber(user.getPhoneNumber()).isPresent()) {
			return ResponseEntity.status(409).body("Phone number is already registered");
		}
		// Save user
		Users savedUser = user;
		// If the role is Guide (roleId = 2), register the guide
		if (role.getRoleId() == 2) {
			// Check for required Guide fields
			if (registrationRequest.getAadharNumber() == null || registrationRequest.getAadharNumber().isEmpty()) {
				return ResponseEntity.badRequest().body("Aadhar Number is required for Guide registration");
			}
			if (registrationRequest.getPanNumber() == null || registrationRequest.getPanNumber().isEmpty()) {
				return ResponseEntity.badRequest().body("PAN Number is required for Guide registration");
			}
			if (registrationRequest.getAccountNumber() == null || registrationRequest.getAccountNumber().isEmpty()) {
				return ResponseEntity.badRequest().body("Account Number is required for Guide registration");
			}

			// Create and save Guide
			Guide guide = new Guide();
			if (guideRepository.findByAadharNumber(guide.getAadharNumber()).isPresent()) {
				return ResponseEntity.status(409).body("A Guide with this Aadhar Number already exists.");
			}
			if (guideRepository.findByPanNumber(guide.getPanNumber()).isPresent()) {
				return ResponseEntity.status(409).body("A Guide with this PAN Number already exists.");
			}
			if (guideRepository.findByAccountNumber(guide.getAccountNumber()).isPresent()) {
				return ResponseEntity.status(409).body("A Guide with this Account Number already exists.");
			}
			guide.setUser(savedUser);
			guide.setAadharNumber(registrationRequest.getAadharNumber());
			guide.setPanNumber(registrationRequest.getPanNumber());
			guide.setAccountNumber(registrationRequest.getAccountNumber());
			guide.setAddress(registrationRequest.getAddress());

			emailService.sendSimpleEmail(
	                user.getEmail(),
	                "Welcome to Our Service",
	                "Dear " + user.getName() + ",\n\nThank you for registering with us.\n\nBest regards,\n\nBhatkanti Soul-Explorer,\nAnd Team"
	        );
			
			guideRepository.save(guide);
		} else {
			usersRepository.save(user);
		}
		return ResponseEntity.status(201).body(savedUser);
	}

}
