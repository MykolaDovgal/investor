namespace Investor.Model
{
    public class PopularUser
    {
        public User User { set; get; }
        public BlogPreview LatestBlog { set; get; }
        public int NumberOfPosts { set; get; }
    }
}
