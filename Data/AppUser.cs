using System.ComponentModel.DataAnnotations;

namespace DnDInventoryApp.Data
{
    public class AppUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public byte[] Salt { get; set; }
        public List<string> RoleList
        {
            get
            {
                return Roles?.Split(',').ToList() ?? new List<string>();
            }
        }
    }
}
