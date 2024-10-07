package com.explorer.Services;

import com.explorer.Models.Users;
import java.util.List;
import java.util.Optional;

public interface UsersService {

	List<Users> getAllUsers();

	Optional<Users> getUserById(int id);

	Users createUser(Users user);

	Optional<Users> updateUser(int id, Users userDetails);

	public void saveUser(Users user);
 	
	boolean deleteUser(int id);

	Optional<Optional<Users>> getUserByEmail(String email);
}