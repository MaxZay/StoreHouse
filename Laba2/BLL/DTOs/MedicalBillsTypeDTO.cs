using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class MedicalBillsTypeDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return Type;
        }
    }
}
