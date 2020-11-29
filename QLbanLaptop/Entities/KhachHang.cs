using System;
using System.Collections.Generic;
using System.Text;

namespace HoaDon.Entities
{
    public class KhachHang
    {
        #region Các thành phần dữ liệu
        private string makhach;
        private string hoten;
        private string quequan;
        private string diachi;
        private string sodienthoai;
        #endregion

        #region Các thuộc tính
        public string MaKhach
        {
            get { return makhach; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    makhach = value;
            }
        }
        public string Hoten
        {
            get { return hoten; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    hoten = value;
            }
        }
        public string QueQuan
        {
            get { return quequan; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    quequan = value;
            }
        }
        public string DiaChi
        {
            get { return diachi; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    diachi = value;
            }
        }
        public string SodienThoai
        {
            get { return sodienthoai; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length == 10)
                    sodienthoai = value;
            }
        }
        #endregion

        #region Các thương thức             
        public KhachHang() { }
        //Phương thức thiết lập sao chép
        public KhachHang(KhachHang kh)
        {
            this.makhach = kh.makhach;
            this.hoten = kh.hoten;
            this.quequan = kh.quequan;
            this.diachi = kh.diachi;
            this.sodienthoai = kh.sodienthoai;
        }
        public KhachHang(string makhach, string hoten, string quequan, string diachi, string sodienthoai)
        {
            this.makhach = makhach;
            this.hoten = hoten;
            this.quequan = quequan;
            this.diachi = diachi;
            this.sodienthoai = sodienthoai;
        }
        #endregion
    }
}
