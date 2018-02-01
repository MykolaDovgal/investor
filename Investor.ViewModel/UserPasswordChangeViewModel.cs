using System.ComponentModel.DataAnnotations;
using Investor.ViewModel.Attributes;

namespace Investor.ViewModel
{
    public class UserPasswordChangeViewModel
    {
        public string Id { get; set; }
        [PasswordCheck]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string NewPassword { set; get; }
        [Compare("NewPassword")]
        [DataType(DataType.Password)]
        public string NewConfirmedPassword { set; get; }
    }
}
