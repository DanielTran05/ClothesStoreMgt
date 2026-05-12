using ClothesStore.DAL.Repository;
using ClothesStore.DTO;
using ClothesStore.DTO.MasterDataDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClothesStore.BUS
{
    public class SizeService
    {
        private readonly SizeRepository _sizeRepository;

        public SizeService()
        {
            _sizeRepository = new SizeRepository();
        }

        public List<SizeDTO> GetAllSizes() => _sizeRepository.GetAllSizes();

        public void CreateSize(SizeDTO size)
        {
            if (string.IsNullOrWhiteSpace(size.SizeName))
                throw new Exception("Tên kích cỡ không được để trống!");

            size.SizeName = size.SizeName.Trim();

            if (_sizeRepository.GetAllSizes().Any(s => s.SizeName.Equals(size.SizeName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception($"Kích cỡ '{size.SizeName}' đã tồn tại!");

            _sizeRepository.CreateSize(size);
        }

        public void UpdateSize(SizeDTO size)
        {
            if (string.IsNullOrWhiteSpace(size.SizeName))
                throw new Exception("Tên kích cỡ không được để trống!");

            size.SizeName = size.SizeName.Trim();

            if (_sizeRepository.GetAllSizes().Any(s => s.SizeName.Equals(size.SizeName, StringComparison.OrdinalIgnoreCase) && s.SizeID != size.SizeID))
                throw new Exception($"Kích cỡ '{size.SizeName}' đã tồn tại!");

            _sizeRepository.UpdateSize(size);
        }

        public void DeleteSize(int id) => _sizeRepository.DeleteSize(id);
    }
}