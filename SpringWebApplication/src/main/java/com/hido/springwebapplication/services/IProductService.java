package com.hido.springwebapplication.services;

import com.hido.springwebapplication.models.Product;

import java.util.List;

public interface IProductService {
    public List<Product> getProducts()throws Exception;

    public Product addProduct(Product product) throws Exception;

    public Product getProduct(int id) throws Exception;

    public Product updateProduct(int id, Product product) throws Exception;
    public boolean deleteProduct(int id) throws Exception;
}
