using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    class AssetRepository : IRepository<Asset>, IAssetRepository
    {
        private MoneyManagerContext db;

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
            Asset asset = db.Assets.Find(id);
            if (asset != null)
                db.Assets.Remove(asset);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
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
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
