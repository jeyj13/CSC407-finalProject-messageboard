namespace CSC407_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        commentId = c.Int(nullable: false, identity: true),
                        threadId = c.Int(),
                        username = c.String(),
                        comment = c.String(),
                        timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.commentId)
                .ForeignKey("dbo.Threads", t => t.threadId)
                .Index(t => t.threadId);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        threadId = c.Int(nullable: false, identity: true),
                        postDate = c.DateTime(nullable: false),
                        username = c.String(maxLength: 128),
                        title = c.String(),
                        postText = c.String(),
                    })
                .PrimaryKey(t => t.threadId)
                .ForeignKey("dbo.Users", t => t.username)
                .Index(t => t.username);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Email = c.String(),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "threadId", "dbo.Threads");
            DropForeignKey("dbo.Threads", "username", "dbo.Users");
            DropIndex("dbo.Threads", new[] { "username" });
            DropIndex("dbo.Comments", new[] { "threadId" });
            DropTable("dbo.Users");
            DropTable("dbo.Threads");
            DropTable("dbo.Comments");
        }
    }
}
