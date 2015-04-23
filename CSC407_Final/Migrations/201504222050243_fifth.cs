namespace CSC407_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Comment_commentId", c => c.Int());
            CreateIndex("dbo.Threads", "Comment_commentId");
            AddForeignKey("dbo.Threads", "Comment_commentId", "dbo.Comments", "commentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Threads", "Comment_commentId", "dbo.Comments");
            DropIndex("dbo.Threads", new[] { "Comment_commentId" });
            DropColumn("dbo.Threads", "Comment_commentId");
        }
    }
}
