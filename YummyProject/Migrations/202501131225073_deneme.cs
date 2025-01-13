namespace YummyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Services", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
