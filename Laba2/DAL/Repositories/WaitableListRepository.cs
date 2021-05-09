using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class WaitableListRepository : IWaitableList
    {
        ApplicationContext db = new ApplicationContext();
        public void Add(WaitableList entity)
        {
            db.Attach(entity);
            db.WaitableList.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<WaitableList> GetAll()
        {
            return db.WaitableList.Include(u => u.MedicalBills).AsNoTracking();
        }

        public void Remove(WaitableList entity)
        {
            db.WaitableList.Remove(db.WaitableList.FirstOrDefault(u => u.Id == entity.Id));
            db.SaveChanges();
        }

        public void Update(WaitableList entity)
        {
            var house = db.WaitableList.FirstOrDefault(u => u.Id == entity.Id);
            house.MedicalBillId = entity.MedicalBillId;
            house.MedicalBills = entity.MedicalBills;
            house.ShelfLife = entity.ShelfLife;
            house.DateOfManufacture = entity.DateOfManufacture;
            db.SaveChanges();
        }
    }
}
