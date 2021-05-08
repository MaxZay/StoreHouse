using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class MedicalBills
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MedicalBillsTypeId { get; set; }
        public MedicalBillsType MedicalBillsType { get; set; }
        public int FormId { get; set; }
        public Form Form { get; set; }
        public ICollection<StoreHouse> StoreHouses { get; set; }
    }
}
