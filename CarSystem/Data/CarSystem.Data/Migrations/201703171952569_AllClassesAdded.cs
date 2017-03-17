namespace CarSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllClassesAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            CreateTable(
                "dbo.AdvertImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageData = c.Binary(),
                        ImageName = c.String(),
                        AdvertImageId = c.Int(nullable: false),
                        Advert_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdvertImages", t => t.AdvertImageId)
                .ForeignKey("dbo.Adverts", t => t.Advert_Id)
                .Index(t => t.AdvertImageId)
                .Index(t => t.Advert_Id);
            
            CreateTable(
                "dbo.Adverts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        VehicleModelId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Year = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Power = c.Int(nullable: false),
                        DistanceCoverage = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId)
                .Index(t => t.VehicleModelId)
                .Index(t => t.UserId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        ManufacturerId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId)
                .Index(t => t.Name, unique: true)
                .Index(t => t.ManufacturerId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 20));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 20));
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.VehicleModels", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.VehicleModels", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Adverts", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.Adverts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Adverts", "CityId", "dbo.Cities");
            DropForeignKey("dbo.AdvertImages", "Advert_Id", "dbo.Adverts");
            DropForeignKey("dbo.AdvertImages", "AdvertImageId", "dbo.AdvertImages");
            DropIndex("dbo.Manufacturers", new[] { "Name" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropIndex("dbo.VehicleModels", new[] { "CategoryId" });
            DropIndex("dbo.VehicleModels", new[] { "ManufacturerId" });
            DropIndex("dbo.VehicleModels", new[] { "Name" });
            DropIndex("dbo.Cities", new[] { "Name" });
            DropIndex("dbo.Adverts", new[] { "CityId" });
            DropIndex("dbo.Adverts", new[] { "UserId" });
            DropIndex("dbo.Adverts", new[] { "VehicleModelId" });
            DropIndex("dbo.AdvertImages", new[] { "Advert_Id" });
            DropIndex("dbo.AdvertImages", new[] { "AdvertImageId" });
            DropColumn("dbo.AspNetUsers", "IsDeleted");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Categories");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.Cities");
            DropTable("dbo.Adverts");
            DropTable("dbo.AdvertImages");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
