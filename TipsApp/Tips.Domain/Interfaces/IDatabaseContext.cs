using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tips.Domain.Interfaces
{
    public interface IDatabaseContext
    {
        Task<List<T>> GetItemsAsync<T>() where T : new();
        Task<List<T>> FilterItemsAsync<T>(string table, string condition) where T : new();
        Task<T> GetItemAsync<T>(object id) where T : new();
        Task<int> SaveItemAsync<T>(T item, bool isInsert) where T : new();
        Task<int> DeleteItemAsync<T>(T item) where T : new();
    }
}
