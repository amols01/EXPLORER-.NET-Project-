//package com.explorer.Controllers;
//
//import com.explorer.Models.MRoles;
//import com.explorer.Models.Users;
//import com.explorer.Repositories.RoleRepository;
//import com.explorer.Repositories.UsersRepository;
//import com.explorer.Utils.JwtUtil;
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.http.ResponseEntity;
//import org.springframework.web.bind.annotation.*;
//
//import java.util.Optional;
//
//@RestController
//@RequestMapping("/api/users/register")
//public class RegistrationController {
//
//    @Autowired
//    private UsersRepository usersRepository;
//
//    @Autowired
//    private RoleRepository roleRepository;
//
//    @Autowired
//    private JwtUtil jwtUtils;
//
//    // Register a new user
//    @PostMapping("/register")
//    public ResponseEntity<?> registerUser(@RequestBody Users user) {
//        // Ensure you set the role entity based on the role ID provided
//        if (user.getRole() != null && user.getRole().getRoleId() != 0) {
//            MRoles role = roleRepository.findById(user.getRole().getRoleId())
//                .orElseThrow(() -> new RuntimeException("Role not found"));
//            user.setRole(role);
//        } else {
//            return ResponseEntity.badRequest().body("Role id not found");
//        }
//
//        // Check if a user with the same mobile number or email already exists
//        boolean emailExists = usersRepository.findByEmail(user.getEmail()).isPresent();
//        boolean phoneExists = usersRepository.findByPhoneNumber(user.getPhoneNumber()).isPresent();
//
//        if (emailExists) {
//            return ResponseEntity.status(409).body("Email is already registered");
//        }
//
//        if (phoneExists) {
//            return ResponseEntity.status(409).body("Phone number is already registered");
//        }
//
//        // Save the user to the database
//        Users savedUser = usersRepository.save(user);
//        return ResponseEntity.status(201).body(savedUser);
//    }
//}
