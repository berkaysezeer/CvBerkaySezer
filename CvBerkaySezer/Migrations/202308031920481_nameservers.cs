namespace CvBerkaySezer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameservers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Domains", "NameServer1", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.Domains", "NameServer2", c => c.String(maxLength: 100, unicode: false));
            DropColumn("dbo.Domains", "HostUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Domains", "HostUrl", c => c.String(maxLength: 100, unicode: false));
            DropColumn("dbo.Domains", "NameServer2");
            DropColumn("dbo.Domains", "NameServer1");
        }
    }
}
