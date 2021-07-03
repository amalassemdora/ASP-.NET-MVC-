namespace Day4Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "dept_Dept_id", c => c.Int());
            CreateIndex("dbo.Students", "dept_Dept_id");
            AddForeignKey("dbo.Students", "dept_Dept_id", "dbo.Departments", "Dept_id");
            DropColumn("dbo.Students", "deptId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "deptId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Students", "dept_Dept_id", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "dept_Dept_id" });
            DropColumn("dbo.Students", "dept_Dept_id");
        }
    }
}
