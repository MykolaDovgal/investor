using System;
using System.IO;
using Investor.Service.Utils.Interfaces;

namespace Investor.Service.Utils
{
    public class ImagePathService : IImagePathService
    {
        //private readonly IPostRepository _postRepository;
        public ImagePathService()
        {
            //_postRepository = postRepository;
        }
        public string GetImagePath(string imageName, int id, string prefix = "")
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                return $"img/posts/{Path.GetFileNameWithoutExtension(imageName)}/{prefix}{imageName}";
            }

            return "img/no-img/no-img-policy.png";
            //PostEntity post = _postRepository.GetPostByIdAsync<PostEntity>(id).Result;

            //return post == null ? $"img/no-img/no-img.png" : $"img/no-img/no-img-{post.Category.Url}.png";
        }

        public string GetAccountImagePath(string imageName, string prefix = "small-")
        {
            return String.IsNullOrEmpty(imageName) ? $"img/no-img/no-img-user.png" : $"img/accounts/{Path.GetFileNameWithoutExtension(imageName)}/{prefix}{imageName}";
        }
    }
}
