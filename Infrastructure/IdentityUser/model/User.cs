using Domain.Entites;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace model
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AccountTypes AccountTypes { get; set; }
        public DateTime DateOfBirth { get; set; }

     





    }
}
