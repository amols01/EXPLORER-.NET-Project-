//package com.explorer.Models;
//
//import jakarta.persistence.*;
//import java.time.LocalDateTime;
//import java.util.List;
//
//@Entity
//@Table(name = "guide_feedback")
//public class GuideFeedbacks {
//
//    @Id
//    @GeneratedValue(strategy = GenerationType.IDENTITY)
//    private int guideFeedbackId;
//
//    @ManyToOne
//    @JoinColumn(name = "user_id")
//    private Users user;
//
//    @ManyToOne
//    @JoinColumn(name = "guide_id")
//    private Guide guide;
//
//    @Column(nullable = false)
//    private String guideFeedback;
//
//    
//    private int guideRating;
//
//    @Column(columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")
//    private LocalDateTime timestamp;
//
//	public GuideFeedbacks(int guideFeedbackId, Users user, Guide guide, String guideFeedback, int guideRating,
//			LocalDateTime timestamp) {
//		super();
//		this.guideFeedbackId = guideFeedbackId;
//		this.user = user;
//		this.guide = guide;
//		this.guideFeedback = guideFeedback;
//		this.guideRating = guideRating;
//		this.timestamp = timestamp;
//	}
//	
//	public GuideFeedbacks() {
//		
//	}
//
//	public int getGuideFeedbackId() {
//		return guideFeedbackId;
//	}
//
//	public void setGuideFeedbackId(int guideFeedbackId) {
//		this.guideFeedbackId = guideFeedbackId;
//	}
//
//	public Users getUser() {
//		return user;
//	}
//
//	public void setUser(Users user) {
//		this.user = user;
//	}
//
//	public Guide getGuide() {
//		return guide;
//	}
//
//	public void setGuide(List<Guide> guide2) {
//		this.guide = (Guide) guide2;
//	}
//
//	public String getGuideFeedback() {
//		return guideFeedback;
//	}
//
//	public void setGuideFeedback(String guideFeedback) {
//		this.guideFeedback = guideFeedback;
//	}
//
//	public int getGuideRating() {
//		return guideRating;
//	}
//
//	public void setGuideRating(int guideRating) {
//		this.guideRating = guideRating;
//	}
//
//	public LocalDateTime getTimestamp() {
//		return timestamp;
//	}
//
//	public void setTimestamp(LocalDateTime timestamp) {
//		this.timestamp = timestamp;
//	}
//
//    
//	
//}

package com.explorer.Models;

import jakarta.persistence.*;
import java.time.LocalDateTime;

@Entity
@Table(name = "guide_feedback")
public class GuideFeedbacks {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int guideFeedbackId;

    @ManyToOne
    @JoinColumn(name = "user_id", nullable = false)
    private Users user;

    @ManyToOne
    @JoinColumn(name = "guide_id", nullable = false)
    private Guide guide;

    @Column(nullable = false)
    private String guideFeedback;

    @Column(nullable = false)
    private int guideRating;

    @Column(columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP", updatable = true)
    private LocalDateTime timestamp;

    public GuideFeedbacks(int guideFeedbackId, Users user, Guide guide, String guideFeedback, int guideRating, LocalDateTime timestamp) {
        this.guideFeedbackId = guideFeedbackId;
        this.user = user;
        this.guide = guide;
        this.guideFeedback = guideFeedback;
        this.guideRating = guideRating;
        this.timestamp = timestamp;
    }

    public GuideFeedbacks() {
    }

    public int getGuideFeedbackId() {
        return guideFeedbackId;
    }

    public void setGuideFeedbackId(int guideFeedbackId) {
        this.guideFeedbackId = guideFeedbackId;
    }

    public Users getUser() {
        return user;
    }

    public void setUser(Users user) {
        this.user = user;
    }

    public Guide getGuide() {
        return guide;
    }

    public void setGuide(Guide guide) {
        this.guide = guide;
    }

    public String getGuideFeedback() {
        return guideFeedback;
    }

    public void setGuideFeedback(String guideFeedback) {
        this.guideFeedback = guideFeedback;
    }

    public int getGuideRating() {
        return guideRating;
    }

    public void setGuideRating(int guideRating) {
        this.guideRating = guideRating;
    }

    public LocalDateTime getTimestamp() {
        return timestamp;
    }

    public void setTimestamp(LocalDateTime timestamp) {
        this.timestamp = timestamp;
    }
}

