using DnDInventoryApp.Data;

namespace DnDInventoryApp.Repositories
{
    public interface IUserRepository : IRepository<AppUser>
    {

        AppUser GetByUsername(string username);

    }
}
