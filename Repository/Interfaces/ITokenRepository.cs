using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Repository.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
