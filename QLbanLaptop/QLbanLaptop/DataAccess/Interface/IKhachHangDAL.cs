using Đồ_án_1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Đồ_án_1.DataAccess.Interface
{
    public interface IKhachHangDAL
    {
        List<KhachHang> GetAllKhachHang();
        void ThemKhachHang(KhachHang kh);
        void Update(List<KhachHang> list);
    }
}
