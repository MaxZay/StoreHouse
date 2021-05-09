using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Contexts;
using System.Linq;

namespace DAL.Repositories
{
    public class WriteOfListRepository : IWriteOfList
    {
        ApplicationContext db = new ApplicationContext();
        public void Add(WriteOfList entity)
        {
            db.Attach(entity);
            db.WriteOfList.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<WriteOfList> GetAll()
        {
            return db.WriteOfList.Include(u => u.MedicalBills).AsNoTracking();
        }

        public void Remove(WriteOfList entity)
        {
            db.WriteOfList.Remove(db.WriteOfList.FirstOrDefault(u => u.Id == entity.Id));
            db.SaveChanges();
        }

        public void Update(WriteOfList entity)
        {
            var house = db.WriteOfList.FirstOrDefault(u => u.Id == entity.Id);
            house.MedicalBillId = entity.MedicalBillId;
            house.MedicalBills = entity.MedicalBills;
            house.ShelfLife = entity.ShelfLife;
            house.DateOfManufacture = entity.DateOfManufacture;
            db.SaveChanges();
        }
    }
}
