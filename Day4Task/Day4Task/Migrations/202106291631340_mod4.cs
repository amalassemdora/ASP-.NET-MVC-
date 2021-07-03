namespace Day4Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "dept_id", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "dept_id" });
            AlterColumn("dbo.Students", "dept_id", c => c.Int());
            CreateIndex("dbo.Students", "dept_id");
            AddForeignKey("dbo.Students", "dept_id", "dbo.Departments", "Dept_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "dept_id", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "dept_id" });
            AlterColumn("dbo.Students", "dept_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "dept_id");
            AddForeignKey("dbo.Students", "dept_id", "dbo.Departments", "Dept_id", cascadeDelete: true);
        }
    }
}
