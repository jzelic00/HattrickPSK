namespace HattrickPSK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        Tip1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tip2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipX = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PaymentTime = c.DateTime(nullable: false),
                        BetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bonus5 = c.Boolean(nullable: false),
                        Bonus10 = c.Boolean(nullable: false),
                        Odds = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.TicketEvents",
                c => new
                    {
                        TicketID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                        Tip = c.String(),
                    })
                .PrimaryKey(t => new { t.TicketID, t.EventID })
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketID, cascadeDelete: true)
                .Index(t => t.TicketID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.RoleID })
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Tickets", "UserID", "dbo.Users");
            DropForeignKey("dbo.TicketEvents", "TicketID", "dbo.Tickets");
            DropForeignKey("dbo.TicketEvents", "EventID", "dbo.Events");
            DropIndex("dbo.UserRoles", new[] { "RoleID" });
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropIndex("dbo.TicketEvents", new[] { "EventID" });
            DropIndex("dbo.TicketEvents", new[] { "TicketID" });
            DropIndex("dbo.Tickets", new[] { "UserID" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.TicketEvents");
            DropTable("dbo.Tickets");
            DropTable("dbo.Roles");
            DropTable("dbo.Events");
        }
    }
}
