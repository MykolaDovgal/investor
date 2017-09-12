using Investor.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Repository.Interfaces
{
    public interface ISliderItemRepository
    {
        Task<IEnumerable<SliderItemEntity>> GetAllSliderItemsAsync();
        Task<SliderItemEntity> GetSliderItemByIdAsync(int id);

        Task<SliderItemEntity> AddSliderItemAsync(SliderItemEntity sliderItem);
        Task UpdateSliderItemAsync(SliderItemEntity sliderItem);
        Task RemoveSliderItemAsync(int id);

    }
}
