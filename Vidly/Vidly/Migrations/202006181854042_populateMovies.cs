namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, Genre, dateReleased, dateAdded, inStock) VALUES ('Shrek', 'Infantil', 01/01/1900, 01/01/1950,10)");
            Sql("INSERT INTO Movies (Name, Genre, dateReleased, dateAdded, inStock) VALUES ('Wall-e', 'Infantil', 01/01/1900, 01/01/1950,8)");

        }
        
        public override void Down()
        {
        }
    }
}
