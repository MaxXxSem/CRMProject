namespace CRMProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityEntitiesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "PasswordHash", c => c.String(nullable: false, maxLength: 64, fixedLength: true));
            AddColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.User", "SecurityStamp", c => c.String());
            DropColumn("dbo.User", "Password");
            DropColumn("dbo.User", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Name", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 64, fixedLength: true));
            DropColumn("dbo.User", "SecurityStamp");
            DropColumn("dbo.User", "UserName");
            DropColumn("dbo.User", "PasswordHash");
            DropColumn("dbo.User", "EmailConfirmed");
        }
    }
}
