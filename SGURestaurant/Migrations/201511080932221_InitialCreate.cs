namespace SGURestaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        BookingId = c.Int(nullable: false),
                        Meal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.Meal_Id)
                .Index(t => t.BookingId)
                .Index(t => t.Meal_Id);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        TableId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Table_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tables", t => t.Table_Id)
                .ForeignKey("dbo.Tables", t => t.TableId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TableId)
                .Index(t => t.UserId)
                .Index(t => t.Table_Id);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ChairNumber = c.Int(nullable: false),
                        Feature = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Gender = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Indredients = c.String(),
                        Price = c.Int(nullable: false),
                        MealTypeId = c.Int(nullable: false),
                        MealStyleId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MealStyles", t => t.MealStyleId, cascadeDelete: true)
                .ForeignKey("dbo.MealTypes", t => t.MealTypeId, cascadeDelete: true)
                .Index(t => t.MealTypeId)
                .Index(t => t.MealStyleId);
            
            CreateTable(
                "dbo.DialyMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MealStyles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MealTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Single(nullable: false),
                        Comment = c.String(),
                        MealId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .Index(t => t.MealId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meal_DialyMenu",
                c => new
                    {
                        MealId = c.Int(nullable: false),
                        DialyMenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MealId, t.DialyMenuId })
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .ForeignKey("dbo.DialyMenus", t => t.DialyMenuId, cascadeDelete: true)
                .Index(t => t.MealId)
                .Index(t => t.DialyMenuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.BookingDetails", "Meal_Id", "dbo.Meals");
            DropForeignKey("dbo.Votes", "MealId", "dbo.Meals");
            DropForeignKey("dbo.Meals", "MealTypeId", "dbo.MealTypes");
            DropForeignKey("dbo.Meals", "MealStyleId", "dbo.MealStyles");
            DropForeignKey("dbo.Meal_DialyMenu", "DialyMenuId", "dbo.DialyMenus");
            DropForeignKey("dbo.Meal_DialyMenu", "MealId", "dbo.Meals");
            DropForeignKey("dbo.Bookings", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Bookings", "TableId", "dbo.Tables");
            DropForeignKey("dbo.Bookings", "Table_Id", "dbo.Tables");
            DropForeignKey("dbo.BookingDetails", "BookingId", "dbo.Bookings");
            DropIndex("dbo.Meal_DialyMenu", new[] { "DialyMenuId" });
            DropIndex("dbo.Meal_DialyMenu", new[] { "MealId" });
            DropIndex("dbo.Votes", new[] { "MealId" });
            DropIndex("dbo.Meals", new[] { "MealStyleId" });
            DropIndex("dbo.Meals", new[] { "MealTypeId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Bookings", new[] { "Table_Id" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "TableId" });
            DropIndex("dbo.BookingDetails", new[] { "Meal_Id" });
            DropIndex("dbo.BookingDetails", new[] { "BookingId" });
            DropTable("dbo.Meal_DialyMenu");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Votes");
            DropTable("dbo.MealTypes");
            DropTable("dbo.MealStyles");
            DropTable("dbo.DialyMenus");
            DropTable("dbo.Meals");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.Tables");
            DropTable("dbo.Bookings");
            DropTable("dbo.BookingDetails");
        }
    }
}
