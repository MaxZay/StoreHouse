using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IService<DTO, T>
    {
        IEnumerable<DTO> GetAll();
        void Add(DTO entity);
        void Remove(DTO entity);
        void Update(DTO entity);
    }
}
