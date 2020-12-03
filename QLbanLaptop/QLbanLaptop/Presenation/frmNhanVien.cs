using System;
using System.Collections.Generic;
using System.Text;
using Đồ_án_1.Business;
using Đồ_án_1.Business.Interface;
using Đồ_án_1.Entities;
using HoaDon;

namespace Đồ_án_1.Presenation
{
    public class frmNhanVien
    {
        private INhanvienBLL ltDLL = new NhanVienBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHAP THONG TIN LAPTOP");
            Nhanvien NV = new Nhanvien();
            Console.Write("nhap ma Nhan Vien :"); NV.MaNhanVien = Console.ReadLine();
            Console.Write("Nhap ten nhan vien :"); NV.TenNhanVien = Console.ReadLine();
            Console.Write("nhap dia chi :"); NV.DiaChiNV = Console.ReadLine();
            Console.Write("Nhap so dien thoai :"); NV.SoDienThoaiNV = Console.ReadLine();
            Console.Write(" nhap dia chi gmail :");NV.Gmail = Console.ReadLine();
            Console.Write("nhap luong co ban :");NV.LuongCoBan = int.Parse(Console.ReadLine());
            ltDLL.ThemNhanVien(NV);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("HIEN THI THONG TIN LAPTOP");
            List<Nhanvien> list = ltDLL.GetAllNhanVien();
            foreach (var NV in list)
                Console.WriteLine(NV.MaNhanVien + "\t\t" + NV.TenNhanVien + "\t\t" + NV.DiaChiNV + "\t\t" + NV.SoDienThoaiNV + "\t\t" + NV.Gmail + "\t\t" + NV.LuongCoBan);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN LAPTOP");
            List<Nhanvien> list = ltDLL.GetAllNhanVien();
            string MaNV;
            Console.Write("Nhap ma nhan vien can sua:");
            MaNV = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaNhanVien == MaNV) break;

            if (i < list.Count)
            {
                Nhanvien NV = new Nhanvien(list[i]);
                Console.Write("Nhap Ma moi:");
                string ma = Console.ReadLine();
                if (!string.IsNullOrEmpty(ma)) NV.MaNhanVien = ma;
                Console.Write("nhap sdt:");
                string sdt= Console.ReadLine();
                if (!string.IsNullOrEmpty(sdt)) NV.SoDienThoaiNV = sdt;
                Console.Write("nhap gmail:");
                string gmail = Console.ReadLine();
                if (!string.IsNullOrEmpty(gmail)) NV.Gmail = gmail;
                Console.Write("nhap luong co ban:");
                int Luongcb = int.Parse(Console.ReadLine());
                if (Luongcb > 0) NV.LuongCoBan = Luongcb;
                ltDLL.SuaNhanVien(NV);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma san pham nay");
            }

        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("thong tin laptop can tim...");
            List<Nhanvien> list = ltDLL.GetAllNhanVien();
            string MaNV;
            Console.Write("nhap ma NhanVien can tim : ");
            MaNV = Console.ReadLine();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].MaNhanVien == MaNV)
                    Console.WriteLine(list[i].MaNhanVien + "#" + list[i].TenNhanVien + "#" + list[i].DiaChiNV + "#" + list[i].SoDienThoaiNV + "#" + list[i].Gmail + "#" + list[i].LuongCoBan);
                else
                {
                    Console.WriteLine("Khong ton tai ma san pham nay");
                }

        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("QUAN LY THONG TIN SAN PHAM");
                Console.WriteLine(" 1.Nhap Nhan Vien ");
                Console.WriteLine(" 2.Sua NHAN Vien ");
                Console.WriteLine(" 3.Xoa Nhan Vien ");
                Console.WriteLine(" 4.Hien danh sach ");
                Console.WriteLine(" 5.Tim kiem ");
                Console.WriteLine(" 6.Back ");
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        Nhap();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F4:
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F2:
                        Sua();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F6:
                        Program.Menu();
                        break;
                    case ConsoleKey.F5:
                        TimKiem();
                        Console.WriteLine("nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }
    }
}

