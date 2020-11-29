using HoaDon.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace HoaDon.Business.Interface
{
    public interface ILaptopBLL
    {
        List<Laptop> GetAllLaptop();
        public void ThemLaptop(Laptop lt) ;
        public void XoaLaptop(string maLaptop);
        public void SuaLaptop(Laptop lt);
        List<Laptop> TimLaptop(Laptop lt);
    } 
}
