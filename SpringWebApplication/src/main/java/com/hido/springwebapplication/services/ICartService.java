package com.hido.springwebapplication.services;


import com.hido.springwebapplication.models.Cart;

import java.util.List;

public interface ICartService {

    public Cart addCart(Cart cart) throws Exception;

    public List<Cart> getCarts() throws Exception;

    public void updateCart(Cart cart) throws Exception;

    public void deleteCart(Cart cart) throws Exception;

}
