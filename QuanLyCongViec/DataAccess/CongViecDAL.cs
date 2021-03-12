using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
   public class CongViecDAL
    {
        DataContext db;
        public CongViecDAL(DataContext context)
        {
            db = context;
        }
        public List<CongViec> Get()
        {
            return db.CongViecs.ToList();
        }
        public CongViec GetByID(int id)
        {
            return db.CongViecs.FirstOrDefault(x => x.Id == id);
        }
        public CongViec Add(CongViec cvmoi)
        {
            try
            {
                db.CongViecs.Add(cvmoi);
                db.SaveChanges();
                return cvmoi;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public CongViec Delete(CongViec cv)
        {
            try
            {
                db.CongViecs.Remove(cv);
                db.SaveChanges();
                return cv;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public CongViec Update(int id,CongViec cvmoi)
        {
            try
            {
                //db.Entry(cvmoi).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //db.SaveChanges();
                //return cvmoi;
                CongViec thisrole = (from x in db.CongViecs
                                 where x.Id == id
                                 select x).First();
                thisrole.NguoiDung = cvmoi.NguoiDung;
                thisrole.TenCV = cvmoi.TenCV;
                thisrole.TinhTrang = cvmoi.TinhTrang;
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
