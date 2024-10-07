package com.explorer.ServiceImpl;


import com.explorer.Models.Users;
import com.explorer.Repositories.UsersRepository;
import com.explorer.Services.UsersService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class UsersServiceImpl implements UsersService {

    @Autowired
    private UsersRepository usersRepository;

    @Autowired
    private PasswordEncoder passwordEncoder;

    @Override
    public List<Users> getAllUsers() {
        return usersRepository.findAll();
    }

    @Override
    public Optional<Users> getUserById(int id) {
        return usersRepository.findById(id);
    }

    public void saveUser(Users user) {
        // Encode the password before saving the user
        user.setPassword(passwordEncoder.encode(user.getPassword()));
        usersRepository.save(user);
    }
    @Override
    public Users createUser(Users user) {
    	user.setPassword(passwordEncoder.encode(user.getPassword()));
    	return usersRepository.save(user);
        
    }

    @Override
    public Optional<Users> updateUser(int id, Users userDetails) {
        Optional<Users> user = usersRepository.findById(id);

        if (user.isPresent()) {
            Users existingUser = user.get();
            existingUser.setName(userDetails.getName());
            existingUser.setEmail(userDetails.getEmail());
            existingUser.setPhoneNumber(userDetails.getPhoneNumber());
            existingUser.setPassword(userDetails.getPassword());
            existingUser.setRole(userDetails.getRole());
            existingUser.setRegistrationTimestamp(userDetails.getRegistrationTimestamp());
            existingUser.setAddress(userDetails.getAddress());

            Users updatedUser = usersRepository.save(existingUser);
            return Optional.of(updatedUser);
        } else {
            return Optional.empty();
        }
    }

    @Override
    public boolean deleteUser(int id) {
        Optional<Users> user = usersRepository.findById(id);

        if (user.isPresent()) {
            usersRepository.delete(user.get());
            return true;
        } else {
            return false;
        }
    }

    @Override
    public Optional<Optional<Users>> getUserByEmail(String email) {
        return Optional.ofNullable(usersRepository.findByEmail(email));
    }
}

