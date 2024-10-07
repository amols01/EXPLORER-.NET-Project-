package com.explorer.Repositories;

import java.util.List;

import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UsernameNotFoundException;

import com.explorer.Models.Users;

import jakarta.transaction.Transactional;

public interface UserDetailsService {

	@Transactional
	@Procedure(procedureName = "loadUserByUsername")
    List<Users> loadUserByUsername(@Param("username") String username);

}