namespace HattrickPSK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "UserID", "dbo.Users");
            DropForeignKey("dbo.TicketEvents", "TicketID", "dbo.Tickets");
            DropForeignKey("dbo.TicketEvents", "EventID", "dbo.Events");
            DropIndex("dbo.Tickets", new[] { "UserID" });
            DropIndex("dbo.TicketEvents", new[] { "EventID" });
            DropIndex("dbo.TicketEvents", new[] { "TicketID" });
            DropTable("dbo.Users");
            DropTable("dbo.Tickets");
            DropTable("dbo.TicketEvents");
            DropTable("dbo.Events");
        }
    }
}
