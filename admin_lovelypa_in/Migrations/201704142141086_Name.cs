namespace admin_lovelypa_in.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MPA_ADMIN_ROLES",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.MPA_ADMIN_USER_ROLES",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.MPA_ADMIN_ROLES", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.MPA_ADMIN_USERS", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.MPA_ADMIN_USERS",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.MPA_ADMIN_USER_CLAIMS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MPA_ADMIN_USERS", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.MPA_ADMIN_USER_LOGINS",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.MPA_ADMIN_USERS", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MPA_ADMIN_USER_ROLES", "IdentityUser_Id", "dbo.MPA_ADMIN_USERS");
            DropForeignKey("dbo.MPA_ADMIN_USER_LOGINS", "IdentityUser_Id", "dbo.MPA_ADMIN_USERS");
            DropForeignKey("dbo.MPA_ADMIN_USER_CLAIMS", "IdentityUser_Id", "dbo.MPA_ADMIN_USERS");
            DropForeignKey("dbo.MPA_ADMIN_USER_ROLES", "RoleId", "dbo.MPA_ADMIN_ROLES");
            DropIndex("dbo.MPA_ADMIN_USER_LOGINS", new[] { "IdentityUser_Id" });
            DropIndex("dbo.MPA_ADMIN_USER_CLAIMS", new[] { "IdentityUser_Id" });
            DropIndex("dbo.MPA_ADMIN_USERS", "UserNameIndex");
            DropIndex("dbo.MPA_ADMIN_USER_ROLES", new[] { "IdentityUser_Id" });
            DropIndex("dbo.MPA_ADMIN_USER_ROLES", new[] { "RoleId" });
            DropIndex("dbo.MPA_ADMIN_ROLES", "RoleNameIndex");
            DropTable("dbo.MPA_ADMIN_USER_LOGINS");
            DropTable("dbo.MPA_ADMIN_USER_CLAIMS");
            DropTable("dbo.MPA_ADMIN_USERS");
            DropTable("dbo.MPA_ADMIN_USER_ROLES");
            DropTable("dbo.MPA_ADMIN_ROLES");
        }
    }
}
