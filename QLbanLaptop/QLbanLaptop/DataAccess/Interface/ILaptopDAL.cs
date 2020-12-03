using System;
using System.Collections.Generic;
using System.Text;
using HoaDon.Entities;

namespace HoaDon.DataAccess
{
    public interface ILaptopDAL
    {
        List<Laptop> GetAllLaptop();
        void ThemLaptop(Laptop lt);
        void Update(List<Laptop> list);
    }
}
