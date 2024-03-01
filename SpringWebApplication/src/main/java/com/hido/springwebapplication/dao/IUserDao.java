package com.hido.springwebapplication.dao;

import com.hido.springwebapplication.models.User;
import org.hibernate.Session;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

public interface IUserDao {
    public List<User> getAllUser() throws Exception;

    public User saveUser(User user)throws Exception;

    public User getUser(String username, String password) throws Exception;
}
