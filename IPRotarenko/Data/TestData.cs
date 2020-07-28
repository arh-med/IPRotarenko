using IPRotarenko.Domain.Entities;
using IPRotarenko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Data
{
    public class TestData
    {
        public static List<Employee> Employees { get; } = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                SurName = "Иванов",
                FirstName = "Иван",
                Patronymic = "Иванович",
                Age = 39
            },
            new Employee
            {
                Id = 2,
                SurName = "Петров",
                FirstName = "Пётр",
                Patronymic = "Петрович",
                Age = 18
            },
            new Employee
            {
                Id = 3,
                SurName = "Сидоров",
                FirstName = "Сидор",
                Patronymic = "Сидорович",
                Age = 27
            },
        };



        public static IEnumerable<Section> Sections { get; } = new[]
       {
               new Section { Id = 1, Name = "Мясо", Order = 0 },
               new Section { Id = 2, Name = "Свинина ", Order = 0, ParentId = 1 },
               new Section { Id = 3, Name = "Телятина ", Order = 1, ParentId = 1 },
               new Section { Id = 4, Name = "Говядина ", Order = 2, ParentId = 1 },
               new Section { Id = 5, Name = "Баранина ", Order = 3, ParentId = 1 },
               new Section { Id = 6, Name = "Птица", Order = 1 },
               new Section { Id = 7, Name = "Курица", Order = 0, ParentId = 6 },
               new Section { Id = 8, Name = "Индейка", Order = 1, ParentId = 6 },
               new Section { Id = 9, Name = "Утка", Order = 2, ParentId = 6 },
               new Section { Id = 10, Name = "Перепелка", Order = 3, ParentId = 6 },
               new Section { Id = 11, Name = "Кулинария и шашлык", Order = 2 },
               new Section { Id = 12, Name = "Кулинария", Order = 0, ParentId = 11 },
               new Section { Id = 13, Name = "Шашлык", Order = 1, ParentId = 11 },
               new Section { Id = 14, Name = "Колбаски", Order = 2, ParentId = 11 },
               new Section { Id = 15, Name = "Котлеты", Order = 3, ParentId = 11 },
               new Section { Id = 16, Name = "Специи и соусы", Order = 3 },
               new Section { Id = 17, Name = "Все для отдыха", Order = 4 },
               new Section { Id = 18, Name = "Разное", Order = 5 },
         };

        public static IEnumerable<Product> Products { get; } = new[]
        {
             new Product { Id = 1, Name = "Куриная грудка", Price = 295, ImageUrl = "G01.jpg", Order = 0, SectionId = 7},
             new Product { Id = 2, Name = "Бедро свиное", Price = 345, ImageUrl = "G01.jpg", Order = 1, SectionId = 2,},
             new Product { Id = 3, Name = "Шейка свиная", Price = 485, ImageUrl = "G01.jpg", Order = 2, SectionId = 2},
             new Product { Id = 4, Name = "Крылышки куриные", Price = 325, ImageUrl = "G01.jpg", Order = 3, SectionId = 7},
             new Product { Id = 5, Name = "Грудка Индейки", Price = 385, ImageUrl = "G01.jpg", Order = 4, SectionId = 8},
             new Product { Id = 6, Name = "Окорочка куриные", Price = 325, ImageUrl = "G01.jpg", Order = 5, SectionId = 7},
             new Product { Id = 7, Name = "Голень куриная", Price = 355, ImageUrl = "G01.jpg", Order = 6, SectionId = 7},
             new Product { Id = 8, Name = "Корейка свиная", Price = 475, ImageUrl = "G01.jpg", Order = 7, SectionId = 2},
             new Product { Id = 9, Name = "Вырезка говяжая", Price = 525, ImageUrl = "G01.jpg", Order = 8, SectionId = 4},
             new Product { Id = 10, Name = "Шейки индейки", Price = 299, ImageUrl = "G01.jpg", Order = 9, SectionId = 8},
             new Product { Id = 11, Name = "Сердце говяжье", Price = 285, ImageUrl = "G01.jpg", Order = 10, SectionId = 4},
             new Product { Id = 12, Name = "Бедро куриное", Price = 315, ImageUrl = "G01.jpg", Order = 11, SectionId = 7},
         };

        public static IEnumerable<Recipe> Recipes { get; } = new[]
       {
               new Recipe { Id = 1, Name = "Котлеты для бургеров", Order = 0 },
               new Recipe { Id = 2, Name = "говяжий фарш – 300 г", Order = 0, ParentId = 1 },
               new Recipe { Id = 3, Name = "свиной фарш – 100 г", Order = 1, ParentId = 1 },
               new Recipe { Id = 4, Name = "соль и черный молотый перец – по вкусу", Order = 2, ParentId = 1 },
               new Recipe { Id = 5, Name = "растительное масло – 0,5 ст. л.", Order = 3, ParentId = 1 },
               new Recipe { Id = 6, Name = "Домашнии колбаски", Order = 1 },
               new Recipe { Id = 7, Name = "50 г консервированных шампиньонов", Order = 0, ParentId = 6 },
               new Recipe { Id = 8, Name = "фарш из говядины и свинины", Order = 1, ParentId = 6 },
               new Recipe { Id = 9, Name = "соль и черный молотый перец – по вкусу", Order = 2, ParentId = 6 },
               new Recipe { Id = 10, Name = "растительное масло – 0,5 ст. л.", Order = 3, ParentId = 6 },
               new Recipe { Id = 11, Name = "Купаты", Order = 2 },
               new Recipe { Id = 12, Name = "говяжий фарш – 300 г", Order = 0, ParentId = 11 },
               new Recipe { Id = 13, Name = "свиной фарш – 100 г ", Order = 1, ParentId = 11 },
               new Recipe { Id = 14, Name = "соль и черный молотый перец – по вкусу", Order = 2, ParentId = 11 },
               new Recipe { Id = 15, Name = "растительное масло – 0,5 ст. л. ", Order = 3, ParentId = 11 },
         };
        public static IEnumerable<ReviewSite> Reviews { get; } = new[]
       {
               new ReviewSite { Id = 1, Name = "Ольга Павловна", Deliveri="№35245", Email="arh_med@mail.ru", Review="Спасибо за заказ", Stars=5 },
               new ReviewSite { Id = 2, Name = "Ольга Павловна", Deliveri="№35245", Email="arh_med@mail.ru", Review="Спасибо за заказ", Stars=5},
               new ReviewSite {Id = 3, Name = "Ольга Павловна", Deliveri="№35245", Email="arh_med@mail.ru", Review="Спасибо за заказ", Stars=5},
         };
        public static IEnumerable<RequestCall> Requests { get; } = new[]
       {
               new RequestCall { Id = 1, Name = "Ольга Павловна", Phone="+798 203 85 95", Email="arh_med@mail.ru", Headline="Спасибо за заказ", Message="Спасибо" },
               new RequestCall { Id = 2, Name = "Ольга Павловна", Phone="+798 203 85 95", Email="arh_med@mail.ru", Headline="Спасибо за заказ", Message="Спасибо"},
               new RequestCall {Id = 3, Name = "Ольга Павловна", Phone="+798 203 85 95", Email="arh_med@mail.ru", Headline="Спасибо за заказ", Message="Спасибо"},
         };
    }
}
