namespace DeviceReg.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WithoutVirtual : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "OwnerID", "dbo.Users");
            DropIndex("dbo.Tags", new[] { "OwnerID" });
            RenameColumn(table: "dbo.Tags", name: "OwnerID", newName: "User_Id");
            AlterColumn("dbo.Tags", "User_Id", c => c.Int());
            CreateIndex("dbo.Tags", "User_Id");
            AddForeignKey("dbo.Tags", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "User_Id", "dbo.Users");
            DropIndex("dbo.Tags", new[] { "User_Id" });
            AlterColumn("dbo.Tags", "User_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Tags", name: "User_Id", newName: "OwnerID");
            CreateIndex("dbo.Tags", "OwnerID");
            AddForeignKey("dbo.Tags", "OwnerID", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
