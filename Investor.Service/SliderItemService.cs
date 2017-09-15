using Investor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Entity;
using System.Threading.Tasks;
using Investor.Repository.Interfaces;
using Investor.Model;
using AutoMapper;
using System.Linq;

namespace Investor.Service
{
    public class SliderItemService : ISliderItemService
    {
        private ISliderItemRepository _sliderItemRepository;
        public SliderItemService(ISliderItemRepository sliderItemRepository)
        {
            _sliderItemRepository = sliderItemRepository;
        }
        public async Task<SliderItem> AddSliderItemAsync(SliderItem sliderItem)
        {
            var result = await _sliderItemRepository.AddSliderItemAsync(Mapper.Map<SliderItem, SliderItemEntity>(sliderItem));
            sliderItem.SliderItemId = result.SliderItemId;
            return sliderItem;
        }

        public async Task<IEnumerable<SliderItem>> GetAllSliderItemsAsync()
        {
            var sliderItems = await _sliderItemRepository.GetAllSliderItemsAsync();
            return sliderItems.Select(Mapper.Map<SliderItemEntity, SliderItem>);
        }

        public async Task<SliderItem> GetSliderItemByIdAsync(int id)
        {
            return Mapper.Map<SliderItemEntity, SliderItem>(await _sliderItemRepository.GetSliderItemByIdAsync(id));
        }

        public async Task RemoveSliderItemAsync(int id)
        {
            await _sliderItemRepository.RemoveSliderItemAsync(id);
        }

        public async Task UpdateSliderItemAsync(SliderItem sliderItem)
        {
            await _sliderItemRepository.UpdateSliderItemAsync(Mapper.Map < SliderItem, SliderItemEntity > (sliderItem));
        }
    }
}
