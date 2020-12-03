using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn1.Business;
using HoaDon.Business;
using HoaDon.Business.Interface;
using HoaDon.Entities;


namespace HoaDon.Presenation
{
    public class frmLaptop
    {
        private ILaptopBLL ltDLL= new LaptopBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHAP THONG TIN LAPTOP");
            Laptop lt = new Laptop();
            Console.Write("nhap ma Laptop :");lt.MaLT = Console.ReadLine();
            Console.Write("Nhap ten Laptop :"); lt.TenLT = Console.ReadLine();
            Console.Write("nhap mau laptop :"); lt.Mau = Console.ReadLine();
            Console.Write("Nhap gia Laptop :"); lt.DonGia = int.Parse(Console.ReadLine());
            ltDLL.ThemLaptop(lt);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("HIEN THI THONG TIN LAPTOP");
            List<Laptop> list = ltDLL.GetAllLaptop();
            foreach (var lt in list)
                Console.WriteLine(lt.MaLT + "\t" + lt.TenLT + "\t" + lt.Mau + "#" + lt.DonGia);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN LAPTOP");
            List<Laptop> list = ltDLL.GetAllLaptop();
            string maLaptop;
            Console.Write("Nhap ma Laptop can sua:");
            maLaptop = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaLT == maLaptop) break;

            if (i < list.Count)
            {
                Laptop lt = new Laptop(list[i]);
                Console.Write("Nhap Ma moi:");
                string ma = Console.ReadLine();
                if (!string.IsNullOrEmpty(ma)) lt.MaLT = ma;
                Console.Write("Gia moi:");
                int gia = int.Parse(Console.ReadLine());
                if (gia > 0) lt.DonGia = gia;
                ltDLL.SuaLaptop(lt);
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
            List<Laptop> list = ltDLL.GetAllLaptop();
            string maLaptop;
            Console.Write("nhap ma laptop can tim : ");
            maLaptop = Console.ReadLine();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].MaLT == maLaptop)
                    Console.WriteLine(list[i].MaLT + "#" + list[i].TenLT + "#" + list[i].Mau + "#" + list[i].DonGia);
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
                Console.WriteLine(" F1.Nhap san pham ");
                Console.WriteLine(" F2.Sua san pham ");
                Console.WriteLine(" F3.Xoa san pham ");
                Console.WriteLine(" F4.Hien danh sach ");
                Console.WriteLine(" F5.Kim kiem ");
                Console.WriteLine(" F6.Back ");
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

