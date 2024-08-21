using Microsoft.AspNetCore.Mvc;

namespace ECommerceAppusingDotnetcore.Models
{
    public class User
    {
        public int Id {  get; set; }
        [Remote(action:"CheckExistingEmailId",controller:"Auth")]
        public string Email { get; set; }
        public string Username { get; set; }       
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
