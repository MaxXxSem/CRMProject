namespace CRMProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesAdded : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IdentityUserDatas", newName: "IdentityUserData");
            RenameColumn(table: "dbo.IdentityUserData", name: "Users_Id", newName: "User_Id");
            RenameIndex(table: "dbo.IdentityUserData", name: "IX_Users_Id", newName: "IX_User_Id");
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityUserData", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.IdentityUserData");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            RenameIndex(table: "dbo.IdentityUserData", name: "IX_User_Id", newName: "IX_Users_Id");
            RenameColumn(table: "dbo.IdentityUserData", name: "User_Id", newName: "Users_Id");
            RenameTable(name: "dbo.IdentityUserData", newName: "IdentityUserDatas");
        }
    }
}
