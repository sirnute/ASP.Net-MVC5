namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'323645b5-6822-46ce-9347-ddc15ea75253', N'admin@vidly.com', 0, N'AKb9oYhDTWYbyqTUGx4XtLf27tK2h/MrmtpBfnxujdTCFf/1GPzV9h4ZG+YRRiTEVQ==', N'91ef98b2-59bc-4f30-a027-1311d9b7fb52', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'558af589-7efe-415d-9a68-392e9d2f850b', N'nuteempire@gmail.com', 0, N'AK4jq7OLnyhcx5i7FBnJyGALqgLipeWa4HoE9UGgphLrtkX3tbDla6SZF4UGQQPTZA==', N'7e655d27-ebf6-4bfb-9603-3cd63c006ca9', NULL, 0, 0, NULL, 1, 0, N'nuteempire@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7dd0e67e-bc7a-4521-877e-74800f00b851', N'canManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'323645b5-6822-46ce-9347-ddc15ea75253', N'7dd0e67e-bc7a-4521-877e-74800f00b851')


");
        }
        
        public override void Down()
        {
        }
    }
}
