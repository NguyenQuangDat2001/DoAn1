using Đồ_án_1.Business.Interface;
using Đồ_án_1.DataAccess;
using Đồ_án_1.DataAccess.Interface;
using Đồ_án_1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Đồ_án_1.Business
{
    public class KhachHangBLL : IKhachHangBLL
    {
        private IKhachHangDAL khDAL = new KhachHangDAL();
        //Thực thi các yêu cầu
        public List<KhachHang> GetAllKhachHang()
        {
            return khDAL.GetAllKhachHang();
        }
        public void ThemKhachHang(KhachHang kh)
        {
            if (!string.IsNullOrEmpty(kh.Hoten))
            {
                //Tiến hành chuẩn hóa dữ liệu nếu cần
                khDAL.ThemKhachHang(kh);
            }
            else
                throw new Exception("Du lieu sai");
        }

        public void XoaKhachHang(string makhach)
        {
            int i;
            List<KhachHang> list = GetAllKhachHang();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaKhach == makhach) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                khDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này");
        }
        public void SuaKhachHang(KhachHang kh)
        {
            int i;
            List<KhachHang> list = GetAllKhachHang();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaKhach == kh.MaKhach) 
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(kh);
                khDAL.Update(list);
            }
            else
                Console.WriteLine("Không tồn tại mã này");
        }
        public List<KhachHang> TimKhachHang(KhachHang kh)
        {
            List<KhachHang> list = GetAllKhachHang();
            List<KhachHang> kq = new List<KhachHang>();
            if (string.IsNullOrEmpty(kh.MaKhach) &&
                string.IsNullOrEmpty(kh.Hoten) &&
                string.IsNullOrEmpty(kh.QueQuan) &&
                string.IsNullOrEmpty(kh.DiaChi) &&
                string.IsNullOrEmpty(kh.SodienThoai))
            {
                kq = list;
            }
            //Tim theo ho ten khach hang
            if (!string.IsNullOrEmpty(kh.Hoten))
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Hoten.IndexOf(kh.Hoten) >= 0)
                    {
                        kq.Add(new KhachHang(list[i]));
                    }
            }

            //Tim theo ma khach hang
            else if (kh.MaKhach != "")
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].MaKhach == kh.MaKhach)
                    {
                        kq.Add(new KhachHang(list[i]));
                    }
            }
            else kq = null;
            return kq;
        }
    }
}


