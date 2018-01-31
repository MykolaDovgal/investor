using System.Collections.Generic;

namespace Investor.ViewModel
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
