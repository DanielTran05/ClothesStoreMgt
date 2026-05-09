using ClothesStore.DAL.Repository; 
using ClothesStore.DTO;
using ClothesStore.DTO.MasterDataDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClothesStore.BUS
{
    public class ColorService
    {
        private readonly ColorRepository _colorRepository;

        public ColorService()
        {
            _colorRepository = new ColorRepository();
        }

        public List<ColorDTO> GetAllColors() => _colorRepository.GetAllColors();

        public void CreateColor(ColorDTO color)
        {
            if (string.IsNullOrWhiteSpace(color.ColorName))
                throw new Exception("Tên màu không được để trống!");

            color.ColorName = color.ColorName.Trim();

            if (_colorRepository.GetAllColors().Any(c => c.ColorName.Equals(color.ColorName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception($"Màu '{color.ColorName}' đã tồn tại!");

            _colorRepository.CreateColor(color);
        }

        public void UpdateColor(ColorDTO color)
        {
            if (string.IsNullOrWhiteSpace(color.ColorName))
                throw new Exception("Tên màu không được để trống!");

            color.ColorName = color.ColorName.Trim();

            if (_colorRepository.GetAllColors().Any(c => c.ColorName.Equals(color.ColorName, StringComparison.OrdinalIgnoreCase) && c.ColorID != color.ColorID))
                throw new Exception($"Màu '{color.ColorName}' đã tồn tại!");

            _colorRepository.UpdateColor(color);
        }

        public void DeleteColor(int id) => _colorRepository.DeleteColor(id);
    }
}