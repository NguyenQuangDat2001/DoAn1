using Đồ_án_1.Business.Interface;
using Đồ_án_1.DataAccess;
using Đồ_án_1.DataAccess.Interface;
using Đồ_án_1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Đồ_án_1.Business
{
    public class HoaDonBLL : IHoaDonBLL
    {
        private IHoaDonDAL hdDAL = new HoaDonDAL();
        //Thực thi các yêu cầu
        public List<Hoadon> GetAllHoadon()
        {
            return hdDAL.GetAllHoadon();
        }
        public void ThemHoaDon(Hoadon hd)
        {
            if (!string.IsNullOrEmpty(hd.tenlaptop))
            {
                //Tiến hành chuẩn hóa dữ liệu nếu cần
                hdDAL.ThemHoaDon(hd);
            }
            else
                throw new Exception("Dữ liệu sai!!!");
        }

        public void XoaHoaDon(string mahoadon)
        {
            int i;
            List<Hoadon> list = GetAllHoadon();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaHoaDon == mahoadon) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                hdDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã hóa đơn này!!!");
        }
        public void SuaHoaDon(Hoadon hd)
        {
            int i;
            List<Hoadon> list = GetAllHoadon();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaHoaDon == hd.MaHoaDon) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(hd);
                hdDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã hóa đơn này!!!");
        }
        public List<Hoadon> TimHoaDon(Hoadon hd)
        {
            List<Hoadon> list = GetAllHoadon();
            List<Hoadon> kq = new List<Hoadon>();
            if (string.IsNullOrEmpty(hd.MaHoaDon))
            {
                kq = list;
            }

            //Tìm theo mã hóa đơn
            if (!string.IsNullOrEmpty(hd.MaHoaDon))
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].MaHoaDon.IndexOf(hd.MaHoaDon) >= 0)
                    {
                        kq.Add(new Hoadon(list[i]));
                    }
            }
            return kq;
        }
    }
}
