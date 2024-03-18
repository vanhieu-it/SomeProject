package com.example.learn_spring_boot.courses.repository;


import org.springframework.data.jpa.repository.JpaRepository;

import com.example.learn_spring_boot.courses.bean.Course;

public interface CourseRepository extends JpaRepository<Course, Long> {

}