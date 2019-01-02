namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeMoviesToDatabase2 : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Movies (Name,GenreId,ReleaseDate,DateAdded,NumberInStock) values('Se7en',4,'1995-01-01','2019-02-25',5)");
            Sql("Insert Into Movies (Name,GenreId,ReleaseDate,DateAdded,NumberInStock) values('Saw',1,'2004-01-11','2019-03-31',3)");
            Sql("Insert Into Movies (Name,GenreId,ReleaseDate,DateAdded,NumberInStock) values('Aquaman',3,'2018-01-01','2019-04-3',2)");
        }
        
        public override void Down()
        {
        }
    }
}
