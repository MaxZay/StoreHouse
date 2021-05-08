using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Entities;
using BLL.DTOs;
using DAL.Interfaces;

namespace BLL.Services
{
    public class MedicalBillsService : IMedicalBillsService
    {
        private readonly IMedicalBills _repository;

        public MedicalBillsService(IMedicalBills medicalBills)
        {
            _repository = medicalBills;
        }
        public void Add(MedicalBillsDTO entity)
        {
            _repository.Add(Mapper.FromDTO(entity));
        }

        public IEnumerable<MedicalBillsDTO> GetAll()
        {
            var bills = _repository.GetAll();
            List<MedicalBillsDTO> medicals = new List<MedicalBillsDTO>();
            foreach(MedicalBills mb in bills)
            {
                medicals.Add(Mapper.ToDTO(mb));
            }
            return medicals;
        }

        public void Remove(MedicalBillsDTO entity)
        {
            _repository.Remove(Mapper.FromDTO(entity));
        }

        public void Update(MedicalBillsDTO entity)
        {
            _repository.Update(Mapper.FromDTO(entity));
        }
    }
}
