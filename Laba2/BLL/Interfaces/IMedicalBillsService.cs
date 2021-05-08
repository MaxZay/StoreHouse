using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IMedicalBillsService : IService<MedicalBillsDTO, MedicalBills>
    {
    }
}
