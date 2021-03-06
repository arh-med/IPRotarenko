﻿using IPRotarenko.Domain.Entities;
using IPRotarenko.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPRotarenko.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Section> Sections { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RequestCall> RequestsCall { get; set; }
        public DbSet<ReviewSite> ReviewsSite { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        //private static ApplicationContext _instance; // статическое поле 
        //public static ApplicationContext Instance // данное свойство дайт доступ к безе данный с инициализацие только один раз 
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new ApplicationContext();
        //        }

        //        return _instance;
        //    }
        //}

        public ApplicationContext() 
        {
            Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=91.227.16.123;database=h151315_rot;user id=h151315_rot;password=7S1s7S8d;Charset=utf8;");
        }
       
    }
}
