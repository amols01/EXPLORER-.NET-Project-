package com.explorer.Repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.explorer.Models.Bill;

public interface BillRepository extends JpaRepository<Bill, Integer>{

}
