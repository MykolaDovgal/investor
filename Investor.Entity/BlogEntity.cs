using System.ComponentModel.DataAnnotations.Schema;

namespace Investor.Entity
{
    public class BlogEntity : PostEntity
    {
        public string AuthorId { set; get; }

        [ForeignKey("AuthorId")]
        public UserEntity Author { set; get; }
    }
}
