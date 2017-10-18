using Investor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Investor.Repository
{
    public class SliderItemRepository : ISliderItemRepository
    {
        private readonly NewsContext _newsContext;

        public SliderItemRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
            
        }
        public async Task<IEnumerable<SliderItemEntity>> GetAllSliderItemsAsync()
        {
            return await _newsContext
                .SliderItems
                .Include(s=>s.Post)
                .ToListAsync();
        }

        public async Task<SliderItemEntity> GetSliderItemByIdAsync(int id)
        {
            return await _newsContext
                .SliderItems
                .Include(s => s.Post)
                .FirstOrDefaultAsync(s => s.SliderItemId == id);
                
        }

        public async Task<SliderItemEntity> AddSliderItemAsync(SliderItemEntity sliderItem)
        {
            await _newsContext
                .SliderItems
                .AddAsync(sliderItem);
            await _newsContext.SaveChangesAsync();

            return sliderItem;
        }

        public async Task RemoveSliderItemAsync(int id)
        {
            SliderItemEntity sliderItemToRemove = await _newsContext
                .SliderItems
                .FindAsync(id);

            _newsContext
                .SliderItems
                .Remove(sliderItemToRemove);

            await _newsContext.SaveChangesAsync();
        }

        public async Task UpdateSliderItemAsync(SliderItemEntity sliderItem)
        {
            _newsContext
                .SliderItems
                .Update(sliderItem);

            await _newsContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SliderItemEntity>> GetSideSliderItemsAsync()
        {
            var sliderItems = await _newsContext
               .SliderItems
               .Include(s => s.Post)
               .ToListAsync();
            return sliderItems.Where(s => s.IsOnSide == true);
                
        }

        public async Task<IEnumerable<SliderItemEntity>> GetCentralSliderItemsAsync()
        {
            var sliderItems = await _newsContext
               .SliderItems
               .Include(s => s.Post)
               .ToListAsync();

            return sliderItems.Where(s => s.IsOnSlider == true);
        }

        public async Task<SliderItemEntity> GetSliderItemByPostIdAsync(int PostId)
        {
            return await _newsContext
                .SliderItems
                .FirstOrDefaultAsync(s => s.PostId == PostId);
        }
    }
}
