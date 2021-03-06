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
                Form = ToDTO(medicalBills.Form)
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
                Form = FromDTO(medicalBillsDTO.Form)
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
                DateOfManufacture = storeHouse.DateOfManufacture,
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
                DateOfManufacture = storeHouse.DateOfManufacture,
                ShelfLife = storeHouse.ShelfLife,
                MedicalBills = FromDTO(storeHouse.MedicalBills)
            };
            return f;
        }

        public static WaitableListDTO ToDTO(WaitableList storeHouse)
        {
            WaitableListDTO f = new WaitableListDTO
            {
                Id = storeHouse.Id,
                DateOfManufacture = storeHouse.DateOfManufacture,
                ShelfLife = storeHouse.ShelfLife,
                MedicalBills = ToDTO(storeHouse.MedicalBills)
            };
            return f;
        }

        public static WaitableList FromDTO(WaitableListDTO storeHouse)
        {
            WaitableList f = new WaitableList
            {
                Id = storeHouse.Id,
                DateOfManufacture = storeHouse.DateOfManufacture,
                ShelfLife = storeHouse.ShelfLife,
                MedicalBills = FromDTO(storeHouse.MedicalBills)
            };
            return f;
        }

        public static WriteOfListDTO ToDTO(WriteOfList storeHouse)
        {
            WriteOfListDTO f = new WriteOfListDTO
            {
                Id = storeHouse.Id,
                DateOfManufacture = storeHouse.DateOfManufacture,
                ShelfLife = storeHouse.ShelfLife,
                MedicalBills = ToDTO(storeHouse.MedicalBills)
            };
            return f;
        }

        public static WriteOfList FromDTO(WriteOfListDTO storeHouse)
        {
            WriteOfList f = new WriteOfList
            {
                Id = storeHouse.Id,
                DateOfManufacture = storeHouse.DateOfManufacture,
                ShelfLife = storeHouse.ShelfLife,
                MedicalBills = FromDTO(storeHouse.MedicalBills)
            };
            return f;
        }
    }
}
