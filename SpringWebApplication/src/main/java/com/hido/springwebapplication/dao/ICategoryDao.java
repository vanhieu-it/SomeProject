package com.hido.springwebapplication.dao;

import com.hido.springwebapplication.models.Category;
import org.hibernate.Session;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

public interface ICategoryDao {

    public Category addCategory(String name) throws Exception;

    public List<Category> getCategories() throws Exception;

    public Boolean deletCategory(int id)throws Exception;

    public Category updateCategory(int id, String name)throws Exception;

}
