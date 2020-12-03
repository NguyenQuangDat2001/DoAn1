using HoaDon.Presenation;
using Đồ_án_1.Presenation;
using System;

namespace HoaDon
{
    public class Program
    {
        public static void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(" F1.Quan ly khach hang ");
                Console.WriteLine(" F2.Quan ly san pham ");
                Console.WriteLine(" F3.Quan ly nhan vien ");
                Console.WriteLine(" F4.Quan ly hoa don ");
                Console.WriteLine(" F5.Bao cao/Thong ke ");
                Console.WriteLine(" F6.Ket thuc ");
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F2:
                        frmLaptop frm = new frmLaptop();
                        frm.Menu();
                        break;
                    case ConsoleKey.F6:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.F3:
                        frmNhanVien frm1 = new frmNhanVien();
                        frm1.Menu();
                        break;
                }
            } while (true);
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
