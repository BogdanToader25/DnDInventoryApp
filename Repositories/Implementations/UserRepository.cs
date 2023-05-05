using DnDInventoryApp.Data;

namespace DnDInventoryApp.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(AppUser item)
        {
            _context.AppUsers.Add(item);
        }

        public void Delete(int id)
        {
            _context.Remove(id);
        }

        public void Update(AppUser entity)
        {
            _context.Update(entity);
        }

        public AppUser Get(int id)
        {
            return _context.AppUsers.Where(x => x.UserId == id).FirstOrDefault();
        }

        public IEnumerable<AppUser> GetAll()
        {
            return _context.AppUsers;
        }

        public AppUser GetByUsername(string username)
        {
            return _context.AppUsers.Where(x => x.Username == username).FirstOrDefault();
        }
    }
}
