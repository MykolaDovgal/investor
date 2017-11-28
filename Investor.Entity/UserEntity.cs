using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace Investor.Entity
{
    public class UserEntity : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string SerializedSocials { get; set; }
        public List<BlogEntity> Blogs { get; set; }
        public string SerializedCropPoints { get; set; }
        public UserEntity()
        {
            Blogs = new List<BlogEntity>();
        }
    }
}
