using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Entities;
using BLL.DTOs;
using DAL.Interfaces;


namespace BLL.Services
{
    public class MedicalBillsTypeService : IMedicalBillsTypeService
    {
        private readonly IMedicalBillsType _repository;

        public MedicalBillsTypeService(IMedicalBillsType medicalBillsType)
        {
            _repository = medicalBillsType;
        }

        public void Add(MedicalBillsTypeDTO entity)
        {
            _repository.Add(Mapper.FromDTO(entity));
        }

        public IEnumerable<MedicalBillsTypeDTO> GetAll()
        {
            var billsType = _repository.GetAll();
            List<MedicalBillsTypeDTO> typeDTOs = new List<MedicalBillsTypeDTO>();
            foreach (MedicalBillsType type in billsType)
            {
                typeDTOs.Add(Mapper.ToDTO(type));
            }
            return typeDTOs;
        }

        public void Remove(MedicalBillsTypeDTO entity)
        {
            _repository.Remove(Mapper.FromDTO(entity));
        }

        public void Update(MedicalBillsTypeDTO entity)
        {
            _repository.Update(Mapper.FromDTO(entity));
        }
    }
}
