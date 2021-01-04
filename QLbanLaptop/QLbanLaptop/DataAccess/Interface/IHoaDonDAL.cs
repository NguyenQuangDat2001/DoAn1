using Đồ_án_1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Đồ_án_1.DataAccess.Interface
{
    public interface IHoaDonDAL
    {
        List<Hoadon> GetAllHoadon();
        void ThemHoaDon(Hoadon hd);
        void Update(List<Hoadon> list);
    }
}
