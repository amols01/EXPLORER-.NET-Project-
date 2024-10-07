package com.explorer.Repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.explorer.Models.MRoles;


@Repository
public interface RoleRepository extends JpaRepository<MRoles, Integer> {
    // You can define custom query methods here if needed
    MRoles findByRole(String role);
    Optional<MRoles> findById(int role);
}