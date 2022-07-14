namespace OnlineShoppingDemo2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "CateId", "dbo.Categories");
            DropIndex("dbo.Carts", new[] { "CateId" });
            DropTable("dbo.Carts");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Carts", "CateId");
            AddForeignKey("dbo.Carts", "CateId", "dbo.Categories", "CateId", cascadeDelete: true);
        }
    }
}
