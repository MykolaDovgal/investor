using Investor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Investor.Repository
{
    class SliderItemRepository : ISliderItemRepository
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
    }
}
