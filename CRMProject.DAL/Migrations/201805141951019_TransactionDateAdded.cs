namespace CRMProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "Date");
        }
    }
}
