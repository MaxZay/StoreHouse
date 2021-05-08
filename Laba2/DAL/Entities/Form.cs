using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Form
    {
        public int Id { get; set; }
        public string FormName { get; set; }

        public ICollection<MedicalBills> MedicalBills { get; set; }
    }
}
