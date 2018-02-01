using System.ComponentModel.DataAnnotations;
using Investor.ViewModel.Attributes;

namespace Investor.ViewModel
{
    public class UserPersonalDataViewModel
    {
        public string Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailCheck]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [NicknameCheck]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
    }
}
