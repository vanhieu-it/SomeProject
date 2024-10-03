package com.example.demo.logger.ExecutionTime;
import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.*;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;


@Aspect
@Component
public class LoggingAspect {
    private static final Logger logger = LoggerFactory.getLogger(LoggingAspect.class);

    // Định nghĩa pointcut cho các phương thức có annotation @LogExecutionTime
    @Pointcut("@annotation(com.example.demo.logger.ExecutionTime.LogExecutionTime)")
    public void logExecutionTimePointcut() {}

    // Định nghĩa advice sẽ được thực thi trước khi phương thức chạy
    @Before("logExecutionTimePointcut()")
    public void logBefore(JoinPoint joinPoint) {
        logger.info("Starting method: " + joinPoint.getSignature().getName());
    }

    // Định nghĩa advice sẽ được thực thi sau khi phương thức hoàn thành mà không ném ra ngoại lệ
    @AfterReturning("logExecutionTimePointcut()")
    public void logAfter(JoinPoint joinPoint) {
        logger.info("Completed method: " + joinPoint.getSignature().getName());
    }

    // Định nghĩa Pointcut cho các phương thức có annotation @LogExecutionDetails
    @Pointcut("@annotation(com.example.demo.logger.ExecutionTime.LogExecutionDetails)")
    public void logExecutionDetailsPointcut() {}

    // Ghi lại thời gian thực thi của phương thức
    @Around("logExecutionDetailsPointcut()")
    public Object logExecutionTime(ProceedingJoinPoint joinPoint) throws Throwable {
        long start = System.currentTimeMillis();

        Object result = joinPoint.proceed();

        long elapsedTime = System.currentTimeMillis() - start;
        logger.info("Method {} executed in {} ms", joinPoint.getSignature(), elapsedTime);

        return result;
    }

    // Ghi lại các tham số đầu vào của phương thức
    @Before("logExecutionDetailsPointcut()")
    public void logMethodParameters(JoinPoint joinPoint) {
        Object[] args = joinPoint.getArgs();
        logger.info("Method {} called with parameters: {}", joinPoint.getSignature(), args);
    }

    // Ghi lại thông tin khi một ngoại lệ bị ném ra bởi phương thức
    @AfterThrowing(value = "logExecutionDetailsPointcut()", throwing = "ex")
    public void logAfterThrowing(JoinPoint joinPoint, Throwable ex) {
        logger.error("Exception in method: {} with message: {}", joinPoint.getSignature(), ex.getMessage());
    }
}
