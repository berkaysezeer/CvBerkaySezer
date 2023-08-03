namespace CvBerkaySezer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class domain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Domains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(nullable: false, maxLength: 256, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RegistrationDate = c.DateTime(nullable: false),
                        NextPaymentDate = c.DateTime(nullable: false),
                        UserName = c.String(maxLength: 50, unicode: false),
                        HostUrl = c.String(maxLength: 100, unicode: false),
                        ClientId = c.Int(nullable: false),
                        ServiceProviderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceProviders", t => t.ServiceProviderId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ServiceProviderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Domains", "ServiceProviderId", "dbo.ServiceProviders");
            DropForeignKey("dbo.Domains", "ClientId", "dbo.Clients");
            DropIndex("dbo.Domains", new[] { "ServiceProviderId" });
            DropIndex("dbo.Domains", new[] { "ClientId" });
            DropTable("dbo.Domains");
        }
    }
}
