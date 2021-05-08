using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Entities;
using DAL.Contexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class MedicalBillsRepository : IMedicalBills
    {
        ApplicationContext db = new ApplicationContext();
        public void Add(MedicalBills entity)
        {
            db.Attach(entity.MedicalBillsType);
            db.MedicalBills.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<MedicalBills> GetAll()
        {
            return db.MedicalBills.Include(t => t.MedicalBillsType).AsNoTracking();
        }

        public void Remove(MedicalBills entity)
        {
            db.MedicalBills.Remove(db.MedicalBills.FirstOrDefault(u => u.Id == entity.Id));
            db.SaveChanges();
        }

        public void Update(MedicalBills entity)
        {
            var bill = db.MedicalBills.FirstOrDefault(u => u.Id == entity.Id);
            bill.Name = entity.Name;
            bill.MedicalBillsType = entity.MedicalBillsType;
            bill.MedicalBillsTypeId = entity.MedicalBillsTypeId;
            bill.Form = entity.Form;
            bill.FormId = entity.FormId;
            db.SaveChanges();
        }
    }
}
