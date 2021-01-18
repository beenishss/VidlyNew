namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres(GenreType) Values('Comedy')");
            Sql("Insert Into Genres(GenreType) Values('Horror')");
            Sql("Insert Into Genres(GenreType) Values('Fiction')");
            Sql("Insert Into Genres(GenreType) Values('Romantic')");

        }
        
        public override void Down()
        {
        }
    }
}
