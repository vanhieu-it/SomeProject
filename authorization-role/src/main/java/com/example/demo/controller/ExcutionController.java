package com.example.demo.controller;

import com.example.demo.logger.ExecutionTime.LogExecutionDetails;
import com.example.demo.logger.ExecutionTime.LogExecutionTime;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ExcutionController {
    @LogExecutionTime
    @GetMapping("/hello")
    public String hello() {
        return "Hello, World!";
    }

    @LogExecutionTime
    @GetMapping("/greet")
    public String greet() {
        return "Greetings!";
    }

    @LogExecutionDetails
    @GetMapping("/calculate")
    public int calculate(@RequestParam int a, @RequestParam int b) {
        return a + b;
    }

    @LogExecutionDetails
    @GetMapping("/error")
    public String throwError() {
        throw new RuntimeException("Intentional error");
    }
}
