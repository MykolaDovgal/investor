using System.Text;
using System.Text.RegularExpressions;
using Investor.Model;
using UnidecodeSharpFork;

namespace Investor.Service.Utils
{
    public class UrlService
    {
        public string GetEncodedUrlString(string url)
        {
            return SimplifyString(Regex.Replace(url, @"\s+", "-").Unidecode()).ToLower();
        }

        private string SimplifyString(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '-')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public string GetPostRelativePath(News news)
        {
            return $"/{news.Category.Url}/{news.Url}-{news.PostId}";
        }

        public string GetPostRelativePath(Blog news)
        {
            return $"/{news.Category.Url}/{news.Url}-{news.PostId}";
        }

        public string GetPostRelativePath(PostPreview news)
        {
            return $"/{news.Category.Url}/{news.Url}-{news.PostId}";
        }

        public string GetPostRelativePath(BlogPreview news)
        {
            return $"/{(news.IsPublished ? "blog" : "unpublished")}/{news.Url}-{news.PostId}";
        }
    }
}
