namespace CvBerkaySezer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class domain1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Domains", "DomainName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropColumn("dbo.Domains", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Domains", "UserName", c => c.String(maxLength: 50, unicode: false));
            DropColumn("dbo.Domains", "DomainName");
        }
    }
}
