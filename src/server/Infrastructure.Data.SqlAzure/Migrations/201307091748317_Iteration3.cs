namespace Infrastructure.Data.SqlAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Iteration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobApplications", "ApplicantId", "dbo.JobApplicants");
            DropForeignKey("dbo.JobApplications", "PositionId", "dbo.Jobs");
            DropIndex("dbo.JobApplications", new[] { "ApplicantId" });
            DropIndex("dbo.JobApplications", new[] { "PositionId" });
            AddColumn("dbo.JobApplications", "JobApplicantId", c => c.Guid(nullable: false));
            AddColumn("dbo.JobApplications", "JobId", c => c.Guid(nullable: false));
            AddForeignKey("dbo.JobApplications", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
            CreateIndex("dbo.JobApplications", "JobId");
            DropColumn("dbo.JobApplications", "ApplicantId");
            DropColumn("dbo.JobApplications", "PositionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobApplications", "PositionId", c => c.Guid(nullable: false));
            AddColumn("dbo.JobApplications", "ApplicantId", c => c.Guid(nullable: false));
            DropIndex("dbo.JobApplications", new[] { "JobId" });
            DropForeignKey("dbo.JobApplications", "JobId", "dbo.Jobs");
            DropColumn("dbo.JobApplications", "JobId");
            DropColumn("dbo.JobApplications", "JobApplicantId");
            CreateIndex("dbo.JobApplications", "PositionId");
            CreateIndex("dbo.JobApplications", "ApplicantId");
            AddForeignKey("dbo.JobApplications", "PositionId", "dbo.Jobs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobApplications", "ApplicantId", "dbo.JobApplicants", "Id", cascadeDelete: true);
        }
    }
}
