namespace sheff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Order", new[] { "executor_ID" });
            DropIndex("dbo.Order", new[] { "feedback_ID" });
            AlterColumn("dbo.Order", "executor_ID", c => c.Int());
            AlterColumn("dbo.Order", "feedback_ID", c => c.Int());
            CreateIndex("dbo.Order", "executor_ID");
            CreateIndex("dbo.Order", "feedback_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Order", new[] { "feedback_ID" });
            DropIndex("dbo.Order", new[] { "executor_ID" });
            AlterColumn("dbo.Order", "feedback_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "executor_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Order", "feedback_ID");
            CreateIndex("dbo.Order", "executor_ID");
        }
    }
}
