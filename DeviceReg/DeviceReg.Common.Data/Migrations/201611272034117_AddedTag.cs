namespace DeviceReg.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp_Created = c.DateTime(),
                        Timestamp_Deleted = c.DateTime(),
                        Timestamp_Modified = c.DateTime(),
                        name = c.String(),
                        OwnerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerID, cascadeDelete: true)
                .Index(t => t.OwnerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "OwnerID", "dbo.Users");
            DropIndex("dbo.Tags", new[] { "OwnerID" });
            DropTable("dbo.Tags");
        }
    }
}
