﻿namespace YummyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageUrl2addedToAboutClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "ImageUrl2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "ImageUrl2");
        }
    }
}
