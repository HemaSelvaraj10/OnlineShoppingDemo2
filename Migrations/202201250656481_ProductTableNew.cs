namespace OnlineShoppingDemo2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductTableNew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageUrl1", c => c.String());
            AddColumn("dbo.Products", "ImageUrl2", c => c.String());
            AddColumn("dbo.Products", "ImageUrl3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImageUrl3");
            DropColumn("dbo.Products", "ImageUrl2");
            DropColumn("dbo.Products", "ImageUrl1");
        }
    }
}
