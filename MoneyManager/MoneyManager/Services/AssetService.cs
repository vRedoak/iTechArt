using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;
using MoneyManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;

        public AssetService(UnitOfWork unitOfWork)
        {
            _assetRepository = unitOfWork.AssetRepository;
        }

        public Asset GetAsset(int id)
        {
            try
            {
                return _assetRepository.GetList().Where(x => x.Id == id).FirstOrDefault();
            }
            catch
            {
                Console.WriteLine("Error getting asset");
                throw;
            }
        }

        public async Task<Asset> GetAssetAsync(int id)
        {
            try
            {
                return await _assetRepository.GetList().AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch
            {
                Console.WriteLine("Error getting asset");
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
                Console.WriteLine("Error adding asset");
                throw;
            }
        }

        public async Task AddAsync(Asset item)
        {
            try
            {
                await _assetRepository.CreateAsync(item);
            }
            catch
            {
                Console.WriteLine("Error adding asset");
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
                Console.WriteLine("Error deleting asset");
                throw;
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                await _assetRepository.DeleteAsync(id);
            }
            catch
            {
                Console.WriteLine("Error deleting asset");
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
                Console.WriteLine("Error update asset");
                throw;
            }
        }

        public async Task UpdateAsync(Asset item)
        {
            try
            {
                await _assetRepository.UpdateAsync(item);
            }
            catch
            {
                Console.WriteLine("Error update asset");
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
                Console.WriteLine("Error getting assets");
                throw;
            }
        }

        public async Task<IEnumerable<Asset>> GetListAsync()
        {
            try
            {
                return await _assetRepository.GetListAsync();
            }
            catch
            {
                Console.WriteLine("Error getting assets");
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
                Console.WriteLine("Save Error");
                throw;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
               await _assetRepository.SaveAsync();
            }
            catch
            {
                Console.WriteLine("Save Error");
                throw;
            }
        }
    }
}
