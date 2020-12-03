using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Đồ_án_1.Entities;

namespace Đồ_án_1.DataAccess
{
    class NhanVienDAL : INhanVienDAL
    {
        //Xác định đường dẫn của tệp dữ liệu Laptop.txt
        private string txtfile = "Data/NhanVien.txt";
        //Lấy toàn bộ dữ liệu có trong file Laptop.txt đưa vào một danh sách 
        public List<Nhanvien> GetAllNhanvien()
        {
            List<Nhanvien> list = new List<Nhanvien>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new Nhanvien(a[0], a[1], a[2],a[3],a[4],double.Parse(a[5]),int.Parse(a[6])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Chèn một bản ghi học sinh vào tệp
        public void ThemNhanvien(Nhanvien NV)
        {
            string MaNV = NV.MaNhanVien;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(MaNV + " # " + NV.TenNhanVien + " # " + NV.DiaChiNV + " # " + NV.SoDienThoaiNV + " # " + NV.Gmail + " # " + NV.SoDienThoaiNV + " # " + " # " + NV.HeSoLuong+"#"+NV.LuongCoBan );
        }//Cập nhật lại danh sách vào tệp        
        public void Update(List<Nhanvien> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].MaNhanVien + "#" + list[i].TenNhanVien + "#" + list[i].DiaChiNV + "#" + list[i].Gmail + "#" + list[i].SoDienThoaiNV + "#"+list[i].HeSoLuong + "#" + list[i].LuongCoBan);
            fwrite.Close();
        }
    }

}

