using Investor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Service.Utils.Interfaces
{
    public interface IImagePathService
    {
        string GetImagePath(string imageName, int id, string prefix = "");
        string GetAccountImagePath(string imageName, string prefix = "small-");
    }
}
