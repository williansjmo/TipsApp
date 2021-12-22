using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tips.Domain.Entities;
using Tips.Domain.Interfaces;

namespace Tips.Domain.Services
{
    public class TipsService : IGenericRepository<Tip>
    {
        private readonly IDatabaseContext context;

        public TipsService(IDatabaseContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddAsync(Tip entity)
        {
            try
            {
               await context.SaveItemAsync(entity,true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(object Id)
        {
            try
            {
                var entity = await GetAsync(Id);
                await context.DeleteItemAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Tip>> GetAllAsync()
        {
            try
            {
                return await context.GetItemsAsync<Tip>();
            }
            catch (Exception ex)
            {
                return new List<Tip>();
            }
        }

        public async Task<Tip> GetAsync(object Id)
        {
            try
            {
                return await context.GetItemAsync<Tip>(Id);
            }
            catch (Exception ex)
            {
                return new Tip();
            }
        }

        public async Task<bool> UpdateAsync(Tip entity)
        {
            try
            {
                entity.UpdateDate = DateTime.Now;
                await context.SaveItemAsync(entity, false);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
