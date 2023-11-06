using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netdemo
{
    class SinhVien
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string Lop { get; set; }

    }
    class TheMuon : SinhVien
    {
        public int MaPhieuMuon { get; set; }
        public int NgayMuon { get; set; }
        public int HanTra { get; set; }
        public int SoHieuSach { get; set; }
        public TheMuon theMuon { get; set; }

        public TheMuon(string hoTen, int tuoi, string lop, int maPhieuMuon, int ngayMuon, int hanTra, int soHieuSach)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            Lop = lop;
            MaPhieuMuon = maPhieuMuon;
            NgayMuon = ngayMuon;
            HanTra = hanTra;
            SoHieuSach = soHieuSach;
        }
    }
    class ThuVien
    {
        private List<TheMuon> danhSachTheMuon = new List<TheMuon>();
        public void ThemTheMuon()
        {
            Console.WriteLine("Nhap ho ten: ");
            string hoTen = Console.ReadLine();
            Console.WriteLine("Nhap tuoi: ");
            int tuoi = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap lop: ");
            string lop = Console.ReadLine();
            Console.WriteLine("Nhap ma phieu muon: ");
            int maPhieuMuon = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap ngay muon: ");
            int ngayMuon = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap han tra: ");
            int hanTra = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap so hieu sach: ");
            int soHieuSach = int.Parse(Console.ReadLine());
            TheMuon theMuon = new TheMuon(hoTen, tuoi, lop, maPhieuMuon, ngayMuon, hanTra, soHieuSach);
        }
    }
}