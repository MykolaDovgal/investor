namespace Investor.Entity
{
    public class NewsEntity : PostEntity
    {
        public bool? IsOnMainPage { set; get; }
        public bool? IsImportant { set; get; }
        public bool? IsOnSlider { set; get; }
        public bool? IsOnSide { set; get; }

        public NewsEntity() : base()
        { }
    }
}
