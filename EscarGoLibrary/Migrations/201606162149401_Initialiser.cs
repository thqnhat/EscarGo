namespace EscarGoLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialiser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Concurrents",
                c => new
                    {
                        IdConcurrent = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Victoires = c.Int(nullable: false),
                        Defaites = c.Int(nullable: false),
                        IdEntraineur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdConcurrent)
                .ForeignKey("dbo.Entraineurs", t => t.IdEntraineur, cascadeDelete: true)
                .Index(t => t.IdEntraineur);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        IdCourse = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Date = c.DateTime(nullable: false),
                        Pays = c.String(),
                        Ville = c.String(),
                        Likes = c.Int(nullable: false),
                        NbTickets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCourse);
            
            CreateTable(
                "dbo.Entraineurs",
                c => new
                    {
                        IdEntraineur = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.IdEntraineur);
            
            CreateTable(
                "dbo.Paris",
                c => new
                    {
                        IdPari = c.Int(nullable: false, identity: true),
                        DateDernierPari = c.DateTime(nullable: false),
                        NbParis = c.Int(nullable: false),
                        IdCourse = c.Int(nullable: false),
                        IdConcurrent = c.Int(nullable: false),
                        SC = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdPari)
                .ForeignKey("dbo.Concurrents", t => t.IdConcurrent, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.IdCourse, cascadeDelete: true)
                .Index(t => t.IdCourse)
                .Index(t => t.IdConcurrent);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        NbPlaces = c.Int(nullable: false),
                        Acheteur_Id = c.Int(),
                        Course_IdCourse = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Visiteurs", t => t.Acheteur_Id)
                .ForeignKey("dbo.Courses", t => t.Course_IdCourse)
                .Index(t => t.Acheteur_Id)
                .Index(t => t.Course_IdCourse);
            
            CreateTable(
                "dbo.Visiteurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConcurrentCourses",
                c => new
                    {
                        Concurrent_IdConcurrent = c.Int(nullable: false),
                        Course_IdCourse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Concurrent_IdConcurrent, t.Course_IdCourse })
                .ForeignKey("dbo.Concurrents", t => t.Concurrent_IdConcurrent, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_IdCourse, cascadeDelete: true)
                .Index(t => t.Concurrent_IdConcurrent)
                .Index(t => t.Course_IdCourse);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Course_IdCourse", "dbo.Courses");
            DropForeignKey("dbo.Tickets", "Acheteur_Id", "dbo.Visiteurs");
            DropForeignKey("dbo.Paris", "IdCourse", "dbo.Courses");
            DropForeignKey("dbo.Paris", "IdConcurrent", "dbo.Concurrents");
            DropForeignKey("dbo.Concurrents", "IdEntraineur", "dbo.Entraineurs");
            DropForeignKey("dbo.ConcurrentCourses", "Course_IdCourse", "dbo.Courses");
            DropForeignKey("dbo.ConcurrentCourses", "Concurrent_IdConcurrent", "dbo.Concurrents");
            DropIndex("dbo.ConcurrentCourses", new[] { "Course_IdCourse" });
            DropIndex("dbo.ConcurrentCourses", new[] { "Concurrent_IdConcurrent" });
            DropIndex("dbo.Tickets", new[] { "Course_IdCourse" });
            DropIndex("dbo.Tickets", new[] { "Acheteur_Id" });
            DropIndex("dbo.Paris", new[] { "IdConcurrent" });
            DropIndex("dbo.Paris", new[] { "IdCourse" });
            DropIndex("dbo.Concurrents", new[] { "IdEntraineur" });
            DropTable("dbo.ConcurrentCourses");
            DropTable("dbo.Visiteurs");
            DropTable("dbo.Tickets");
            DropTable("dbo.Paris");
            DropTable("dbo.Entraineurs");
            DropTable("dbo.Courses");
            DropTable("dbo.Concurrents");
        }
    }
}