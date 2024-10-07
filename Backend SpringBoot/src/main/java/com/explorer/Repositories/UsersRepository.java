package com.explorer.Repositories;

import com.explorer.Models.Users;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface UsersRepository extends JpaRepository<Users, Integer> {
	Optional<Users> findByEmail(String email);

	Optional<Users> findByPhoneNumber(String phoneNumber);

}