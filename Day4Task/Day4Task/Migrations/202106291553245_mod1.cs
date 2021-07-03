namespace Day4Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Departments");
            AddColumn("dbo.Departments", "Dept_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Students", "Age", c => c.Int());
            AddPrimaryKey("dbo.Departments", "Dept_id");
            DropColumn("dbo.Departments", "id");
            DropColumn("dbo.Students", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "MyProperty", c => c.Int(nullable: false));
            AddColumn("dbo.Departments", "id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.Students", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String());
            DropColumn("dbo.Departments", "Dept_id");
            AddPrimaryKey("dbo.Departments", "id");
        }
    }
}
