namespace DeviceReg.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDevice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "User_Id", c => c.Int());
            CreateIndex("dbo.Devices", "User_Id");
            AddForeignKey("dbo.Devices", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "User_Id", "dbo.Users");
            DropIndex("dbo.Devices", new[] { "User_Id" });
            DropColumn("dbo.Devices", "User_Id");
        }
    }
}
