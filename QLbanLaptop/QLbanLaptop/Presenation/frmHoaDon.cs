using Đồ_án_1.Business;
using Đồ_án_1.Business.Interface;
using Đồ_án_1.Entities;
using HoaDon;
using System;
using System.Collections.Generic;
using System.Text;

namespace Đồ_án_1.Presenation
{
    public class frmHoaDon
    {
        private IHoaDonBLL hdBLL = new HoaDonBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("------------------------------Nhập thông tin hóa đơn------------------------------");
            Hoadon hd = new Hoadon();
            //Console.Write("Mã hóa đơn:"); hd.MaHoaDon = Console.ReadLine();
            Console.Write("Tên Laptop:"); hd.tenlaptop = Console.ReadLine();
            Console.Write("Ngày bán:"); hd.NgayBan = Console.ReadLine();
            Console.Write("Số lượng:"); hd.SoLuong = int.Parse(Console.ReadLine());
            Console.Write("Tổng tiền" +
                ":"); hd.TongTien = int.Parse(Console.ReadLine());
            hdBLL.ThemHoaDon(hd);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("------------------------------thông tin hóa đơn------------------------------");
            Console.WriteLine("Mã hóa đơn | tên laptop | Ngày bán | số lượng | tổng tiền ");
            List<Hoadon> list = hdBLL.GetAllHoadon();
            foreach (var hd in list)
                Console.WriteLine(hd.MaHoaDon + "\t" + hd.tenlaptop + "\t" + hd.NgayBan + "\t" + hd.SoLuong + "\t" + hd.TongTien);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("------------------------------Thông tin hóa đơn------------------------------");
            List<Hoadon> list = hdBLL.GetAllHoadon();
            string mahoadon;
            Console.Write("Nhập mã hóa đơn cần sửa :");
            mahoadon = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaHoaDon == mahoadon) break;

            if (i < list.Count)
            {
                Hoadon hd = new Hoadon(list[i]);
                Console.Write("Tên laptop:");
                string tenlaptop = Console.ReadLine();
                if (tenlaptop != "")
                    hd.tenlaptop = tenlaptop;
                Console.Write("Ngày bán:");
                string ngayban = Console.ReadLine();
                hd.NgayBan = ngayban;
                Console.Write("số lượng:");
                int soluong = int.Parse(Console.ReadLine());
                if (soluong > 0) hd.SoLuong = soluong;
                Console.Write("Tổng tiền:");
                int tongtien = int.Parse(Console.ReadLine());
                if (tongtien > 0) hd.TongTien = tongtien;
                hdBLL.SuaHoaDon(hd);
            }
            else
            {
                Console.WriteLine("                        Không tồn tại mã này!!!");
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("------------------------------Xóa thông tin hóa đơn------------------------------");
            List<Hoadon> list = hdBLL.GetAllHoadon();
            string mahoadon;
            Console.Write("Nhập mã hóa đơn cần xóa:");
            mahoadon = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaHoaDon == mahoadon) break;

            if (i < list.Count)
            {
                list.RemoveAt(i);
                hdBLL.XoaHoaDon(mahoadon);
            }
            else
            {
                Console.WriteLine("                         Không tồn tại mã này !!!");
            }
        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("------------------------------thông tin hóa đơn------------------------------");
            List<Hoadon> list = hdBLL.GetAllHoadon();

            Console.Write("Nhập Mã hóa đơn cần tìm:");
            string tt = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; i++)
                if (list[i].MaHoaDon == tt) break;
            if (i < list.Count)
            {
                List<Hoadon> grt = hdBLL.TimHoaDon(new Hoadon(list[i]));
                foreach (var x in grt)

                    Console.WriteLine(x.MaHoaDon + "\t" + x.tenlaptop + "\t" + x.NgayBan + "\t" + x.SoLuong + "\t" + x.TongTien);
            }

            else Console.WriteLine("                         Không tồn tại mã này!!!");


        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------Quản lý hóa đơn------------------------------");
                Console.WriteLine("                                  F1.Nhập hóa đơn                           ");
                Console.WriteLine("                                  F2.Sửa hóa đơn                            ");
                Console.WriteLine("                                  F3.Xóa hóa đơn                            ");
                Console.WriteLine("                                  F4.Hiện danh sách hóa đơn                 ");
                Console.WriteLine("                                  F5.Tìm kiếm hóa đơn                       ");
                Console.WriteLine("                                  F6.Thoát                                  ");
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        Nhap();
                        Hien();
                        Console.WriteLine("                        Nhập phím bất kỳ để tiếp tục...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F4:
                        Hien();
                        Console.WriteLine("                        Nhập phím bất kỳ để tiếp tục...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F2:
                        Sua();
                        Hien();
                        Console.WriteLine("                        Nhập phím bất kỳ để tiếp tục...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F3:
                        Xoa();
                        Hien();
                        Console.WriteLine("                        Nhập phím bất kỳ để tiếp tục...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F5:
                        TimKiem();
                        Console.WriteLine("                        Nhập phím bất kỳ để tiếp tục...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F6:
                        Program.Menu();
                        break;
                }
            } while (true);
        }

    }
}
