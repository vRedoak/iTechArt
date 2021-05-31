using System;
using System.Collections.Generic;
using System.Linq;
using MoneyManager.Repositories;

namespace MoneyManager.Services
{
    class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;

        public AssetService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public Asset GetAsset(int id)
        {
            return _assetRepository.GetList().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Add(Asset asset)
        {
            _assetRepository.Create(asset);
        }

        public void Remove(int id)
        {
            _assetRepository.Delete(id);
        }

        public void Update(Asset asset)
        {
            _assetRepository.Update(asset);
        }

        public IEnumerable<Asset> GetList()
        {
            return _assetRepository.GetList();
        }

        public void Save()
        {
            _assetRepository.Save();
        }
    }
}
