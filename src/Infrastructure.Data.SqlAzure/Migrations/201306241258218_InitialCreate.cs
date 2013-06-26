namespace Infrastructure.Data.SqlAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsFilled = c.Boolean(nullable: false),
                        PersonHiredId = c.Guid(nullable: false),
                        PersonHired_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobApplicants", t => t.PersonHired_Id)
                .Index(t => t.PersonHired_Id);
            
            CreateTable(
                "dbo.JobApplicants",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name_First = c.String(),
                        Name_Last = c.String(),
                        Address_Street = c.String(),
                        Address_City = c.String(),
                        Address_State = c.String(),
                        Address_Zip = c.String(),
                        PhoneNumber = c.String(),
                        Job_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id)
                .Index(t => t.Job_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.JobApplicants", new[] { "Job_Id" });
            DropIndex("dbo.Jobs", new[] { "PersonHired_Id" });
            DropForeignKey("dbo.JobApplicants", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "PersonHired_Id", "dbo.JobApplicants");
            DropTable("dbo.JobApplicants");
            DropTable("dbo.Jobs");
        }
    }
}
