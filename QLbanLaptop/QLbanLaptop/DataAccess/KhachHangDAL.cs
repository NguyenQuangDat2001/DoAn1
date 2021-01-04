using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Đồ_án_1.DataAccess.Interface;
using Đồ_án_1.Entities;

namespace Đồ_án_1.DataAccess
{
    public class KhachHangDAL : IKhachHangDAL
    {
        //Xác định đường dẫn của tệp dữ liệu SanPham.txt
        private string txtKhachHang = "Data/KhachHang.txt";
        //Lấy toàn bộ dữ liệu có trong file SanPham.txt đưa vào một danh sách 
        public List<KhachHang> GetAllKhachHang()
        {
            List<KhachHang> list = new List<KhachHang>();
            StreamReader fread = File.OpenText(txtKhachHang);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new KhachHang(a[0], a[1], a[2], a[3], a[4]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Chèn một bản ghi san pham vào tệp
        public void ThemKhachHang(KhachHang kh)
        {
            string makhachhang = "KH" + DateTime.Now.ToString("yyMMddhhmmss");
            StreamWriter fwrite = File.AppendText(txtKhachHang);
            fwrite.WriteLine();
            fwrite.Write(makhachhang + "#" + kh.Hoten + "#" + kh.QueQuan + "#" + kh.DiaChi + "#" + kh.SodienThoai);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<KhachHang> list)
        {
            StreamWriter fwrite = File.CreateText(txtKhachHang);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].MaKhach + "#" + list[i].Hoten + "#" + list[i].QueQuan + "#" + list[i].DiaChi + "#" + list[i].SodienThoai);
            fwrite.Close();
        }
    }
}
