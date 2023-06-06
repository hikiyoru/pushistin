using pushistin.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace pushistin.Models {
    public interface IIdentityRepository {

        IQueryable<ApplicationUser> Users { get; }
        IQueryable<ApplicationRole> Roles { get; }
        IQueryable<IdentityUserRole<string>> UserRoles { get; }

        void SaveUser(ApplicationUser u);
        void CreateUser(ApplicationUser u);
        void DeleteUser(ApplicationUser u);

        void SaveRole(ApplicationUser u);
        void CreateRole(ApplicationUser u);
        void DeleteRole(ApplicationUser u);

        void SaveUserRole(ApplicationUser u);
        void CreateUserRole(ApplicationUser u);
        void DeleteUserRole(ApplicationUser u);

    }
}
