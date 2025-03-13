using System.Threading.Tasks;
using eCommerce.Core.Entities.ApplicationUser;

namespace eCommerce.Core.RepositoryContracts
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> AddUserAsync(User user);
        Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
