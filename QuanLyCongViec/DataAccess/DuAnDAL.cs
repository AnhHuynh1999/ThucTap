using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess
{
    public class DuAnDAL
    {
        DataContext db;
        public DuAnDAL(DataContext dataContext)
        {
            db = dataContext;
        }
        public List<DuAn> Get()
        {
            return db.DuAns.ToList();
        }
        public DuAn GetByID(int id)
        {
            return db.DuAns.FirstOrDefault(x => x.Id == id);
        }
        public DuAn Add(DuAn DuAnMoi)
        {
            try
            {
                db.DuAns.Add(DuAnMoi);
                db.SaveChanges();
                return DuAnMoi;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public DuAn Delete(DuAn duan)
        {
            try
            {
                db.DuAns.Remove(duan);
                db.SaveChanges();
                return duan;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public DuAn Update(DuAn duanmoi)
        {
            try
            {
                db.Entry(duanmoi).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return duanmoi;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
