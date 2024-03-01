package com.hido.springwebapplication.services.impl;

import com.hido.springwebapplication.dao.impl.userDao;
import com.hido.springwebapplication.models.User;
import com.hido.springwebapplication.services.IUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class userService implements IUserService {
    @Autowired
    private userDao userDao;

    public List<User> getUsers(){
        return this.userDao.getAllUser();
    }

    public User addUser(User user) {
        return this.userDao.saveUser(user);
    }

    public User checkLogin(String username,String password) {
        return this.userDao.getUser(username, password);
    }

}
