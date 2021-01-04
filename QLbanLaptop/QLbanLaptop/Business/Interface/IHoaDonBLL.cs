using System.Collections.Generic;
using Đồ_án_1.Entities;



namespace Đồ_án_1.Business.Interface
{
    public interface IHoaDonBLL
    {
        List<Hoadon> GetAllHoadon();
        void ThemHoaDon(Hoadon hd);
        void XoaHoaDon(string mahoadon);
        void SuaHoaDon(Hoadon hd);
        List<Hoadon> TimHoaDon(Hoadon hd );
    }
}
