namespace PetHotelWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Pets", "EmployeID", c => c.Int(nullable: false));
            AddColumn("dbo.Pets", "Employee_ID", c => c.Int());
            CreateIndex("dbo.Pets", "Employee_ID");
            AddForeignKey("dbo.Pets", "Employee_ID", "dbo.Employees", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "Employee_ID", "dbo.Employees");
            DropIndex("dbo.Pets", new[] { "Employee_ID" });
            DropColumn("dbo.Pets", "Employee_ID");
            DropColumn("dbo.Pets", "EmployeID");
            DropTable("dbo.Employees");
        }
    }
}
