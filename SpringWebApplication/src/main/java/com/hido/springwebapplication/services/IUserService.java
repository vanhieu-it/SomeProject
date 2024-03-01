package com.hido.springwebapplication.services;

import com.hido.springwebapplication.models.User;

import java.util.List;

public interface IUserService {
    public List<User> getUsers() throws Exception;

    public User addUser(User user) throws Exception;

    public User checkLogin(String username,String password) throws Exception;

}
