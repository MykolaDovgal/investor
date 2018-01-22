using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model.Views
{
    public class UserDescriptionViewModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public List<int> CropPoints { get; set; }
        public List<string> Socials { get; set; }
    }
}
