namespace Day4Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "dept_Dept_id", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "dept_Dept_id" });
            RenameColumn(table: "dbo.Students", name: "dept_Dept_id", newName: "dept_id");
            AlterColumn("dbo.Students", "dept_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "dept_id");
            AddForeignKey("dbo.Students", "dept_id", "dbo.Departments", "Dept_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "dept_id", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "dept_id" });
            AlterColumn("dbo.Students", "dept_id", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "dept_id", newName: "dept_Dept_id");
            CreateIndex("dbo.Students", "dept_Dept_id");
            AddForeignKey("dbo.Students", "dept_Dept_id", "dbo.Departments", "Dept_id");
        }
    }
}
