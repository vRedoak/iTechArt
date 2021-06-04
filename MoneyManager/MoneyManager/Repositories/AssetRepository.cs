using MoneyManager.Models;
using System;
using System.Collections.Generic;

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

        public void Delete(int id)
        {
            var asset = _db.Assets.Find(id);
            if (asset != null)
                _db.Assets.Remove(asset);
        }

        public IEnumerable<Asset> GetList()
        {
            return _db.Assets;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Asset item)
        {
            _db.Assets.Update(item);
        }
    }
}
