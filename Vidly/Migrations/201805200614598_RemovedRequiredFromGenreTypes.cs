namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequiredFromGenreTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GenreTypes", "name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GenreTypes", "name", c => c.String(nullable: false));
        }
    }
}
