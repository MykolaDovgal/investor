using Investor.Entity;
using Investor.Model;
using Investor.Repository;
using Investor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Investor.Service.Utils.Interfaces;

namespace Investor.Service.Utils
{
    public class ImagePathService : IImagePathService
    {
        private readonly IPostRepository _postRepository;
        public ImagePathService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public string GetImagePath(string imageName, int id, string prefix = "")
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                return $"img/posts/{Path.GetFileNameWithoutExtension(imageName)}/{prefix}{imageName}";
            }

            PostEntity post = _postRepository.GetPostByIdAsync<PostEntity>(id).Result;
            
            return post == null ? $"img/no-img/no-img.png" : $"img/no-img/no-img-{post.Category.Url}.png";
        }

        public string GetAccountImagePath(string imageName, string prefix = "small-")
        {
            return String.IsNullOrEmpty(imageName) ? $"img/no-img/no-img-user.png" : $"img/accounts/{Path.GetFileNameWithoutExtension(imageName)}/{prefix}{imageName}";
        }
    }
}
