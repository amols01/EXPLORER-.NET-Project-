package com.explorer.Controllers;

import com.explorer.Models.MRoles;
import com.explorer.Models.Users;
import com.explorer.Repositories.RoleRepository;
import com.explorer.Repositories.UsersRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatusCode;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/users")
public class UsersController {

    @Autowired
    private UsersRepository usersRepository;
    @Autowired
    private RoleRepository roleRepository;
    

    // Get all users
    @GetMapping
    public List<Users> getAllUsers() {
        return usersRepository.findAll();
    }

    // Get user by ID
    @GetMapping("/{id}")
    public ResponseEntity<Users> getUserById(@PathVariable int id) {
        Optional<Users> user = usersRepository.findById(id);
        return user.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }

    // Create a new user
//    @PostMapping
//    public ResponseEntity<Users> createUser(@RequestBody Users user) {
//        // Ensure you set the role entity based on the role ID provided
//        if (user.getRole() != null && user.getRole().getRoleId() != 0) { // Check for non-zero roleId
//            MRoles role = roleRepository.findById(user.getRole().getRoleId())
//                .orElseThrow(() -> new RuntimeException("Role not found"));
//            user.setRole(role);
//        } else {
//        	return ResponseEntity.badRequest().body(null); // Handle case where role ID is not provided
//        }
//        // Save the user to the database
//        Users savedUser = usersRepository.save(user);
//        return ResponseEntity.status(HttpStatusCode.valueOf(200)).body(savedUser);
//    }
    @PostMapping
    public ResponseEntity<?> createUser(@RequestBody Users user) {
        // Ensure you set the role entity based on the role ID provided
        if (user.getRole() != null && user.getRole().getRoleId() != 0) { // Check for non-zero roleId
            MRoles role = roleRepository.findById(user.getRole().getRoleId())
                .orElseThrow(() -> new RuntimeException("Role not found"));
            user.setRole(role);
        } else {
            return ResponseEntity.status(400).body("Role id not found"); 
        }

        // Check if a user with the same mobile number or email already exists
        boolean emailExists = usersRepository.findByEmail(user.getEmail()).isPresent();
        boolean phoneExists = usersRepository.findByPhoneNumber(user.getPhoneNumber()).isPresent();

        if (emailExists) {
            return ResponseEntity.status(409).body("Email is already registerd ");
        }

        if (phoneExists) {
            return ResponseEntity.status(409).body("Phone number is already registed ");
        }

        // Save the user to the database
        Users savedUser = usersRepository.save(user);
        return ResponseEntity.status(201).body(savedUser); // Successfully created
    }

    // Update an existing user
    @PutMapping("/{id}")
    public ResponseEntity<?> updateUser(@PathVariable int id, @RequestBody Users userDetails) {
        Optional<Users> existingUserOpt = usersRepository.findById(id);

        if (existingUserOpt.isPresent()) {
            Users existingUser = existingUserOpt.get();

            // Check if the email or phone number being updated already exists
            boolean emailExists = usersRepository.findByEmail(userDetails.getEmail())
                .filter(u -> u.getUserId() != id) // Ensure it's not the same user
                .isPresent();
            boolean phoneExists = usersRepository.findByPhoneNumber(userDetails.getPhoneNumber())
                .filter(u -> u.getUserId() != id) // Ensure it's not the same user
                .isPresent();

            if (emailExists) {
                return ResponseEntity.status(409).body("Email is already registered");
            }

            if (phoneExists) {
                return ResponseEntity.status(409).body("Phone number is already registered");
            }

            // Update user details
            existingUser.setName(userDetails.getName());
            existingUser.setEmail(userDetails.getEmail());
            existingUser.setPhoneNumber(userDetails.getPhoneNumber());
            existingUser.setPassword(userDetails.getPassword());
            existingUser.setRole(userDetails.getRole());
            existingUser.setRegistrationTimestamp(userDetails.getRegistrationTimestamp());
            existingUser.setAddress(userDetails.getAddress());

            Users updatedUser = usersRepository.save(existingUser);
            return ResponseEntity.ok(updatedUser);
        } else {
            return ResponseEntity.status(404).body("User not found");
        }
    }
    // Delete a user
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteUser(@PathVariable int id) {
        Optional<Users> user = usersRepository.findById(id);

        if (user.isPresent()) {
            usersRepository.delete(user.get());
            return ResponseEntity.ok().build();
        } else {
            return ResponseEntity.notFound().build();
        }
    }
}