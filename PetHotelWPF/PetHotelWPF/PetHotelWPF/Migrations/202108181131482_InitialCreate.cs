namespace PetHotelWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        PetName = c.String(),
                        Specie = c.String(),
                        Age = c.Int(nullable: false),
                        IsGuestNow = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PetID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Pets", new[] { "CustomerID" });
            DropTable("dbo.Pets");
            DropTable("dbo.Customers");
        }
    }
}
