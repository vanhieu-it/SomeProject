package com.example.demo.controller;

import com.example.demo.logger.Author.RequiresAuthorization;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class AuthorizationController {
    @RequiresAuthorization(role = "ADMIN")
    @GetMapping("/admin")
    public String adminAccess() {
        return "Welcome, Admin!";
    }

    @RequiresAuthorization(role = "USER")
    @GetMapping("/user")
    public String userAccess() {
        return "Welcome, User!";
    }
}
