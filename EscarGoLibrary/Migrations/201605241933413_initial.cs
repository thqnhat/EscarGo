namespace EscarGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                        Entraineur = c.String(),
                    })
                .PrimaryKey(t => t.IdConcurrent);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        IdCourse = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Date = c.DateTime(nullable: false),
                        Pays = c.String(),
                        Ville = c.String(),
                    })
                .PrimaryKey(t => t.IdCourse);
            
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
            DropForeignKey("dbo.Paris", "IdCourse", "dbo.Courses");
            DropForeignKey("dbo.Paris", "IdConcurrent", "dbo.Concurrents");
            DropForeignKey("dbo.ConcurrentCourses", "Course_IdCourse", "dbo.Courses");
            DropForeignKey("dbo.ConcurrentCourses", "Concurrent_IdConcurrent", "dbo.Concurrents");
            DropIndex("dbo.ConcurrentCourses", new[] { "Course_IdCourse" });
            DropIndex("dbo.ConcurrentCourses", new[] { "Concurrent_IdConcurrent" });
            DropIndex("dbo.Paris", new[] { "IdConcurrent" });
            DropIndex("dbo.Paris", new[] { "IdCourse" });
            DropTable("dbo.ConcurrentCourses");
            DropTable("dbo.Paris");
            DropTable("dbo.Courses");
            DropTable("dbo.Concurrents");
        }
    }
}