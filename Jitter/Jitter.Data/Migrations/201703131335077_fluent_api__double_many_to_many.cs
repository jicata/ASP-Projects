namespace Jitter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluent_api__double_many_to_many : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jeets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(maxLength: 128),
                        Content = c.String(maxLength: 160),
                        PostedOn = c.DateTime(),
                        Reported = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.AspNetUsers",
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.String(maxLength: 128),
                        RecieverId = c.String(maxLength: 128),
                        Content = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RecieverId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.SenderId)
                .Index(t => t.RecieverId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserFollowedBy",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FollowerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.FollowerId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .Index(t => t.UserId)
                .Index(t => t.FollowerId);
            
            CreateTable(
                "dbo.UserFollowing",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FollowingId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.FollowingId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.FollowingId)
                .Index(t => t.UserId)
                .Index(t => t.FollowingId);
            
            CreateTable(
                "dbo.UsersFavoriteJeets",
                c => new
                    {
                        JeetFavoritedId = c.Int(nullable: false),
                        UserFavoriterId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.JeetFavoritedId, t.UserFavoriterId })
                .ForeignKey("dbo.Jeets", t => t.JeetFavoritedId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserFavoriterId, cascadeDelete: true)
                .Index(t => t.JeetFavoritedId)
                .Index(t => t.UserFavoriterId);
            
            CreateTable(
                "dbo.UsersRejeetedJeets",
                c => new
                    {
                        JeetRejeetedId = c.Int(nullable: false),
                        UserRejeeterId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.JeetRejeetedId, t.UserRejeeterId })
                .ForeignKey("dbo.Jeets", t => t.JeetRejeetedId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserRejeeterId, cascadeDelete: true)
                .Index(t => t.JeetRejeetedId)
                .Index(t => t.UserRejeeterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UsersRejeetedJeets", "UserRejeeterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersRejeetedJeets", "JeetRejeetedId", "dbo.Jeets");
            DropForeignKey("dbo.UsersFavoriteJeets", "UserFavoriterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersFavoriteJeets", "JeetFavoritedId", "dbo.Jeets");
            DropForeignKey("dbo.Jeets", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "RecieverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserFollowing", "FollowingId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserFollowing", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserFollowedBy", "FollowerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserFollowedBy", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UsersRejeetedJeets", new[] { "UserRejeeterId" });
            DropIndex("dbo.UsersRejeetedJeets", new[] { "JeetRejeetedId" });
            DropIndex("dbo.UsersFavoriteJeets", new[] { "UserFavoriterId" });
            DropIndex("dbo.UsersFavoriteJeets", new[] { "JeetFavoritedId" });
            DropIndex("dbo.UserFollowing", new[] { "FollowingId" });
            DropIndex("dbo.UserFollowing", new[] { "UserId" });
            DropIndex("dbo.UserFollowedBy", new[] { "FollowerId" });
            DropIndex("dbo.UserFollowedBy", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropIndex("dbo.Messages", new[] { "RecieverId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Jeets", new[] { "AuthorId" });
            DropTable("dbo.UsersRejeetedJeets");
            DropTable("dbo.UsersFavoriteJeets");
            DropTable("dbo.UserFollowing");
            DropTable("dbo.UserFollowedBy");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Messages");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Jeets");
        }
    }
}
