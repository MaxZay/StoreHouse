using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class StoreHouseRepository : IStoreHouse
    {
        ApplicationContext db = new ApplicationContext();
        public void Add(StoreHouse entity)
        {
            db.Attach(entity);
            db.StoreHouse.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<StoreHouse> GetAll()
        {
            return db.StoreHouse.Include(u => u.MedicalBills).AsNoTracking();
        }

        public void Remove(StoreHouse entity)
        {
            db.StoreHouse.Remove(db.StoreHouse.FirstOrDefault(u => u.Id == entity.Id));
            db.SaveChanges();
        }

        public void Update(StoreHouse entity)
        {
            var house = db.StoreHouse.FirstOrDefault(u => u.Id == entity.Id);
            house.MedicalBillId = entity.MedicalBillId;
            house.MedicalBills = entity.MedicalBills;
            house.ShelfLife = entity.ShelfLife;
            house.DateOfManufacturer = entity.DateOfManufacturer;
            db.SaveChanges();
        }
    }
}
