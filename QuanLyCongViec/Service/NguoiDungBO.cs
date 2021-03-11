using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class NguoiDungBO
    {
        NguoiDungDAL ngdal;
        public  NguoiDungBO(NguoiDungDAL nguoiDung)
        {
            ngdal = nguoiDung;
        }
        public List<NguoiDung> GetAll()
        {
            return ngdal.Get();
        }
        public NguoiDung Add(NguoiDung ngmoi)
        {
            try
            {
                NguoiDung d = ngdal.GetByID(ngmoi.Id);
                if (d == null)
                {
                    return ngdal.Add(ngmoi);
                }
                return null;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public NguoiDung GetByID(int id)
        {
            try
            {
                return ngdal.GetByID(id);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public NguoiDung Delete(int id)
        {
            try
            {

                NguoiDung xoa = ngdal.GetByID(id);
                if (xoa != null)
                {
                    return ngdal.Delete(xoa);
                }
                return null;


            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public NguoiDung Update(NguoiDung ng)
        {
            try
            {
                //NguoiDung sua = ngdal.GetByID(ng.Id);
                //if (sua != null)
                    return ngdal.Update(ng);
               // return null;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
