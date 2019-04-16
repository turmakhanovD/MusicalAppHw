namespace MusicalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        MemberCount = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Text = c.String(),
                        Duration = c.String(),
                        Rating = c.Int(nullable: false),
                        Group_Id = c.Guid(),
                        GroupId_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .ForeignKey("dbo.Groups", t => t.GroupId_Id)
                .Index(t => t.Group_Id)
                .Index(t => t.GroupId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "GroupId_Id", "dbo.Groups");
            DropForeignKey("dbo.Songs", "Group_Id", "dbo.Groups");
            DropIndex("dbo.Songs", new[] { "GroupId_Id" });
            DropIndex("dbo.Songs", new[] { "Group_Id" });
            DropTable("dbo.Songs");
            DropTable("dbo.Groups");
        }
    }
}
