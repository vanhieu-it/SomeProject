package com.hido.springwebapplication.controller;

import com.hido.springwebapplication.models.*;
import com.hido.springwebapplication.services.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;

import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletResponse;
import java.util.ArrayList;
import java.util.List;

@Controller
public class UserController {
    @Autowired
    private IUserService userService;

    @Autowired
    private IProductService productService;

    @GetMapping("/register")
    public String registerUser() {
        return "register";
    }

    @GetMapping("/buy")
    public String buy() {
        return "buy";
    }


    @GetMapping("/")
    public String userlogin(Model model) {

        return "userLogin";
    }

    @RequestMapping(value = "userloginvalidate", method = RequestMethod.POST)
    public ModelAndView userlogin(@RequestParam("username") String username, @RequestParam("password") String pass, Model model, HttpServletResponse res) throws Exception {

        System.out.println(pass);
        User u = this.userService.checkLogin(username, pass);
        System.out.println(u.getUsername());
        if (u.getUsername().equals(username)) {

            res.addCookie(new Cookie("username", u.getUsername()));
            ModelAndView mView = new ModelAndView("index");
            mView.addObject("user", u);
            List<Product> products = this.productService.getProducts();

            if (products.isEmpty()) {
                mView.addObject("msg", "No products are available");
            } else {
                mView.addObject("products", products);
            }
            return mView;

        } else {
            ModelAndView mView = new ModelAndView("userLogin");
            mView.addObject("msg", "Please enter correct email and password");
            return mView;
        }

    }

    @GetMapping("/user/products")
    public ModelAndView getproduct() throws Exception {

        ModelAndView mView = new ModelAndView("uproduct");

        List<Product> products = this.productService.getProducts();

        if (products.isEmpty()) {
            mView.addObject("msg", "No products are available");
        } else {
            mView.addObject("products", products);
        }

        return mView;
    }

    @RequestMapping(value = "newuserregister", method = RequestMethod.POST)
    public String newUseRegister(@ModelAttribute User user) throws Exception {

        System.out.println(user.getEmail());
        user.setRole("ROLE_NORMAL");
        this.userService.addUser(user);

        return "redirect:/";
    }
}

