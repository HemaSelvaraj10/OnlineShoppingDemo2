namespace OnlineShoppingDemo2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ImageUrl = c.String(),
                        ImageUrl1 = c.String(),
                        ImageUrl2 = c.String(),
                        ImageUrl3 = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CateId, cascadeDelete: true)
                .Index(t => t.CateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "CateId", "dbo.Categories");
            DropIndex("dbo.Carts", new[] { "CateId" });
            DropTable("dbo.Carts");
        }
    }
}
