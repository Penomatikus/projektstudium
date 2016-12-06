namespace DeviceReg.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRefInDevice : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Devices", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Devices", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Devices", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Devices", name: "UserId", newName: "User_Id");
        }
    }
}
