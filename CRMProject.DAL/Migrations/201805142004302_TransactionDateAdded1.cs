namespace CRMProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDateAdded1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "Date", c => c.DateTime(nullable: false));
        }
    }
}
