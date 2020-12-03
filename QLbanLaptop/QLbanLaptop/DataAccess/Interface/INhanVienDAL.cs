using System;
using System.Collections.Generic;
using System.Text;
using Đồ_án_1.Entities;

namespace Đồ_án_1.DataAccess
{
    public interface INhanVienDAL
    {
        List<Nhanvien> GetAllNhanvien();
        void ThemNhanvien(Nhanvien NV);
        void Update(List<Nhanvien> list);
    }
}
