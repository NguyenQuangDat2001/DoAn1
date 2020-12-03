using System;
using Đồ_án_1.Entities;
using System.Collections.Generic;
using System.Text;

namespace Đồ_án_1.Business.Interface
{
    public interface INhanvienBLL
    {
        List<Nhanvien> GetAllNhanVien();
        void ThemNhanVien(Nhanvien NV);
        void XoaNhanVien(string MaNV);
        void SuaNhanVien(Nhanvien NV);
        List<Nhanvien> TimNhanvien(Nhanvien NV);
    }
}
