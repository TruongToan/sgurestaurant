namespace SGURestaurant.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SGURestaurant.Models.SGURestaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.SGURestaurantContext context)
        {
            var MealTypes = new List<MealType>()
            {
                new MealType() { Id=1, Name="Món khai vị", Description="Bắt đầu bữa ăn" },
                new MealType() { Id=2, Name="Món chính", Description="Giữa bữa ăn" },
                new MealType() { Id=3, Name="Món tráng miệng", Description="Sau khi ăn xong" }
            };
            MealTypes.ForEach(e => context.MealTypes.Add(e));
            context.SaveChanges();

            var MealStyles = new List<MealStyle>()
            {
                new MealStyle() { Id=1, Name="Món chay", Description="Dành cho người ăn chay" },
                new MealStyle() { Id=2, Name="Món mặn", Description="Dành cho người ăn mặn" }
            };
            MealStyles.ForEach(e => context.MealStyles.Add(e));
            context.SaveChanges();

            var Meals = new List<Meal>();
            string[] urls = new string[]
            {
                "http://afamily1.vcmedia.vn/k:thumb_w/600/Qalypm8xccccccccccccW2vZ1VroR/Image/2013/03/Chan-gio-bo-(0)-af702/mon-ngon-cuoi-tuan-chan-gio-bo.JPG",
                "http://mónngonchongàymưa.vn/upload/Colombo/39665/20150909/boxiengnuong.jpg",
                "http://kinhdoanhcafe.com/wp-content/uploads/2013/04/kfc-chicken.jpg"
            };
            for (int i = 0; i < 50; i++)
            {
                Meal meal = new Meal();
                meal.Name = "Meal " + i;
                meal.OriginPrice = new Random().Next(100000);
                meal.Price = meal.OriginPrice - new Random().Next((int)(meal.OriginPrice * 0.5));
                meal.Status = new Random().Next(5) == 0 ? false : true;
                meal.ImageUrl = urls[new Random().Next(urls.Length)];
                meal.Indredients = "Cá, tôm, cua";
                meal.MealStyleId = new Random().Next(1, 3);
                meal.MealTypeId = new Random().Next(1, 4);
                Meals.Add(meal);
            }
            Meals.ForEach(e => context.Meals.Add(e));
            context.SaveChanges();
        }
    }
}
