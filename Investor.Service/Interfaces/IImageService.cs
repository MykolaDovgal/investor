using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Investor.Service.Interfaces
{
    public interface IImageService
    {
        string SaveImage(IFormFile file);
        string SaveAccountImage(IFormFile file, List<int> points);
        string CropExistingImage(string imageName, List<int> points);
    }
}
