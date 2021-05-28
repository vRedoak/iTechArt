using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Asset Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Asset> GetList()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Asset item)
        {
            throw new NotImplementedException();
        }
    }
}
