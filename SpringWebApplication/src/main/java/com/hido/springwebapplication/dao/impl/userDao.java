package com.hido.springwebapplication.dao.impl;

import com.hido.springwebapplication.dao.IUserDao;
import com.hido.springwebapplication.models.User;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.query.Query;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Repository
public class userDao implements IUserDao {
    @Autowired

    private SessionFactory sessionFactory;

    public void setSessionFactory(SessionFactory sessionFactory) {
        this.sessionFactory = sessionFactory;
    }
    @Transactional
    public List<User> getAllUser() {
        Session session = this.sessionFactory.getCurrentSession();
        List<User>  userList = session.createQuery("from CUSTOMER").list();
        return userList;
    }

    @Transactional
    public User saveUser(User user) {
        this.sessionFactory.getCurrentSession().saveOrUpdate(user);
        System.out.println("User added" + user.getId());
        return user;
    }

    @Transactional
    public User getUser(String username, String password) {
        Query query = sessionFactory.getCurrentSession().createQuery("from CUSTOMER where username = :username");
        query.setParameter("username",username);

        try {
            User user = (User) query.getSingleResult();
            System.out.println(user.getPassword());
            if(password.equals(user.getPassword())) {
                return user;
            }else {
                return new User();
            }
        }catch(Exception e){
            System.out.println(e.getMessage());
            User user = new User();
            return user;
        }

    }
}
