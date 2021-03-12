using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
   public class NguoiDungDAL
    {
        DataContext db;
        public NguoiDungDAL(DataContext context)
        {
            db = context;
        }
        public List<NguoiDung> Get()
        {
            return db.NguoiDungs.ToList();
        }
        public NguoiDung GetByID(int id)
        {
            return db.NguoiDungs.FirstOrDefault(x => x.Id == id);
        }
        public NguoiDung Add( NguoiDung nguoimoi)
        {
            try
            {
                db.NguoiDungs.Add(nguoimoi);
                db.SaveChanges();
                return nguoimoi;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public NguoiDung Delete(NguoiDung d)
        {
            try
            {
                db.NguoiDungs.Remove(d);
                db.SaveChanges();
                return d;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public NguoiDung Update(int id,NguoiDung nd)
        {
            try
            {
                //db.Entry(nd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //db.SaveChanges();
                //return nd;
                NguoiDung thisrole = (from x in db.NguoiDungs
                                      where x.Id == id
                                      select x).First();
                thisrole.TenNV = nd.TenNV;
                thisrole.DiaChi = nd.DiaChi;
                db.SaveChanges();
                return thisrole;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
