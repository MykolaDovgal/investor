using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Investor.ViewModel
{
    public class UserDescriptionViewModel
    {
        [Required]
        public string Id { get; set; }
        [StringLength(10)]
        [Required]
        public string Description { get; set; }
        public string Photo { get; set; }
        public List<int> CropPoints { get; set; }
        [Url]
        public List<string> Socials { get; set; }
    }
}
