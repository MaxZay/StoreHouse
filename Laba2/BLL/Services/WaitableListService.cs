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
    public class WaitableListService : IWaitableListService
    {
        private readonly IWaitableList _repository;
        private readonly IMedicalBills _rep;

        public WaitableListService(IWaitableList storeHouse, IMedicalBills rep)
        {
            _repository = storeHouse;
            _rep = rep;
        }

        public void Add(WaitableListDTO entity)
        {
            _repository.Add(Mapper.FromDTO(entity));
        }

        public IEnumerable<WaitableListDTO> GetAll()
        {
            var house = _repository.GetAll();
            List<WaitableListDTO> list = new List<WaitableListDTO>();
            foreach (WaitableList mb in house)
            {
                mb.MedicalBills = _rep.GetAll().FirstOrDefault(u => u.Id == mb.MedicalBills.Id);
                list.Add(Mapper.ToDTO(mb));
            }
            return list;
        }

        public void Remove(WaitableListDTO entity)
        {
            _repository.Remove(Mapper.FromDTO(entity));
        }

        public void Update(WaitableListDTO entity)
        {
            _repository.Remove(Mapper.FromDTO(entity));
        }
    }
}
