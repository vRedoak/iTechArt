using System;
using System.Collections.Generic;
using System.Linq;
using MoneyManager.Repositories;
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
    }
}
