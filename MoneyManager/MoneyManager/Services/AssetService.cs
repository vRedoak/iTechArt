using MoneyManager.Models;
using MoneyManager.Repositories;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                return _assetRepository.GetList().Where(x => x.Id == id).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public void Add(Asset item)
        {
            try
            {
                _assetRepository.Create(item);
            }
            catch
            {
                throw;
            }
        }

        public void Remove(int id)
        {
            try
            {
                _assetRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Asset item)
        {
            try
            {
                _assetRepository.Update(item);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Asset> GetList()
        {
            try
            {
                return _assetRepository.GetList();
            }
            catch
            {
                throw;
            }
        }

        public void Save()
        {
            try
            {
                _assetRepository.Save();
            }
            catch
            {
                throw;
            }
        }
    }
}
