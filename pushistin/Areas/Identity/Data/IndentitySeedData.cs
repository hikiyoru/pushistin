using Microsoft.EntityFrameworkCore;

namespace pushistin.Areas.Identity.Data
{

    public static class IdentitySeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            string AdminRoleId = Guid.NewGuid().ToString();

            string User1Id = Guid.NewGuid().ToString();


            if (!context.Users.Any() && !context.Roles.Any())
            {
                context.Roles.AddRange(
                    new ApplicationRole
                    {
                        Id = AdminRoleId,
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR",
                        ConcurrencyStamp = null
                    });

                context.Users.AddRange(

                    new ApplicationUser
                    {
                        Id = User1Id,
                        UserName = "yokutorri",
                        NormalizedUserName = "YOKUTORRI",
                        Email = "uglotov18@gmail.com",
                        NormalizedEmail = "UGLOTOV18@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = "AQAAAAIAAYagAAAAEFMgPQaRrKt+TLDXDc36kqY0jMQqVbsbaY7E0p5cawUPJbp1q4ubWOltWjQEcu+7oA==",
                        SecurityStamp = "FVCYP2R5DIJ4K75TI7TJVNDSKKOSMMIL",
                        ConcurrencyStamp = "cbd57b1b-d909-483b-a314-bbab7754d3b7",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    });
                context.UserRoles.Add(
                    new Microsoft.AspNetCore.Identity.IdentityUserRole<string>
                    {
                        UserId = User1Id,
                        RoleId = AdminRoleId
                    });
                context.SaveChanges();
            }
        }
    }
}
