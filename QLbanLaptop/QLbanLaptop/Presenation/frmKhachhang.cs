using Đồ_án_1.Business;
using Đồ_án_1.Business.Interface;
using Đồ_án_1.Entities;
using HoaDon;
using System;
using System.Collections.Generic;
using System.Text;

namespace Đồ_án_1.Presenation
{
    class frmKhachhang
    {
        private IKhachHangBLL khBLL = new KhachHangBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("                                                 THÔNG TIN KHÁCH HÀNG");
            KhachHang kh = new KhachHang();
            //Console.Write("                                                 Nhập mã khách hàng:"); kh.MaKhach = Console.ReadLine();
            Console.Write("                                                 Nhập tên khách hàng:"); kh.Hoten = (Console.ReadLine());
            Console.Write("                                                 Nhập quê quán khách hàng :"); kh.QueQuan = Console.ReadLine();
            Console.Write("                                                 Nhập địa chỉ khách hàng:"); kh.DiaChi = Console.ReadLine();
            Console.Write("                                                 Nhập số điện thoại :"); kh.SodienThoai = Console.ReadLine();
            khBLL.ThemKhachHang(kh);
        }
        public void Hien()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("                         HIỂN THỊ THÔNG TIN KHÁCH HÀNG");
            Console.WriteLine("\t\t\t"+"Mã Kh\t\t|\tTên KH\t   |Quê quán\t|Địa chỉ\t|Số điện thoại");
            List<KhachHang> list = khBLL.GetAllKhachHang();
            foreach (var kh in list)
                Console.WriteLine("\t\t\t"+kh.MaKhach + "\t" + kh.Hoten + "\t" + kh.QueQuan + "\t" + kh.DiaChi + "\t" + kh.SodienThoai);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("             THÔNG TIN KHÁCH HÀNG");
            List<KhachHang> list = khBLL.GetAllKhachHang();
            string makhachhang;
            Console.Write("             Nhập mã khách hàng cần sửa:");
            makhachhang = Console.ReadLine();
            int i;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaKhach == makhachhang)
                    break;
            if (i < list.Count)
            {
                KhachHang kh = new KhachHang(list[i]);
                Console.Write( "            Nhập họ tên khách hàng :");
                string ten = Console.ReadLine();
                if (!string.IsNullOrEmpty(ten)) kh.MaKhach = ten;
                Console.Write("             Nhập quê quán :");
                string que = Console.ReadLine();
                if (!string.IsNullOrEmpty(que)) kh.QueQuan = que;
                Console.Write("             Nhập địa chỉ :");
                string dc = Console.ReadLine();
                if (!string.IsNullOrEmpty(dc)) kh.DiaChi = dc;
                Console.Write("             Nhập số điện thoại:");
                string sdt = Console.ReadLine();
                if (!string.IsNullOrEmpty(sdt)) kh.SodienThoai = sdt;
                khBLL.SuaKhachHang(kh);
            }
            else
            {
                Console.WriteLine("Không tồn tại mã khách hàng này");
            }  
        }
        public void Tim()
        {
            Console.Clear();
            IKhachHangBLL Khachhang = new KhachHangBLL();
            List<KhachHang> list = Khachhang.TimKhachHang(new KhachHang());
            string makhach;
            Console.Write("Nhập mã khách hàng cần tìm:");
            makhach = Console.ReadLine();
            for (int i = 0; i < list.Count; ++i)
            {
                if (makhach == list[i].MaKhach)
                    Console.WriteLine(list[i].MaKhach + "\t" + list[i].Hoten + "\t" + list[i].QueQuan + "\t" + list[i].DiaChi + "\t" + list[i].SodienThoai);
                else
                    Console.WriteLine("Không tồn tại mã khách hàng này");
            }
            //string tenkhachhang;
            //Console.Write("Nhập tên khách hàng cần tìm:");
            //tenkhachhang = Console.ReadLine();
            //for (int i = 0; i < list.Count; ++i)
            //{
            //    if (tenkhachhang == list[i].Hoten)
            //        Console.WriteLine(list[i].MaKhach + "\t" + list[i].Hoten + "\t" + list[i].QueQuan + "\t" + list[i].DiaChi + "\t" + list[i].SodienThoai);
            //    else
            //        Console.WriteLine("Không tồn tại mã khách hàng này");
            //}
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine(" THÔNG TIN KHÁCH HÀNG");
            List<KhachHang> list = khBLL.GetAllKhachHang();
            string makhachhang;
            Console.Write("Nhập mã khách hàng cần xóa :");
            makhachhang = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaKhach == makhachhang) break;

            if (i < list.Count)
            {
                list.RemoveAt(i);
                khBLL.XoaKhachHang(makhachhang);
            }
              else
                Console.WriteLine("không tồn tại mã khách hàng này");
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("                                 QUẢN LÝ THÔNG TIN KHÁCH HÀNG");
                Console.WriteLine("                                 F1.Nhập thông tin khách hàng ");
                Console.WriteLine("                                 F2.sửa thông tin  khách hàng ");
                Console.WriteLine("                                 F3.Tìm thông tin khách hàng ");
                Console.WriteLine("                                 F4.Hiển thị danh sách khách hàng ");
                Console.WriteLine("                                 F5.Xóa thông tin khách hàng ");
                Console.WriteLine("                                 F6.thoát ");
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        Nhap();
                        Hien();
                        Console.WriteLine("..................................Nhập phím bất kỳ để tiếp tục...............................");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F2:
                        Sua();
                        Hien();
                        Console.WriteLine("..................................Nhập phím bất kỳ để tiếp tục...............................");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F3:
                        Tim();
                        Console.WriteLine("..................................Nhập phím bất kỳ để tiếp tục...............................");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F4:
                        Hien();
                        Console.WriteLine("..................................Nhập phím bất kỳ để tiếp tục...............................");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F5:
                        Xoa();
                        Hien();
                        Console.WriteLine("..................................Nhập phím bất kỳ để tiếp tục...............................");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F6:
                        Program.Menu();
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }
    }
}
