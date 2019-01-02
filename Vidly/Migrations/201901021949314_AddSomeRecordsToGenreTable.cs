namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeRecordsToGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id , Name) values(1,'Horror')");
            Sql("INSERT INTO Genres(Id , Name) values(2,'Comedy')");
            Sql("INSERT INTO Genres(Id , Name) values(3,'Action')");
            Sql("INSERT INTO Genres(Id , Name) values(4,'Trhiller')");
        }
        
        public override void Down()
        {
        }
    }
}
