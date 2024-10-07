//package com.explorer.Utils;
//
//import io.jsonwebtoken.Claims;
//import io.jsonwebtoken.Jwts;
//import io.jsonwebtoken.SignatureAlgorithm;
//import org.springframework.beans.factory.annotation.Value;
//import org.springframework.security.core.Authentication;
//import org.springframework.security.core.userdetails.UserDetails;
//import org.springframework.stereotype.Component;
//
//import java.util.Date;
//
//import javax.crypto.SecretKey;
//
//@Component
//public class JwtUtil {
//
//    @Value("${jwt.secret}")
//    private String jwtSecret;
//
//    @Value("${jwt.expiration}")
//    private int jwtExpiration;
//
//    public String generateJwtToken(Authentication authentication) {
//        return Jwts.builder()
//                .setSubject(authentication.getName())
//                .setIssuedAt(new Date())
//                .setExpiration(new Date((new Date()).getTime() + jwtExpiration))
//                .signWith(SignatureAlgorithm.HS512, jwtSecret)
//                .compact();
//    }
//
//    public String generateToken(UserDetails userDetails) {
//        return Jwts.builder()
//                .setSubject(userDetails.getUsername())
//                .setIssuedAt(new Date())
//                .setExpiration(new Date(System.currentTimeMillis() + 1000 * 60 * 60 * 10)) // 10 hours
//                .signWith(SignatureAlgorithm.HS256, jwtSecret)
//                .compact();
//    }
//
//    public String extractUsername(String token) {
//        return Jwts.parser()
//                .setSigningKey(jwtSecret)
//                .parseClaimsJws(token)
//                .getBody()
//                .getSubject();
//    }
//
//    public String getUserNameFromJwtToken(String token) {
//        Claims claims = Jwts.parser()
//                .setSigningKey(jwtSecret)
//                .parseClaimsJws(token)
//                .getBody();
//        return claims.getSubject();
//    }
//    public boolean validateToken(String token, UserDetails userDetails) {
//        final String username = extractUsername(token);
//        return (username.equals(userDetails.getUsername()) && !isTokenExpired(token));
//    }
//     
//    private boolean isTokenExpired(String token) {
//        return Jwts.parser()
//            .setSigningKey(jwtSecret)
//            .parseClaimsJws(token)
//            .getBody()
//            .getExpiration()
//            .before(new Date());
//    }
//    public boolean validateJwtToken(String authToken) {
//        try {
//            Jwts.parser().setSigningKey(jwtSecret).parseClaimsJws(authToken);
//            return true;
//        } catch (Exception e) {
//            e.printStackTrace();
//           // logger.error("Invalid JWT Token: {}", e.getMessage());
//            return false;
//        }
//    }
//}


package com.explorer.Utils;

import io.jsonwebtoken.Claims;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Component;

import java.util.Date;
import java.util.List;
import java.util.stream.Collectors;

@Component
public class JwtUtil {

    @Value("${jwt.secret}")
    private String jwtSecret;

    @Value("${jwt.expiration}")
    private int jwtExpiration;

    // Generates JWT Token based on Authentication and includes the email in the claims
    public String generateJwtToken(Authentication authentication, String email/*,List<String> roles*/) {
        return Jwts.builder()
                .setSubject(authentication.getName())
                .claim("email", email) 
               // .claim("roles", roles.stream().map(role -> "ROLE_" + role).collect(Collectors.toList()))
                .setIssuedAt(new Date())
                .setExpiration(new Date((new Date()).getTime() + jwtExpiration))
                .signWith(SignatureAlgorithm.HS512, jwtSecret)
                .compact();
    }

    // Generates JWT Token based on UserDetails and includes the email in the claims
    public String generateToken(UserDetails userDetails, String email) {
        return Jwts.builder()
                .setSubject(userDetails.getUsername())
                .claim("email", email)  // Add email to claims
                .setIssuedAt(new Date())
                .setExpiration(new Date(System.currentTimeMillis() + jwtExpiration))
                .signWith(SignatureAlgorithm.HS512, jwtSecret)
                .compact();
    }

    public String extractRole(String token) {
        // Create the parser using the old method
        Claims claims = Jwts.parser()
            .setSigningKey(jwtSecret)
            .parseClaimsJws(token)
            .getBody();
        String role = claims.get("role", String.class);
        System.out.println("Extracted Role: " + role);
        return role != null ? role : "";
    }



    // Extracts the username (subject) from the JWT Token
    public String extractUsername(String token) {
        return Jwts.parser()
                .setSigningKey(jwtSecret)
                .parseClaimsJws(token)
                .getBody()
                .getSubject();
    }

    // Extracts the email from the JWT Token
    public String extractEmail(String token) {
        Claims claims = Jwts.parser()
                .setSigningKey(jwtSecret)
                .parseClaimsJws(token)
                .getBody();
        return claims.get("email", String.class);  // Extract email from claims
    }

    // Validates the JWT Token with the provided UserDetails
    public boolean validateToken(String token, UserDetails userDetails) {
        final String username = extractUsername(token);
        return (username.equals(userDetails.getUsername()) && !isTokenExpired(token));
    }

    // Checks if the JWT Token is expired
    private boolean isTokenExpired(String token) {
        return Jwts.parser()
            .setSigningKey(jwtSecret)
            .parseClaimsJws(token)
            .getBody()
            .getExpiration()
            .before(new Date());
    }

    // Validates the JWT Token without needing UserDetails (for basic token validation)
    public boolean validateJwtToken(String authToken) {
        try {
            Jwts.parser().setSigningKey(jwtSecret).parseClaimsJws(authToken);
            return true;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
    }
}
