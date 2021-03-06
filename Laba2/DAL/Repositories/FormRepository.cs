using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories
{
    public class FormRepository : IForm
    {
        ApplicationContext db = new ApplicationContext();
        public void Add(Form entity)
        {
            db.Attach(entity.MedicalBills);
            db.Form.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<Form> GetAll()
        {
            return db.Form.Include(u => u.MedicalBills).AsNoTracking();
        }

        public void Remove(Form entity)
        {
            db.Form.Remove(db.Form.FirstOrDefault(u => u.Id == entity.Id));
            db.SaveChanges();
        }

        public void Update(Form entity)
        {
            var form = db.Form.FirstOrDefault(u => u.Id == entity.Id);
            form.FormName = entity.FormName;
            form.MedicalBills = entity.MedicalBills;
            db.SaveChanges();
        }
    }
}
