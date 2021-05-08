using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class FormDTO
    {
        public int Id { get; set; }
        public string FormName { get; set; }

        public override string ToString()
        {
            return FormName;
        }
    }
}
