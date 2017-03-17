namespace CarSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdvertImages", "AdvertImageId", "dbo.AdvertImages");
            DropIndex("dbo.AdvertImages", new[] { "AdvertImageId" });
            DropIndex("dbo.AdvertImages", new[] { "Advert_Id" });
            DropColumn("dbo.AdvertImages", "AdvertImageId");
            RenameColumn(table: "dbo.AdvertImages", name: "Advert_Id", newName: "AdvertImageId");
            AlterColumn("dbo.AdvertImages", "AdvertImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.AdvertImages", "AdvertImageId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AdvertImages", new[] { "AdvertImageId" });
            AlterColumn("dbo.AdvertImages", "AdvertImageId", c => c.Int());
            RenameColumn(table: "dbo.AdvertImages", name: "AdvertImageId", newName: "Advert_Id");
            AddColumn("dbo.AdvertImages", "AdvertImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.AdvertImages", "Advert_Id");
            CreateIndex("dbo.AdvertImages", "AdvertImageId");
            AddForeignKey("dbo.AdvertImages", "AdvertImageId", "dbo.AdvertImages", "Id");
        }
    }
}
