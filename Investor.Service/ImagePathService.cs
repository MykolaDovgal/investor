using Investor.Entity;
using Investor.Model;
using Investor.Repository;
using Investor.Repository.Interfaces;
using Investor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Service
{
    public class ImagePathService : IImagePathService
    {
        IPostRepository _postRepository;
        public ImagePathService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public string GetImagePath(string imageName, int id, string prefix = "")
        {
            if (String.IsNullOrEmpty(imageName))
            {
                var post = _postRepository.GetPostByIdAsync<PostEntity>(id).Result;
                return $"img/no-img/no-img-{post.Category.Url}.png";
            }
            return $"img/posts/{Path.GetFileNameWithoutExtension(imageName)}/{prefix}{imageName}";
        }

        public string GetAccountImagePath(string imageName, string prefix = "small-")
        {
            return String.IsNullOrEmpty(imageName) ? $"img/no-img/no-img-user.png" : $"img/accounts/{Path.GetFileNameWithoutExtension(imageName)}/{prefix}{imageName}";
        }
    }
}
