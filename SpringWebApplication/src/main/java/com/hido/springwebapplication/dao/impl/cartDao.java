package com.hido.springwebapplication.dao.impl;

import com.hido.springwebapplication.dao.ICartDao;
import com.hido.springwebapplication.models.Cart;
import org.hibernate.SessionFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
@Repository
public class cartDao implements ICartDao {
    @Autowired
    private SessionFactory sessionFactory;

    public void setSessionFactory(SessionFactory sf){ this.sessionFactory =sf;}

    @Transactional
    public Cart addCart(Cart cart) {
        this.sessionFactory.getCurrentSession().save(cart);
        return cart;
    }

    @Transactional
    public List<Cart> getCarts() {
        return this.sessionFactory.getCurrentSession().createQuery("from CART").list();
    }

    @Transactional
    public void updateCart(Cart cart) {
        this.sessionFactory.getCurrentSession().update(cart);
    }

    @Transactional
    public void deleteCart(Cart cart) {
        this.sessionFactory.getCurrentSession().delete(cart);
    }
}
