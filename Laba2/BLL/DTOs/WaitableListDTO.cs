using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace BLL.DTOs
{
    public class WaitableListDTO
    {
        public int Id { get; set; }
        public MedicalBillsDTO MedicalBills { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public DateTime ShelfLife { get; set; }
    }
}
