using System;
using System.Collections.Generic;
using Đồ_án_1.Entities;
using System.Text;

namespace Đồ_án_1.Business.Interface
{
    public interface IKhachHangBLL
    {
        List<KhachHang> GetAllKhachHang();
        void ThemKhachHang(KhachHang kh);
        void XoaKhachHang(string makhach);
        void SuaKhachHang(KhachHang kh);
        List<KhachHang> TimKhachHang(KhachHang kh);
    }
}
