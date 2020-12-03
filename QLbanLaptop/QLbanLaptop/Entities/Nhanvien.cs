using System;
using System.Collections.Generic;
using System.Text;

namespace Đồ_án_1.Entities
{
    public class Nhanvien
    {
        private string MaNV;
        private string TenNV;
        private string diachi;
        private string sdt;
        private string gmail;
        private double hsl= 2.4;
        private int luongcb;
        public string MaNhanVien
        {
            get { return MaNV; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    MaNV = value;
            }
        }
        public string TenNhanVien
        {
            get { return TenNV; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    TenNV = value;
            }
        }
        public string DiaChiNV
        {
            get { return diachi; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    diachi = value;
            }
        }
        public string SoDienThoaiNV
        {
            get { return sdt; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    sdt = value;
            }
        }
        public string Gmail
        {
            get { return gmail; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    gmail = value;
            }
        }
        public double HeSoLuong
        {
            get { return hsl; }
            set
            {
                if (value > 0)
                    hsl = value;
            }
        }
        public int LuongCoBan
        {
            get { return luongcb; }
            set
            {
                if (value >= 0)
                    luongcb = value;
            }
        }
        public Nhanvien() { }
        public Nhanvien(string MaNV, string TenNV, string diachi, string sdt, string gmail, double hsl, int luongcb)
        {
            this.MaNV = MaNV;
            this.TenNV = TenNV;
            this.diachi = diachi;
            this.sdt = sdt;
            this.gmail = gmail;
            this.hsl = hsl;
            this.luongcb = luongcb;
        }
        public Nhanvien(Nhanvien NV)
        {
            this.MaNV = NV.MaNV;
            this.TenNV = NV.TenNV;
            this.diachi = NV.diachi;
            this.sdt = NV.sdt;
            this.gmail = NV.gmail;
            this.hsl = NV.hsl;
            this.luongcb = NV.luongcb;
        }
        public double tinhLuonh
        {
            get
            {
                return luongcb * hsl;
            }
        }
    }
}
   