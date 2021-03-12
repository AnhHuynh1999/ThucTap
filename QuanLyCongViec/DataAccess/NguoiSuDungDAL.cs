using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
   public class NguoiSuDungDAL
    {
        DataContext db;
        public NguoiSuDungDAL (DataContext a)
        {
            db = a;
        }
        public List<NguoiSuDung> Get()
        {
            return db.NguoiSuDungs.ToList();
        }
        public NguoiSuDung GetById(string id)
        {
            return db.NguoiSuDungs.Find(id);
        }
        public NguoiSuDung Delete(NguoiSuDung nguoisudung)
        {
             db.NguoiSuDungs.Remove(nguoisudung);
            db.SaveChanges();
            return nguoisudung;
        }
        public NguoiSuDung Update(NguoiSuDung nguoisudung)
        {
            db.Entry(nguoisudung).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return nguoisudung;
        }
        public NguoiSuDung Find(string id)
        {
            return db.NguoiSuDungs.Find(id);
        }
        public NguoiSuDung Add(NguoiSuDung nguoimoi)
        {
             db.NguoiSuDungs.Add(nguoimoi);
            db.SaveChanges();
            return nguoimoi;
        }
        
    }
}
