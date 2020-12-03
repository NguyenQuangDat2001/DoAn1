using System;
using System.Collections.Generic;
using Đồ_án_1.Entities;
using Đồ_án_1.Business.Interface;
using Đồ_án_1.DataAccess;

namespace Đồ_án_1.Business
{
        public class NhanVienBLL : INhanvienBLL
        {
            private INhanVienDAL nvDA = new NhanVienDAL();
            //Thực thi các yêu cầu
            public List<Nhanvien> GetAllNhanVien()
            {
                return nvDA.GetAllNhanvien();
            }
            public void ThemNhanVien(Nhanvien NV)
            {
                if (!string.IsNullOrEmpty(NV.MaNhanVien))
                {
                    //Tiến hành chuẩn hóa dữ liệu nếu cần
                    nvDA.ThemNhanvien(NV);
                }
                else
                    throw new Exception("Du lieu sai");
            }

            public void XoaNhanVien(string manhanvien)
            {
                int i;
                List<Nhanvien> list = GetAllNhanVien();
                for (i = 0; i < list.Count; ++i)
                    if (list[i].MaNhanVien == manhanvien) break;
                if (i < list.Count)
                {
                    list.RemoveAt(i);
                    nvDA.Update(list);
                }
                else
                    throw new Exception("Khong ton tai ma nay");
            }
            public void SuaNhanVien(Nhanvien nv)
            {
                int i;
                List<Nhanvien> list = GetAllNhanVien();
                for (i = 0; i < list.Count; ++i)
                    if (list[i].MaNhanVien == nv.MaNhanVien) break;
                if (i < list.Count)
                {
                    list.RemoveAt(i);
                    list.Add(nv);
                    nvDA.Update(list);
                }
                else
                    throw new Exception("Khong ton tai nhan vien nay");
            }
            public List<Nhanvien> TimNhanvien(Nhanvien NV)
            {
                List<Nhanvien> list = GetAllNhanVien();
                List<Nhanvien> kq = new List<Nhanvien>();
                if (string.IsNullOrEmpty(NV.MaNhanVien) &&
                    string.IsNullOrEmpty(NV.TenNhanVien) &&
                    string.IsNullOrEmpty(NV.DiaChiNV) &&
                    string.IsNullOrEmpty(NV.SoDienThoaiNV) &&
                    string.IsNullOrEmpty(NV.Gmail) &&
                    NV.HeSoLuong == 0 &&
                    NV.LuongCoBan == 0)

                {
                    kq = list;
                }
                //Tim theo ho ten nhan vien
                if (!string.IsNullOrEmpty(NV.TenNhanVien))
                {
                    for (int i = 0; i < list.Count; ++i)
                        if (list[i].TenNhanVien.IndexOf(NV.TenNhanVien) >= 0)
                        {
                            kq.Add(new Nhanvien(list[i]));
                        }
                }

                //Tim theo ma nhan vien
                else if (NV.MaNhanVien != "")
                {
                    for (int i = 0; i < list.Count; ++i)
                        if (list[i].MaNhanVien == NV.MaNhanVien)
                        {
                            kq.Add(new Nhanvien(list[i]));
                        }
                }
                else kq = null;
                return kq;
            }
        }
}
