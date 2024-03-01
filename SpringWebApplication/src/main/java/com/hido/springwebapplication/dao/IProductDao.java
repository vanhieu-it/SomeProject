package com.hido.springwebapplication.dao;

import com.hido.springwebapplication.models.Product;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

public interface IProductDao {
    public List<Product> getProducts() throws Exception;

    public Product addProduct(Product product) throws Exception;

    public Product getProduct(int id) throws Exception;

    public Product updateProduct(Product product) throws Exception;

    public Boolean deletProduct(int id) throws Exception;
}
