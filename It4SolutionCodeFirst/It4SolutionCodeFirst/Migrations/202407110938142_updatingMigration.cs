namespace It4SolutionCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingMigration : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Suppliers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mobile = c.Int(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
