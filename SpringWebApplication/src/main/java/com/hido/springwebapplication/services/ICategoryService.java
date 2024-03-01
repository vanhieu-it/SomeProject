package com.hido.springwebapplication.services;

import com.hido.springwebapplication.models.Category;


import java.util.List;


public interface ICategoryService {
    public Category addCategory(String name) throws Exception;

    public List<Category> getCategories() throws Exception;

    public Boolean deleteCategory(int id) throws Exception;

    public Category updateCategory(int id,String name) throws Exception;

    public Category getCategory(int id)throws Exception;
}
