using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Entities;
using DAL.Contexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class MedicalBillsTypeRepository : IMedicalBillsType
    {
        ApplicationContext db = new ApplicationContext();

        public void Add(MedicalBillsType entity)
        {
            db.Attach(entity);
            db.MedicalBillsType.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<MedicalBillsType> GetAll()
        {
            return db.MedicalBillsType.Include(u => u.MedicalBills).AsNoTracking();
        }

        public void Remove(MedicalBillsType entity)
        {
            db.MedicalBillsType.Remove(db.MedicalBillsType.FirstOrDefault(u => u.Id == entity.Id));
            db.SaveChanges();
        }

        public void Update(MedicalBillsType entity)
        {
            var type = db.MedicalBillsType.FirstOrDefault(u => u.Id == entity.Id);
            type.Type = entity.Type;
            type.MedicalBills = entity.MedicalBills;
            db.SaveChanges();
        }
    }
}
