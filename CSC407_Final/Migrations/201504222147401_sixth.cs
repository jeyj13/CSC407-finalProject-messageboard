namespace CSC407_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Thread_threadId", c => c.Int());
            CreateIndex("dbo.Comments", "Thread_threadId");
            AddForeignKey("dbo.Comments", "Thread_threadId", "dbo.Threads", "threadId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Thread_threadId", "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "Thread_threadId" });
            DropColumn("dbo.Comments", "Thread_threadId");
        }
    }
}
