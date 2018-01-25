using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.ViewModel
{
    public class UserPasswordChangeViewModel
    {
        public string Id { get; set; }
        public string OldPassword { get; set; }
        public string OldConfirmedPassword { get; set; }
        public string NewPassword { set; get; }   
    }
}
