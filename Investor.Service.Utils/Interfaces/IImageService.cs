using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Investor.Service.Utils.Interfaces
{
    public interface IImageService
    {
        string SaveImage(IFormFile file);
        string SaveAccountImage(IFormFile file, List<int> points);
        string CropExistingImage(string imageName, List<int> points);
    }
}
