namespace DeviceReg.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagDevice : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.TagDevices", "Device_Id", "dbo.Devices");
            DropForeignKey("dbo.TagDevices", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagDevices", new[] { "Device_Id" });
            DropIndex("dbo.TagDevices", new[] { "Tag_Id" });
            DropTable("dbo.TagDevices");
        }
    }
}
