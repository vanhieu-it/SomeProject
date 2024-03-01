package com.hido.springwebapplication.dao.impl;

import com.hido.springwebapplication.dao.IProductDao;
import com.hido.springwebapplication.models.Product;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Repository
public class productDao implements IProductDao {
    @Autowired
    private SessionFactory sessionFactory;

    public void setSessionFactory(SessionFactory sf) {
        this.sessionFactory = sf;
    }

    @Transactional
    public List<Product> getProducts() {
        return this.sessionFactory.getCurrentSession().createQuery("from PRODUCT").list();
    }

    @Transactional
    public Product addProduct(Product product) {
        this.sessionFactory.getCurrentSession().save(product);
        return product;
    }

    @Transactional
    public Product getProduct(int id) {
        return this.sessionFactory.getCurrentSession().get(Product.class, id);
    }

    public Product updateProduct(Product product) {
        this.sessionFactory.getCurrentSession().update(String.valueOf(Product.class), product);
        return product;
    }

    @Transactional
    public Boolean deletProduct(int id) {

        Session session = this.sessionFactory.getCurrentSession();
        Object persistanceInstance = session.load(Product.class, id);

        if (persistanceInstance != null) {
            session.delete(persistanceInstance);
            return true;
        }
        return false;
    }
}
