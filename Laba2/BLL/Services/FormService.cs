using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Entities;
using BLL.DTOs;
using DAL.Interfaces;

namespace BLL.Services
{
    public class FormService : IFormService
    {
        private readonly IForm _repository;

        public FormService(IForm form)
        {
            _repository = form;
        }
        public void Add(FormDTO entity)
        {
            _repository.Add(Mapper.FromDTO(entity));
        }

        public IEnumerable<FormDTO> GetAll()
        {
            var forms = _repository.GetAll();
            List<FormDTO> list = new List<FormDTO>();
            foreach (Form mb in forms)
            {
                list.Add(Mapper.ToDTO(mb));
            }
            return list;
        }

        public void Remove(FormDTO entity)
        {
            _repository.Remove(Mapper.FromDTO(entity));
        }

        public void Update(FormDTO entity)
        {
            _repository.Update(Mapper.FromDTO(entity));
        }
    }
}
