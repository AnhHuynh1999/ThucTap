
using DataAccess;
using Models;
using System;
using System.Collections.Generic;

namespace Service
{
    public class DuAnBO
    {
        DuAnDAL duan;
        public DuAnBO(DuAnDAL duAnDAL)
        {
            duan = duAnDAL;
        }
        public List<DuAn> GetAll()
        {
            return duan.Get();
        }
        public DuAn Add(DuAn damoi)
        {
            try
            {
                DuAn d = duan.GetByID(damoi.Id);
                if (d == null)
                {
                    return duan.Add(damoi);
                }
                return null;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public DuAn GetByID(int id)
        {
            try
            {
                return duan.GetByID(id);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public DuAn Delete(int id)
        {
            try
            {

                DuAn xoa = duan.GetByID(id);
                if (xoa != null)
                {
                    return duan.Delete(xoa);
                }
                return null;


            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public DuAn Update(DuAn da)
        {
            try
            {
                //DuAn sua = duan.GetByID(da.Id);
                //if (sua != null)
                    return duan.Update(da);
                //return null;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
