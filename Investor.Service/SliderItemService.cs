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
        private readonly ISliderItemRepository _sliderItemRepository;
        private readonly IPostRepository _postRepository;
        private int _sideSliderItemsCount = 2;
        private int _centralSliderItemsCount = 2;
        public SliderItemService(ISliderItemRepository sliderItemRepository, IPostRepository postRepository)
        {
            _sliderItemRepository = sliderItemRepository;
            _postRepository = postRepository;
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

        public async Task<IEnumerable<SliderItem>> GetCentralSliderItemsAsync()
        {
            var slideItems = (await _sliderItemRepository
                .GetCentralSliderItemsAsync())
                .Select(Mapper.Map<SliderItemEntity, SliderItem>);

            if (slideItems.Count() > _centralSliderItemsCount)
                slideItems.Take(_centralSliderItemsCount);
            else if (slideItems.Count() < _centralSliderItemsCount)
            {
                var sidePosts = (await _postRepository
                     .GetLatestPostsAsync(_centralSliderItemsCount - slideItems.Count()))
                     .Select(Mapper.Map<PostEntity, PostPreview>);

                for (int i = 0; slideItems.Count() <= 2; i++)
                {
                    SliderItem sliderItem = new SliderItem() { Post = sidePosts.ToList()[i], IsOnSide = true };
                    slideItems.ToList().Add(await this.AddSliderItemAsync(sliderItem));
                }
            }
            return slideItems;
        }

        public async Task<IEnumerable<SliderItem>> GetSideSliderItemsAsync()
        {
            var sideItems = (await _sliderItemRepository
                .GetSideSliderItemsAsync())
                .Select(Mapper.Map<SliderItemEntity, SliderItem>);

            if (sideItems.Count() > _sideSliderItemsCount)
                return sideItems.Take(_sideSliderItemsCount);
            if (sideItems.Count() < _sideSliderItemsCount)
            {
               var sidePosts = (await _postRepository
                    .GetLatestPostsAsync(_sideSliderItemsCount - sideItems.Count()))
                    .Select(Mapper.Map<PostEntity, PostPreview>);

                for (int i = 0; sideItems.Count() <= 2; i++)
                {
                    SliderItem sliderItem = new SliderItem() { Post = sidePosts.ToList()[i], IsOnSide = true };
                    sideItems.ToList().Add(sliderItem);
                }
            }
            return sideItems;
        }

        public async Task<SliderItem> GetSliderItemByIdAsync(int id)
        {
            return Mapper.Map<SliderItemEntity, SliderItem>(await _sliderItemRepository.GetSliderItemByIdAsync(id));
        }

        public async Task<SliderItem> GetSliderItemByPostIdAsync(int postId)
        {
            return Mapper.Map<SliderItemEntity, SliderItem>( await _sliderItemRepository.GetSliderItemByPostIdAsync(postId));
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
