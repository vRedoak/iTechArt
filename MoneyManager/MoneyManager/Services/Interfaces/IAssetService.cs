using MoneyManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public interface IAssetService
    {
        Asset GetAsset(int id);
        IEnumerable<Asset> GetList();
        void Add(Asset item);
        void Update(Asset item);
        void Remove(int id);
        void Save();
        Task<Asset> GetAssetAsync(int id);
        Task<IEnumerable<Asset>> GetListAsync();
        Task AddAsync(Asset item);
        Task UpdateAsync(Asset item);
        Task RemoveAsync(int id);
        Task SaveAsync();
    }
}
