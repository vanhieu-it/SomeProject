package com.hido.springwebapplication.services.impl;

import com.hido.springwebapplication.dao.impl.cartDao;
import com.hido.springwebapplication.models.Cart;
import com.hido.springwebapplication.services.ICartService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
@Service
public class cartService implements ICartService {
    @Autowired
    private cartDao cartDao;

    public Cart addCart(Cart cart) {
        return cartDao.addCart(cart);
    }

    public List<Cart> getCarts() {
        return this.cartDao.getCarts();
    }

    public void updateCart(Cart cart) {
        cartDao.updateCart(cart);
    }

    public void deleteCart(Cart cart) {
        cartDao.deleteCart(cart);
    }

}
