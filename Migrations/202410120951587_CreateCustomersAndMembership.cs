namespace asp.net_vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCustomersAndMembership : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        IsSubscribedToNewsLetter = c.Boolean(nullable: false),
                        MembershipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        MembershipTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        SignUpFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MembershipTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
        }
    }
}
