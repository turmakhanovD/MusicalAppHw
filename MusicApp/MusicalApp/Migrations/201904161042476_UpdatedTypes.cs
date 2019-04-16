namespace MusicalApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdatedTypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "GroupId_Id", "dbo.Groups");
            DropForeignKey("dbo.Songs", "Group_Id", "dbo.Groups");
            DropIndex("dbo.Songs", new[] { "Group_Id" });
            DropIndex("dbo.Songs", new[] { "GroupId_Id" });
            RenameColumn(table: "dbo.Songs", name: "Group_Id", newName: "GroupId");
            AlterColumn("dbo.Songs", "Duration", c => c.Long(nullable: false));
            AlterColumn("dbo.Songs", "GroupId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Songs", "GroupId");
            AddForeignKey("dbo.Songs", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
            DropColumn("dbo.Songs", "GroupId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "GroupId_Id", c => c.Guid());
            DropForeignKey("dbo.Songs", "GroupId", "dbo.Groups");
            DropIndex("dbo.Songs", new[] { "GroupId" });
            AlterColumn("dbo.Songs", "GroupId", c => c.Guid());
            AlterColumn("dbo.Songs", "Duration", c => c.String());
            RenameColumn(table: "dbo.Songs", name: "GroupId", newName: "Group_Id");
            CreateIndex("dbo.Songs", "GroupId_Id");
            CreateIndex("dbo.Songs", "Group_Id");
            AddForeignKey("dbo.Songs", "Group_Id", "dbo.Groups", "Id");
            AddForeignKey("dbo.Songs", "GroupId_Id", "dbo.Groups", "Id");
        }
    }
}
