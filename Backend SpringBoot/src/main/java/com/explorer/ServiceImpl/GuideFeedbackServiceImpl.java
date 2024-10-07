package com.explorer.ServiceImpl;

import java.net.http.HttpResponse;
import java.time.LocalDateTime;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.repository.query.Param;
import org.springframework.http.HttpStatus;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import com.explorer.Models.Guide;
import com.explorer.Models.GuideFeedbacks;
import com.explorer.Models.Users;
import com.explorer.Repositories.GuideFeedbackRepository;
import com.explorer.Repositories.GuideRepository;
import com.explorer.Repositories.UserDetails;
import com.explorer.Repositories.UsersRepository;
import com.explorer.Services.GuideFeedbackService;

import jakarta.servlet.http.HttpServletResponse;
import jakarta.transaction.Transactional;


@Service
public class GuideFeedbackServiceImpl implements GuideFeedbackService {

	
	@Autowired
    private GuideFeedbackRepository guideFeedbackRepository;

    @Autowired
    private UsersRepository usersRepository;

    @Autowired
    private GuideRepository guideRepository;
    
    
    @Override
    @Transactional
    public void submitFeedback(int guideId, GuideFeedbacks feedback) {
        // Fetch the guide by ID
        Guide guide = guideRepository.findAllByGuide_GuideIdForGuideId(guideId);
        if (guide == null) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Guide not found");
        }

        // Get the current user
        Users currentUser = getCurrentUser();

        // Create a new feedback object
        GuideFeedbacks guideFeedback = new GuideFeedbacks();
        guideFeedback.setGuide(guide);
        guideFeedback.setUser(currentUser);
        guideFeedback.setGuideFeedback(feedback.getGuideFeedback());
        guideFeedback.setGuideRating(feedback.getGuideRating());
        guideFeedback.setTimestamp(LocalDateTime.now());

        // Save the feedback
        guideFeedbackRepository.save(guideFeedback);
    }


    @Override
    public Users getCurrentUser() {
        Authentication authentication = SecurityContextHolder.getContext().getAuthentication();

        // Log the authentication details for debugging
        System.out.println("Current Authentication: " + authentication);

        if (authentication != null && authentication.isAuthenticated() 
                && authentication.getPrincipal() instanceof UserDetails) {
            UserDetails userDetails = (UserDetails) authentication.getPrincipal();
            String username = userDetails.getUsername();

            // Log the username
            System.out.println("Current Username: " + username);

            // Fetch the user from the repository
            return usersRepository.findByEmail(username)
                    .orElseThrow(() -> new UsernameNotFoundException("User not found with username: " + username));
        } else {
            throw new UsernameNotFoundException("No authenticated user found");
        }
    }



}
