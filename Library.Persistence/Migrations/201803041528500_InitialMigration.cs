namespace Library.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 70, unicode: false),
                        Subtitle = c.String(maxLength: 70, unicode: false),
                        Subject = c.String(nullable: false, maxLength: 50, unicode: false),
                        Publisher = c.String(nullable: false, maxLength: 50, unicode: false),
                        Author = c.String(nullable: false, maxLength: 50, unicode: false),
                        PublishDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        IncludedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Book");
        }
    }
}
