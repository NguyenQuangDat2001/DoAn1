using Đồ_án_1.DataAccess.Interface;
using Đồ_án_1.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Đồ_án_1.DataAccess
{
    class HoaDonDAL : IHoaDonDAL
    {
        //Xác định đường dẫn của tệp dữ liệu HoaDon.txt
        private string txtfile = "D:Data/HoaDon.txt";
        //Lấy toàn bộ dữ liệu có trong file HoaDon.txt đưa vào một danh sách 
        public List<Hoadon> GetAllHoadon()
        {
            List<Hoadon> list = new List<Hoadon>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new Hoadon(a[0], a[1], a[2], int.Parse(a[3]), int.Parse(a[4])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }


        //Chèn một bản ghi hóa đơn vào tệp
        public void ThemHoaDon(Hoadon hd)
        {
            string MaHoaDon = "HD" + DateTime.Now.ToString("yyMMddhhmmss");
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(MaHoaDon + "#" + hd.tenlaptop + "#" + hd.NgayBan + "#" + hd.SoLuong + "#" + hd.TongTien);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<Hoadon> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].MaHoaDon + "#" + list[i].tenlaptop + "#" + list[i].NgayBan + "#" + list[i].SoLuong + "#" + list[i].TongTien);
            fwrite.Close();
        }
    }
}
