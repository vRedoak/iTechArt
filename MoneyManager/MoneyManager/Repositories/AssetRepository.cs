using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    class AssetRepository : IAssetRepository
    {
        private readonly MoneyManagerContext _db;

        public AssetRepository(MoneyManagerContext context)
        {
            _db = context;
        }

        public void Create(Asset item)
        {
            _db.Assets.Add(item);
        }

        public async Task CreateAsync(Asset item)
        {
            await _db.Assets.AddAsync(item);
        }

        public void Delete(int id)
        {
            var asset = _db.Assets.Find(id);
            if (asset != null)
                _db.Assets.Remove(asset);
        }

        public async Task DeleteAsync(int id)
        {
            var asset = await _db.Assets.FindAsync(id);
            if (asset != null)
                _db.Assets.Remove(asset);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<Asset> GetList()
        {
            return _db.Assets.AsQueryable();
        }

        public async Task<IEnumerable<Asset>> GetListAsync()
        {
            return await _db.Assets.ToListAsync();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Update(Asset item)
        {
            _db.Assets.Update(item);
        }

        public async Task UpdateAsync(Asset item)
        {
            _db.Assets.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}
