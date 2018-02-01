using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace Investor.ViewModel
{
    public class UserDescriptionViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string Photo { get; set; }
        public List<int> CropPoints { get; set; }
        public List<string> Socials { get; set; }
    }
}
