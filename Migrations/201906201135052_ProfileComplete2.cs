namespace MultiSelectExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileComplete2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profile", "ProfilerNumber", c => c.String());
            AlterColumn("dbo.ProfileViewModel", "ProfilerName", c => c.String(nullable: false));
            AlterColumn("dbo.ProfileViewModel", "ProfilerNumber", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProfileViewModel", "ProfilerNumber", c => c.String());
            AlterColumn("dbo.ProfileViewModel", "ProfilerName", c => c.String());
            AlterColumn("dbo.Profile", "ProfilerNumber", c => c.String(maxLength: 10));
        }
    }
}
