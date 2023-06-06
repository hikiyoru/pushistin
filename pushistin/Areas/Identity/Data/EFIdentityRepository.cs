using pushistin.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace pushistin.Models {
    public class EFIdentityRepository : IIdentityRepository {
        private ApplicationDbContext context;

        public EFIdentityRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IQueryable<ApplicationUser> Users => context.Users;
        public IQueryable<ApplicationRole> Roles => (IQueryable<ApplicationRole>)context.Roles;

        public IQueryable<IdentityUserRole<string>> UserRoles => (IQueryable<IdentityUserRole<string>>)context.UserRoles;

        public void CreateUser(ApplicationUser u) {
            context.Add(u);
            context.SaveChanges();
        }

        public void DeleteUser(ApplicationUser u) {
            context.Remove(u);
            context.SaveChanges();
        }

        public void SaveUser(ApplicationUser u) {
            context.SaveChanges();
        }

        public void CreateRole(ApplicationUser u)
        {
            context.Add(u);
            context.SaveChanges();
        }

        public void DeleteRole(ApplicationUser u)
        {
            context.Remove(u);
            context.SaveChanges();
        }

        public void SaveRole(ApplicationUser u)
        {
            context.SaveChanges();
        }
        public void CreateUserRole(ApplicationUser u)
        {
            context.Add(u);
            context.SaveChanges();
        }

        public void DeleteUserRole(ApplicationUser u)
        {
            context.Remove(u);
            context.SaveChanges();
        }

        public void SaveUserRole(ApplicationUser u)
        {
            context.SaveChanges();
        }
    }
}
