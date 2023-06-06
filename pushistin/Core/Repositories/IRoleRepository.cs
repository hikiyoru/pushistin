using pushistin.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace pushistin.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
