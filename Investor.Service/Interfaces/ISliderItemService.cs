using Investor.Entity;
using Investor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Service.Interfaces
{
    public interface ISliderItemService
    {
        Task<IEnumerable<SliderItem>> GetAllSliderItemsAsync();
        Task<SliderItem> GetSliderItemByIdAsync(int id);
        Task<IEnumerable<SliderItem>> GetSideSliderItemsAsync();
        Task<IEnumerable<SliderItem>> GetCentralSliderItemsAsync();
        Task<SliderItem> GetSliderItemByPostIdAsync(int postId);

        Task<SliderItem> AddSliderItemAsync(SliderItem sliderItem);
        Task UpdateSliderItemAsync(SliderItem sliderItem);
        Task RemoveSliderItemAsync(int id);
    }
}
