namespace DeviceReg.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Serialnumber = c.String(),
                        RegularMaintenance = c.Boolean(nullable: false),
                        Timestamp_Created = c.DateTime(),
                        Timestamp_Deleted = c.DateTime(),
                        Timestamp_Modified = c.DateTime(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp_Created = c.DateTime(),
                        Timestamp_Deleted = c.DateTime(),
                        Timestamp_Modified = c.DateTime(),
                        name = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp_Created = c.DateTime(),
                        Timestamp_Deleted = c.DateTime(),
                        Timestamp_Modified = c.DateTime(),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagDevices",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Device_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Device_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Devices", t => t.Device_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Device_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Devices", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TagDevices", "Device_Id", "dbo.Devices");
            DropForeignKey("dbo.TagDevices", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagDevices", new[] { "Device_Id" });
            DropIndex("dbo.TagDevices", new[] { "Tag_Id" });
            DropIndex("dbo.Tags", new[] { "User_Id" });
            DropIndex("dbo.Devices", new[] { "User_Id" });
            DropTable("dbo.TagDevices");
            DropTable("dbo.Users");
            DropTable("dbo.Tags");
            DropTable("dbo.Devices");
        }
    }
}
