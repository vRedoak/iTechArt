using MoneyManager.Models;
using System.Collections.Generic;

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
