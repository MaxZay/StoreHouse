using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.DTOs
{
    public static class Mapper
    {
        public static MedicalBillsDTO ToDTO(MedicalBills medicalBills)
        {
            MedicalBillsDTO medical = new MedicalBillsDTO
            {
                Id = medicalBills.Id,
                Name = medicalBills.Name,
                MedicalBillsType = ToDTO(medicalBills.MedicalBillsType),
            };
            return medical;
        }

        public static MedicalBills FromDTO(MedicalBillsDTO medicalBillsDTO)
        {
            MedicalBills medicalBills = new MedicalBills
            {
                Id = medicalBillsDTO.Id,
                Name = medicalBillsDTO.Name,
                MedicalBillsType = FromDTO(medicalBillsDTO.MedicalBillsType),
            };
            return medicalBills;
        }

        public static MedicalBillsTypeDTO ToDTO(MedicalBillsType medicalBillsType)
        {
            MedicalBillsTypeDTO medicalBillsTypeDTO = new MedicalBillsTypeDTO
            {
                Id = medicalBillsType.Id,
                Type = medicalBillsType.Type
            };
            return medicalBillsTypeDTO;
        }

        public static MedicalBillsType FromDTO(MedicalBillsTypeDTO medicalBillsTypeDTO)
        {
            MedicalBillsType medicalBillsType = new MedicalBillsType
            {
                Id = medicalBillsTypeDTO.Id,
                Type = medicalBillsTypeDTO.Type
            };
            return medicalBillsType;
        }

        public static FormDTO ToDTO(Form form)
        {
            FormDTO f = new FormDTO
            {
                Id = form.Id,
                FormName = form.FormName
            };
            return f;
        }

        public static Form FromDTO(FormDTO form)
        {
            Form f = new Form
            {
                Id = form.Id,
                FormName = form.FormName
            };
            return f;
        }

        public static StoreHouseDTO ToDTO(StoreHouse storeHouse)
        {
            StoreHouseDTO f = new StoreHouseDTO
            {
                Id = storeHouse.Id,
                DateOfManufacturer = storeHouse.DateOfManufacturer,
                ShelfLife = storeHouse.ShelfLife,
                MedicalBills = ToDTO(storeHouse.MedicalBills)
            };
            return f;
        }

        public static StoreHouse FromDTO(StoreHouseDTO storeHouse)
        {
            StoreHouse f = new StoreHouse
            {
                Id = storeHouse.Id,
                DateOfManufacturer = storeHouse.DateOfManufacturer,
                ShelfLife = storeHouse.ShelfLife,
                MedicalBills = FromDTO(storeHouse.MedicalBills)
            };
            return f;
        }
    }
}
