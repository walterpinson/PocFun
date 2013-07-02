namespace Infrastructure.Data.SqlAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Iteration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobApplicants", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.JobApplicants", new[] { "Job_Id" });
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ApplicantId = c.Guid(nullable: false),
                        PositionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobApplicants", t => t.ApplicantId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.ApplicantId)
                .Index(t => t.PositionId);
            
            DropColumn("dbo.JobApplicants", "Job_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobApplicants", "Job_Id", c => c.Guid());
            DropIndex("dbo.JobApplications", new[] { "PositionId" });
            DropIndex("dbo.JobApplications", new[] { "ApplicantId" });
            DropForeignKey("dbo.JobApplications", "PositionId", "dbo.Jobs");
            DropForeignKey("dbo.JobApplications", "ApplicantId", "dbo.JobApplicants");
            DropTable("dbo.JobApplications");
            CreateIndex("dbo.JobApplicants", "Job_Id");
            AddForeignKey("dbo.JobApplicants", "Job_Id", "dbo.Jobs", "Id");
        }
    }
}
