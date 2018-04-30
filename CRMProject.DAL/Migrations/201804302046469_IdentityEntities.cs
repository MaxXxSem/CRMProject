namespace CRMProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            CreateTable(
                "dbo.IdentityUserDatas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false, maxLength: 64),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(nullable: false, maxLength: 64),
                        UserName = c.String(nullable: false, maxLength: 64),
                        SecurityStamp = c.String(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            AddColumn("dbo.User", "UserDataId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.User", "UserDataId");
            AddForeignKey("dbo.User", "UserDataId", "dbo.IdentityUserDatas", "Id");
            DropColumn("dbo.User", "Email");
            DropColumn("dbo.User", "EmailConfirmed");
            DropColumn("dbo.User", "PasswordHash");
            DropColumn("dbo.User", "UserName");
            DropColumn("dbo.User", "SecurityStamp");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId });
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.User", "SecurityStamp", c => c.String());
            AddColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.User", "PasswordHash", c => c.String(nullable: false, maxLength: 64, fixedLength: true));
            AddColumn("dbo.User", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 64));
            DropForeignKey("dbo.User", "UserDataId", "dbo.IdentityUserDatas");
            DropForeignKey("dbo.IdentityUserDatas", "Users_Id", "dbo.User");
            DropIndex("dbo.IdentityUserDatas", new[] { "Users_Id" });
            DropIndex("dbo.User", new[] { "UserDataId" });
            DropColumn("dbo.User", "UserDataId");
            DropTable("dbo.IdentityUserDatas");
            CreateIndex("dbo.UserRole", "UserId");
            CreateIndex("dbo.UserRole", "RoleId");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
        }
    }
}
