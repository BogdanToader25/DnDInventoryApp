using DnDInventoryApp.Data;
using DnDInventoryApp.Models;
using DnDInventoryApp.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace DnDInventoryApp.Services
{
    public class AccountService
    {
        
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public bool LoginUser(LoginModel loginModel)
        {
            var user = _userRepository.GetByUsername(loginModel.UserName);
            if (user == null || !VerifyPassword(loginModel.Password, user.Password, user.Salt))
            {
                return false;
            }
            
            return true;
        }

        public bool RegisterUser(RegisterModel registerModel)
        {
            try
            {
                byte[] salt;
                var hashedPassowrd = HashPaswordForRegister(registerModel.Password, out salt);

                var newUser = new AppUser()
                {
                    Username = registerModel.UserName,
                    Password = hashedPassowrd,
                    Salt = salt,
                    Roles = "Player"
                };

                _userRepository.Add(newUser);
                return true;
            }
            catch
            {
                throw;
            }
        }

        bool VerifyPassword(string loginPassword, string userPassword, byte[] salt)
        {
            var saltedPassword = HashPaswordForLogin(loginPassword, salt);
            return saltedPassword == userPassword;
        }


        string HashPaswordForRegister(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }

        string HashPaswordForLogin(string password, byte[] salt)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }
    }
}
