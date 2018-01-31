namespace Investor.Service.Utils.Interfaces
{
    public interface IImagePathService
    {
        string GetImagePath(string imageName, int id, string prefix = "");
        string GetAccountImagePath(string imageName, string prefix = "small-");
    }
}
