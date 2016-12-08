namespace Training.Programming.FinalTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Name", c => c.String());
            AddColumn("dbo.Clients", "Surname", c => c.String());
            AddColumn("dbo.Clients", "SocialSecurityNumber", c => c.String());
            AddColumn("dbo.Clients", "Sex", c => c.Int(nullable: false));
            AddColumn("dbo.Policies", "PolicyNumber", c => c.String());
            AddColumn("dbo.Policies", "Premium", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Policies", "State", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Name", c => c.String());
            AddColumn("dbo.Products", "CreatedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "Premium", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Clients", "ClientSsn");
            DropColumn("dbo.Clients", "ClientSex");
            DropColumn("dbo.Policies", "PolicyState");
            DropColumn("dbo.Products", "ProductName");
            DropColumn("dbo.Products", "ProductPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "ProductName", c => c.String());
            AddColumn("dbo.Policies", "PolicyState", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "ClientSex", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "ClientSsn", c => c.String());
            DropColumn("dbo.Products", "Premium");
            DropColumn("dbo.Products", "CreatedDateTime");
            DropColumn("dbo.Products", "Name");
            DropColumn("dbo.Policies", "State");
            DropColumn("dbo.Policies", "Premium");
            DropColumn("dbo.Policies", "PolicyNumber");
            DropColumn("dbo.Clients", "Sex");
            DropColumn("dbo.Clients", "SocialSecurityNumber");
            DropColumn("dbo.Clients", "Surname");
            DropColumn("dbo.Clients", "Name");
        }
    }
}
