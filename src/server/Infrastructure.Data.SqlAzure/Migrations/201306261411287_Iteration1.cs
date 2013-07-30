namespace Infrastructure.Data.SqlAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Iteration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "PersonHiredId", "dbo.JobApplicants");
            DropIndex("dbo.Jobs", new[] { "PersonHiredId" });
            AlterColumn("dbo.Jobs", "PersonHiredId", c => c.Guid());
            AddForeignKey("dbo.Jobs", "PersonHiredId", "dbo.JobApplicants", "Id");
            CreateIndex("dbo.Jobs", "PersonHiredId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Jobs", new[] { "PersonHiredId" });
            DropForeignKey("dbo.Jobs", "PersonHiredId", "dbo.JobApplicants");
            AlterColumn("dbo.Jobs", "PersonHiredId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Jobs", "PersonHiredId");
            AddForeignKey("dbo.Jobs", "PersonHiredId", "dbo.JobApplicants", "Id", cascadeDelete: true);
        }
    }
}
