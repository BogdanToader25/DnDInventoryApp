using DnDInventoryApp.Models;
using DnDInventoryApp.Repositories;

namespace DnDInventoryApp.Services
{
    public class AccountService
    {
        private IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public bool LoginUser(LoginModel loginModel)
        {
            var user = _userRepository.GetByUsername(loginModel.UserName);
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}
