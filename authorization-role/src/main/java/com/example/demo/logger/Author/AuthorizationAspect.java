package com.example.demo.logger.Author;

import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.*;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;

@Aspect
@Component
public class AuthorizationAspect {

    private static final Logger logger = LoggerFactory.getLogger(AuthorizationAspect.class);

    // Định nghĩa Pointcut cho các phương thức có annotation @RequiresAuthorization
    @Pointcut("@annotation(com.example.demo.logger.Author.RequiresAuthorization)")
    public void authorizationPointcut() {}

    // Kiểm tra quyền truy cập và log thông tin
    @Around("authorizationPointcut() && @annotation(requiresAuthorization)")
    public Object checkAuthorization(ProceedingJoinPoint joinPoint, RequiresAuthorization requiresAuthorization) throws Throwable {
        String requiredRole = requiresAuthorization.role();
        // Giả sử lấy thông tin role của người dùng hiện tại
        String currentUserRole = getCurrentUserRole();

        if (!requiredRole.equals(currentUserRole)) {
            logger.warn("Unauthorized access attempt by role: {}. Required role: {}", currentUserRole, requiredRole);
            throw new SecurityException("You do not have the required role to access this method.");
        }

        logger.info("User with role: {} is authorized to access method: {}", currentUserRole, joinPoint.getSignature());

        return joinPoint.proceed();
    }

    private String getCurrentUserRole() {
        // Giả sử role của người dùng là "ADMIN" (có thể thay đổi tùy theo ngữ cảnh thực tế)
        return "ADMIN";
    }
}
