using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class WriteOfList
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MedicalBillId { get; set; }
        public MedicalBills MedicalBills { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public DateTime ShelfLife { get; set; }
    }
}
