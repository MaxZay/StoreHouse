using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Entities;
using BLL.DTOs;
using DAL.Interfaces;
using System.Linq;

namespace BLL.Services
{
    public class StoreHouseService : IStoreHouseService
    {
        private readonly IStoreHouse _repository;
        private readonly IMedicalBills _rep;

        public StoreHouseService(IStoreHouse storeHouse, IMedicalBills rep)
        {
            _repository = storeHouse;
            _rep = rep;
        }
        public void Add(StoreHouseDTO entity)
        {
            _repository.Add(Mapper.FromDTO(entity));
        }

        public IEnumerable<StoreHouseDTO> GetAll()
        {
            var house = _repository.GetAll();
            List<StoreHouseDTO> list = new List<StoreHouseDTO>();
            foreach (StoreHouse mb in house)
            {
                mb.MedicalBills = _rep.GetAll().FirstOrDefault(u => u.Id == mb.MedicalBills.Id);
                list.Add(Mapper.ToDTO(mb));
            }
            return list;
        }

        public void Remove(StoreHouseDTO entity)
        {
            _repository.Remove(Mapper.FromDTO(entity));
        }

        public void Update(StoreHouseDTO entity)
        {
            _repository.Update(Mapper.FromDTO(entity));
        }
    }
}
