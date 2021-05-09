using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class MedicalBillsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MedicalBillsTypeDTO MedicalBillsType { get; set; }
        public FormDTO Form { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
