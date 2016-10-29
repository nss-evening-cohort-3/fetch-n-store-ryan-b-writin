namespace FetchNStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        URL = c.String(nullable: false),
                        ResponseTime = c.Int(nullable: false),
                        Method = c.String(nullable: false),
                        Code = c.Int(nullable: false),
                        SendDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ResponseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Responses");
        }
    }
}
