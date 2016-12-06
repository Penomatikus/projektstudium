namespace DeviceReg.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDeviceRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Devices", "User_Id");
            AddForeignKey("dbo.Devices", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Devices", new[] { "User_Id" });
            DropColumn("dbo.Devices", "User_Id");
        }
    }
}
