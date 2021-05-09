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
    public class WriteOfListService : IWriteOfListService
    {
        private readonly IWriteOfList _repository;
        private readonly IMedicalBills _rep;

        public WriteOfListService(IWriteOfList storeHouse, IMedicalBills rep)
        {
            _repository = storeHouse;
            _rep = rep;
        }
        public void Add(WriteOfListDTO entity)
        {
            _repository.Add(Mapper.FromDTO(entity));
        }

        public IEnumerable<WriteOfListDTO> GetAll()
        {
            var house = _repository.GetAll();
            List<WriteOfListDTO> list = new List<WriteOfListDTO>();
            foreach (WriteOfList mb in house)
            {
                mb.MedicalBills = _rep.GetAll().FirstOrDefault(u => u.Id == mb.MedicalBills.Id);
                list.Add(Mapper.ToDTO(mb));
            }
            return list;
        }

        public void Remove(WriteOfListDTO entity)
        {
            _repository.Remove(Mapper.FromDTO(entity));
        }

        public void Update(WriteOfListDTO entity)
        {
            _repository.Remove(Mapper.FromDTO(entity));
        }
    }
}
