using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace BLL.DTOs
{
    public class StoreHouseDTO
    {
        public int Id { get; set; }
        public MedicalBillsDTO MedicalBills { get; set; }
        public DateTime DateOfManufacturer { get; set; }
        public DateTime ShelfLife { get; set; }
    }
}
