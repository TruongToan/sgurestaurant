using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SGURestaurant.Models
{
    public class SGURestaurantContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SGURestaurantContext() : base("name=SGURestaurantContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasKey(e => e.Id);
            modelBuilder.Entity<BookingDetail>().HasKey(e => e.Id);
            modelBuilder.Entity<DialyMenu>().HasKey(e => e.Id);
            modelBuilder.Entity<ApplicationUser>().HasKey(e => e.Id);
            modelBuilder.Entity<Meal>().HasKey(e => e.Id);
            modelBuilder.Entity<MealStyle>().HasKey(e => e.Id);
            modelBuilder.Entity<MealType>().HasKey(e => e.Id);
            modelBuilder.Entity<Table>().HasKey(e => e.Id);

            modelBuilder.Entity<Booking>().HasMany(e => e.BookingDetails).WithRequired().HasForeignKey(e => e.BookingId);
            modelBuilder.Entity<Booking>().HasRequired(e => e.User).WithMany(e => e.Bookings).HasForeignKey(e => e.UserId);
            modelBuilder.Entity<Booking>().HasRequired(e => e.Table).WithMany().HasForeignKey(e => e.TableId);
            modelBuilder.Entity<DialyMenu>().HasMany(e => e.Meals).WithOptional();
            modelBuilder.Entity<Meal>().HasRequired(e => e.MealStyle).WithMany(e => e.Meals).HasForeignKey(e => e.MealStyleId);
            modelBuilder.Entity<Meal>().HasRequired(e => e.MealType).WithMany(e => e.Meals).HasForeignKey(e => e.MealTypeId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Meal> Meals { get; set; }

        public DbSet<MealStyle> MealStyles { get; set; }

        public DbSet<MealType> MealTypes { get; set; }
    }
}
