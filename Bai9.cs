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
        public List<TheMuon> danhSachTheMuon = new List<TheMuon>();

        public void ThemTheMuon(string hoTen, int tuoi, string lop, int maPhieuMuon, int ngayMuon, int hanTra, int soHieuSach)
        {
            TheMuon theMuon = new TheMuon(hoTen, tuoi, lop, maPhieuMuon, ngayMuon, hanTra, soHieuSach);
            danhSachTheMuon.Add(theMuon);
        }
        public void XoaTheMuon(int maPhieuMuon)
        {
            TheMuon theMuonToDelete = danhSachTheMuon.FirstOrDefault(theMuon => theMuon.MaPhieuMuon == maPhieuMuon);
            if (theMuonToDelete != null)
            {
                danhSachTheMuon.Remove(theMuonToDelete);
                Console.WriteLine("Đã xoá thẻ mượn sách có mã phiếu mượn: " + maPhieuMuon);
            }
            else
            {
                Console.WriteLine("Không tìm thấy thẻ mượn sách với mã phiếu mượn: " + maPhieuMuon);
            }
        }
        public void HienThiDanhSachTheMuon()
        {
            Console.WriteLine("Danh sách thẻ mượn sách:");
            foreach (var theMuon in danhSachTheMuon)
            {
                Console.WriteLine($"Họ tên: {theMuon.HoTen}, Mã phiếu mượn: {theMuon.MaPhieuMuon}, Số hiệu sách: {theMuon.SoHieuSach}");
            }
        }

    }
    static class Bai9
    {
        public static void Main()
        {
            ThuVien thuVien = new ThuVien();
            while (true)
            {
                Console.WriteLine("Chon tac vu:");
                Console.WriteLine("1. Them the muon sach");
                Console.WriteLine("2. Xoa the muon sach");
                Console.WriteLine("3. Hien Thi Danh Sach The Muon Sach");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Nhap ho ten: ");
                        string hoTen = Console.ReadLine();
                        Console.Write("Nhap tuoi: ");
                        int tuoi = int.Parse(Console.ReadLine());
                        Console.Write("Nhap lop: ");
                        string lop = Console.ReadLine();
                        Console.Write("Nhap ma phieu muon: ");
                        int maPhieuMuon = int.Parse(Console.ReadLine());
                        Console.Write("Nhap ngay muon: ");
                        int ngayMuon = int.Parse(Console.ReadLine());
                        Console.Write("Nhap han tra: ");
                        int hanTra = int.Parse(Console.ReadLine());
                        Console.Write("Nhap so hieu sach: ");
                        int soHieuSach = int.Parse(Console.ReadLine());

                        thuVien.ThemTheMuon(hoTen, tuoi, lop, maPhieuMuon, ngayMuon, hanTra, soHieuSach);
                        Console.WriteLine("Them the muon sach thanh cong.");
                        break;
                    case 2:
                        Console.Write("Nhap ma phieu muon can xoa: ");
                        int maPhieuMuonToDelete = int.Parse(Console.ReadLine());
                        thuVien.XoaTheMuon(maPhieuMuonToDelete);
                        break;
                    case 3:
                        Console.WriteLine("Danh sach the muon sach:");
                        foreach (var theMuon in thuVien.danhSachTheMuon)
                        {
                            Console.WriteLine($"Ho ten: {theMuon.HoTen}, Ma phieu muon: {theMuon.MaPhieuMuon}, So hieu sach: {theMuon.SoHieuSach}");
                        }
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
        }
    }
}