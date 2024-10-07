package com.explorer.Services;

import com.explorer.Models.GuideFeedbacks;
import com.explorer.Models.Users;

public interface GuideFeedbackService {
	public void submitFeedback(int guideId, GuideFeedbacks feedback);
	public Users getCurrentUser();
}
