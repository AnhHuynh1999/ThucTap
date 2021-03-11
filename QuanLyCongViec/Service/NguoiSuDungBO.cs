using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class NguoiSuDungBO
    {
        NguoiSuDungDAL ngdal;
        public NguoiSuDungBO(NguoiSuDungDAL dal)
        {
            ngdal = dal;
        }

        public NguoiSuDung delete(string id)
        {
            NguoiSuDung xoa = ngdal.Find(id);
            if ( xoa != null)
            {
              return ngdal.Delete(xoa);
            }
            return null;
                 
        }
        public NguoiSuDung Find(string id)
        {
            return ngdal.Find(id);
        }
        public NguoiSuDung Update(NguoiSuDung nguoi)
        {
            NguoiSuDung sua = ngdal.Find(nguoi.Id);
            if(sua !=null)
                return ngdal.Update(nguoi);
            return null;
        }
        public NguoiSuDung Add(NguoiSuDung nguoi)
        {
            return ngdal.Add(nguoi);
            
        }
    }
}
