package com.hido.springwebapplication.services.impl;

import com.hido.springwebapplication.dao.impl.productDao;
import com.hido.springwebapplication.models.Product;
import com.hido.springwebapplication.services.IProductService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
@Service
public class productService implements IProductService {
    @Autowired
    private productDao productDao;

    public List<Product> getProducts(){
        return this.productDao.getProducts();
    }

    public Product addProduct(Product product) {
        return this.productDao.addProduct(product);
    }

    public Product getProduct(int id) {
        return this.productDao.getProduct(id);
    }

    public Product updateProduct(int id, Product product){
        product.setId(id);
        return this.productDao.updateProduct(product);
    }
    public boolean deleteProduct(int id) {
        return this.productDao.deletProduct(id);
    }
}
