using DataAccess;
using Models;
using System;
using System.Collections.Generic;

namespace Service
{
    public class CongViecBO
    {
        CongViecDAL cvdal;
        public CongViecBO(CongViecDAL dal)
        {
            cvdal = dal;
        }
        public List<CongViec> GetAll()
        {
            return cvdal.Get();
        }
        public CongViec Add(CongViec cvmoi)
        {
            try
            {
                CongViec d = cvdal.GetByID(cvmoi.Id);
                if (d == null)
                {
                    return cvdal.Add(cvmoi);
                }
                return null;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public CongViec GetByID(int id)
        {
            try
            {
                return cvdal.GetByID(id);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public CongViec Delete(int id)
        {
            try
            {

                CongViec xoa = cvdal.GetByID(id);
                if (xoa != null)
                {
                    return cvdal.Delete(xoa);
                }
                return null;


            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public CongViec Update(CongViec cv)
        {
            try
            {
                //CongViec sua = cvdal.GetByID(cv.Id);
                //if (sua != null)
                    return cvdal.Update(cv);
                //return null;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
