package com.explorer.config;

import org.apache.naming.factory.BeanFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Lazy;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.config.annotation.ObjectPostProcessor;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.builders.WebSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.web.SecurityFilterChain;
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;

import com.explorer.Repositories.UsersRepository;
import com.explorer.ServiceImpl.UserDetailsServiceImpl;
import com.explorer.Utils.JwtUtil;
import com.explorer.filters.JwtAuthenticationFilter;

import jakarta.servlet.http.HttpServletResponse;

@Configuration
@EnableWebSecurity
public class SecurityConfig {

	@Autowired
	private JwtUtil jwtUtils;
	@Autowired
	@Lazy
	private UsersRepository usersRepository;

	@Autowired
	@Lazy
	private UserDetailsService userDetailsService;

	@Bean
	public PasswordEncoder passwordEncoder() {
		return new BCryptPasswordEncoder();
	}

	@Bean
	public JwtAuthenticationFilter jwtAuthenticationFilter() {
		return new JwtAuthenticationFilter(jwtUtils, userDetailsService); // Pass dependencies
	}

	@Bean
	public AuthenticationManager authenticationManager(HttpSecurity http) throws Exception {
	    AuthenticationManagerBuilder authenticationManagerBuilder = 
	        http.getSharedObject(AuthenticationManagerBuilder.class);
	    
	    authenticationManagerBuilder
	        .userDetailsService(userDetailsService)
	        .passwordEncoder(passwordEncoder());

	    return authenticationManagerBuilder.build();
	}

	@Bean
	public SecurityFilterChain securityFilterChain(HttpSecurity http) throws Exception {
	    http.csrf(csrf -> csrf.disable())
	        .authorizeHttpRequests(authorizeRequests -> authorizeRequests
	            .requestMatchers("/api/auth/**").permitAll()
	            .requestMatchers("/api/auth/register/**").permitAll()
	            .requestMatchers("/api/auth/login").permitAll()
	            .requestMatchers("/bookings/**").permitAll()
	           // .requestMatchers("/**").permitAll()
	           // .antMatchers(HttpMethod.POST, "/api/traveler/guides/**/feedback").hasRole("Traveler")
	            .requestMatchers("/admin/**").hasRole("Admin")
	            .requestMatchers("/guide/**").hasRole("Guide")
	            .requestMatchers("/api/traveler/**").hasRole("Traveler") //.permitAll()
	            .anyRequest().authenticated())
	        .sessionManagement(sessionManagement -> sessionManagement.sessionCreationPolicy(SessionCreationPolicy.STATELESS))
	        .addFilterBefore(jwtAuthenticationFilter(), UsernamePasswordAuthenticationFilter.class)
	        .exceptionHandling(exceptionHandling -> exceptionHandling
	            .accessDeniedHandler((request, response, accessDeniedException) -> response.sendError(HttpServletResponse.SC_FORBIDDEN)))
	        .httpBasic(httpBasic -> httpBasic.disable())  // Disable basic auth if not needed
	        .formLogin(formLogin -> formLogin.disable())  // Disable form login
	        .logout(logout -> logout.disable());  // Disable logout if not needed

	    return http.build();
	}

	
}