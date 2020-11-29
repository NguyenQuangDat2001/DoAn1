using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HoaDon.Entities;
using HoaDon.DataAccess;
using HoaDon.Business.Interface;

namespace DoAn1.Business
{
    public class LaptopBLL : ILaptopBLL
    {
        private ILaptopDAL ltDA = new LaptopDAL();
        //Thực thi các yêu cầu
        public List<Laptop> GetAllLaptop()
        {
            return ltDA.GetAllLaptop();
        }
        public void ThemLaptop(Laptop lt)
        {
            if (!string.IsNullOrEmpty(lt.TenLT))
            {
                //Tiến hành chuẩn hóa dữ liệu nếu cần
                ltDA.ThemLaptop(lt);
            }
            else
                throw new Exception("Du lieu sai");
        }

        public void XoaLaptop(string maLaptop)
        {
            int i;
            List<Laptop> list = GetAllLaptop();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaLT == maLaptop) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                ltDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaLaptop(Laptop lt)
        {
            int i;
            List<Laptop> list = GetAllLaptop();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaLT == lt.MaLT) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(lt);
                ltDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai hs nay");
        }
        public List<Laptop> TimLaptop(Laptop lt)
        {
            List<Laptop> list = GetAllLaptop();
            List<Laptop> kq = new List<Laptop>();
            if (string.IsNullOrEmpty(lt.MaLT) &&
                 string.IsNullOrEmpty(lt.TenLT) &&
                 string.IsNullOrEmpty(lt.Mau) &&
                 lt.DonGia == 0)
            {
                kq = list;
            }
            //Tim theo ten sp
            if (!string.IsNullOrEmpty(lt.TenLT))
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].TenLT.IndexOf(lt.TenLT) >= 0)
                    {
                        kq.Add(new Laptop(list[i]));
                    }
            }

            //Tim theo gia
            else if (lt.DonGia > 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].DonGia == lt.DonGia)
                    {
                        kq.Add(new Laptop(list[i]));
                    }
            }
            else kq = null;
            return kq;
        }
    }
}