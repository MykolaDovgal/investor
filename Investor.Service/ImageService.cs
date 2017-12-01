using System.IO;
using System.Text;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Investor.Service
{
    public class ImageService : IImageService
    {
        IHostingEnvironment _env;

        public ImageService(IHostingEnvironment env)
        {
            _env = env;
        }

        public string SaveImage(IFormFile image)
        {
            string imageExtension = Path.GetExtension(image.FileName);
            string originFileName = CreateMD5(image.FileName + image.Length);
            string fullOriginalFileName = originFileName + imageExtension;
            string imageFolderPath = Path.Combine(_env.WebRootPath, "img", "posts", originFileName);

            if (Directory.Exists(imageFolderPath))
            {
                foreach (string filePath in Directory.GetFiles(imageFolderPath))
                {
                    File.Delete(filePath);
                }
            }
            else
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            using (var stream = new FileStream(Path.Combine(imageFolderPath, fullOriginalFileName), FileMode.Create))
            {
                image.CopyTo(stream);
            }
            ResizeImage(imageFolderPath, fullOriginalFileName, "small-", new Size(104, 104));
            ResizeImage(imageFolderPath, fullOriginalFileName, "medium-", new Size(382, 208));
            ResizeImage(imageFolderPath, fullOriginalFileName, "large-", new Size(751, 423));

            return fullOriginalFileName;
        }
        public string SaveAccountImage(IFormFile image, List<int> points)
        {
            if (image != null && points?.Count != 0)
            {
                string imageExtension = Path.GetExtension(image.FileName);
                string originFileName = CreateMD5(image.FileName + image.Length);
                string fullOriginalFileName = originFileName + imageExtension;
                string imageFolderPath = Path.Combine(_env.WebRootPath, "img", "accounts", originFileName);

                if (Directory.Exists(imageFolderPath))
                {
                    foreach (string filePath in Directory.GetFiles(imageFolderPath))
                    {
                        File.Delete(filePath);
                    }
                }
                else
                {
                    Directory.CreateDirectory(imageFolderPath);
                }

                using (var stream = new FileStream(Path.Combine(imageFolderPath, fullOriginalFileName), FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                ResizeAccountImage(imageFolderPath, fullOriginalFileName, "small-", new Size(104, 104), points);
                return fullOriginalFileName;
            }
            return null;
        }
        public string CropExistingImage(string imageName, List<int> points)
        {
            if (!String.IsNullOrEmpty(imageName))
            {
                string originFileName = Path.GetFileNameWithoutExtension(imageName);
                string imageFolderPath = Path.Combine(_env.WebRootPath, "img", "accounts", originFileName);

                if (Directory.Exists(imageFolderPath))
                {
                    File.Delete(Path.Combine(imageFolderPath, "small-" + imageName));
                }
                else
                {
                    return null;
                }
                ResizeAccountImage(imageFolderPath, imageName, "small-", new Size(104, 104), points);
            }
            return imageName;
        }
        private void ResizeImage(string imageFolderPath, string originalImageName, string prefix, Size size)
        {
            using (var img = Image.Load(Path.Combine(imageFolderPath, originalImageName)))
            {
                img.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = size,
                    Mode = ResizeMode.Crop
                }));

                img.Save(Path.Combine(imageFolderPath, prefix + originalImageName));
            }
        }
        private void ResizeAccountImage(string imageFolderPath, string originalImageName, string prefix, Size size, List<int> points)
        {
            using (var img = Image.Load(Path.Combine(imageFolderPath, originalImageName)))
            {
                img.Mutate(x => x
                .Crop(new Rectangle(points[0], points[1], points[2] - points[0], points[3] - points[1]))
                .Resize(new ResizeOptions
                {
                    Size = size,
                }));

                img.Save(Path.Combine(imageFolderPath, prefix + originalImageName));
            }
        }
        private string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte t in hashBytes)
                {
                    sb.Append(t.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
