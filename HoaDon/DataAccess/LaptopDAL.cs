using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoaDon.Entities;
using HoaDon.Business;

namespace HoaDon.DataAccess
{
    class LaptopDAL : ILaptopDAL
    {
        //Xác định đường dẫn của tệp dữ liệu Laptop.txt
        private string txtfile = "Data/Laptop.txt";
        //Lấy toàn bộ dữ liệu có trong file Laptop.txt đưa vào một danh sách 
        public List<Laptop> GetAllLaptop()
        {
            List<Laptop> list = new List<Laptop>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new Laptop(a[0], a[1], a[2], int.Parse(a[3])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Chèn một bản ghi học sinh vào tệp
        public void ThemLaptop(Laptop lt)
        {
            string maLaptop = "LT" + DateTime.Now.ToString("yyMMddhhmmss");
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(maLaptop + "#" + lt.TenLT + "#" + lt.Mau + "#" + lt.DonGia);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<Laptop> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].MaLT + "#" + list[i].TenLT + "#" + list[i].Mau + "#" + list[i].DonGia);
            fwrite.Close();
        }
    }
}

