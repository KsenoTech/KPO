namespace sheff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        surname = c.String(nullable: false),
                        name = c.String(nullable: false),
                        middle_name = c.String(nullable: false),
                        e_mail = c.String(nullable: false),
                        login = c.String(nullable: false),
                        password = c.String(nullable: false),
                        address = c.String(nullable: false),
                        telephone_number = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        executor_ID = c.Int(nullable: false),
                        client_ID = c.Int(nullable: false),
                        description = c.String(nullable: false),
                        time_order = c.DateTime(nullable: false),
                        general_budget = c.Int(nullable: false),
                        progress = c.Int(nullable: false),
                        feedback_ID = c.Int(nullable: false),
                        IsItFinished = c.Boolean(nullable: false),
                        canIdoIt = c.Boolean(nullable: false),
                        OrderPosition = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Executor", t => t.executor_ID)
                .ForeignKey("dbo.Feedback", t => t.feedback_ID)
                .ForeignKey("dbo.Client", t => t.client_ID)
                .Index(t => t.executor_ID)
                .Index(t => t.client_ID)
                .Index(t => t.feedback_ID);
            
            CreateTable(
                "dbo.Executor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        login = c.String(nullable: false),
                        password = c.String(nullable: false),
                        e_mail = c.String(nullable: false),
                        rating = c.Single(),
                        surname = c.String(nullable: false),
                        name = c.String(nullable: false),
                        middle_name = c.String(nullable: false),
                        telephone_number = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        feedback_mark = c.Int(nullable: false),
                        feedback_text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Type_of_service",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        description_of_service = c.String(nullable: false),
                        cost_of_m = c.Int(),
                        cost_of_m2 = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "client_ID", "dbo.Client");
            DropForeignKey("dbo.Type_of_service", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.Order", "feedback_ID", "dbo.Feedback");
            DropForeignKey("dbo.Order", "executor_ID", "dbo.Executor");
            DropIndex("dbo.Type_of_service", new[] { "Order_Id" });
            DropIndex("dbo.Order", new[] { "feedback_ID" });
            DropIndex("dbo.Order", new[] { "client_ID" });
            DropIndex("dbo.Order", new[] { "executor_ID" });
            DropTable("dbo.Type_of_service");
            DropTable("dbo.Feedback");
            DropTable("dbo.Executor");
            DropTable("dbo.Order");
            DropTable("dbo.Client");
        }
    }
}
