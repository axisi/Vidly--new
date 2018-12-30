namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateToSomeRecords : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE  Customers set BirthDate = '10/9/1989' where Id=3");
            Sql("UPDATE  Customers set BirthDate = '3/8/1992' where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
