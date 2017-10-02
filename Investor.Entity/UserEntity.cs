using Microsoft.AspNetCore.Identity;


namespace Investor.Entity
{
    public class UserEntity : IdentityUser
    {
        public string Name { get; set; }      
    }
}
