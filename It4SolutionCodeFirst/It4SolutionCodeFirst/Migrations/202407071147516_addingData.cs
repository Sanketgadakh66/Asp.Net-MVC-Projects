namespace It4SolutionCodeFirst.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addingData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Roles(Name) VALUES('Adminastartor')");
            Sql("INSERT INTO Roles(Name) VALUES('Poewr User')");
            Sql("INSERT INTO Roles(Name) VALUES('User')");
            Sql("INSERT INTO Roles(Name) VALUES('HR')");
        }

        public override void Down()
        {
        }
    }
}
