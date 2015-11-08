using System.Collections.Generic;
using System.Data.Entity;

namespace SGURestaurant.Models
{
    public class SGURestaurantManagerDbInitializer : DropCreateDatabaseIfModelChanges<SGURestaurantContext>
    {
        protected override void Seed(SGURestaurantContext context)
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

            var Meals = new List<Meal>()
            {
                new Meal() { Name = "Món 1", Price=20000, ImageUrl = "http://mónngonchongàymưa.vn/upload/Colombo/39665/20150909/boxiengnuong.jpg" }
            };
            Meals.ForEach(e => context.Meals.Add(e));
            context.SaveChanges();
        }
    }
}