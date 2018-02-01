using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Investor.ViewModel.Attributes;

namespace Investor.ViewModel
{
    public class RegisterViewModel
    {
        [NicknameCheck]
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [EmailCheck]
        [StringLength(50)]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Required]
        public string PasswordConfirm { get; set; }
        [StringLength(50)]
        [Required]
        public string Surname { get; set; }
        [StringLength(700)]
        [Required]
        public string Description { get; set; }
        public string Photo { get; set; }
        public List<string> Socials { get; set; }
        public List<int> CropPoints { get; set; }
    }
}
