package com.explorer;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

@SpringBootApplication
@ComponentScan(basePackages = {"com.explorer", "com.explorer.Utils"})
@EnableJpaRepositories(basePackages = "com.explorer.Repositories")

public class BhatkantiSoulExplorerApplication {

	public static void main(String[] args) {
		SpringApplication.run(BhatkantiSoulExplorerApplication.class, args);
	}

}