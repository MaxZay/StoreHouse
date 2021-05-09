using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class WriteOfList
    {
        public int Id { get; set; }
        public int MedicalBillId { get; set; }
        public MedicalBills MedicalBills { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public DateTime ShelfLife { get; set; }
    }
}
