using System;
using System.Collections.Generic;

namespace MoneyManager.Repositories
{
    class AssetRepository : IRepository<Asset>, IAssetRepository
    {
        private readonly MoneyManagerContext db;

        public AssetRepository(MoneyManagerContext context)
        {
            db = context;
        }

        public void Create(Asset item)
        {
            db.Assets.Add(item);
        }

        public void Delete(int id)
        {
            var asset = db.Assets.Find(id);
            if (asset != null)
                db.Assets.Remove(asset);
        }

        public IEnumerable<Asset> GetList()
        {
            return db.Assets;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Asset item)
        {
            db.Assets.Update(item);
        }
    }
}
