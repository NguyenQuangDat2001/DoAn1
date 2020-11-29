using System;
using System.Collections.Generic;
using System.Text;

namespace HoaDon.Entities
{
    public class Laptop
    {

        #region Các thành phần dữ liệu
        private string maLaptop;
        private string tenLaptop;
        private string mau;
        private int dongia;
        #endregion

        #region Các thuộc tính
        public string MaLT
        {
            get { return maLaptop; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    maLaptop = value;
            }
        }
        public string TenLT
        {
            get { return tenLaptop; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    tenLaptop = value;
            }
        }
        public string Mau
        {
            get { return mau; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    mau = value;
            }
        }
        public int DonGia
        {
            get { return dongia; }
            set
            {
                if (value > 0)
                    dongia = value;
            }
        }
        #endregion

        #region Các thương thức             
        public Laptop() { }
        //Phương thức thiết lập sao chép
        public Laptop(Laptop lt)
        {
            this.maLaptop = lt.maLaptop;
            this.tenLaptop = lt.tenLaptop;
            this.mau = lt.mau;
            this.dongia = lt.dongia;
        }
        public Laptop(string maLaptop, string tenLaptop,string mau, int dongia)
        {
            this.maLaptop = maLaptop;
            this.tenLaptop = tenLaptop;
            this.mau = mau;
            this.dongia = dongia;
        }
        #endregion
    }
}
