using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netdemo
{
    class KhachHang
    {
        public string HoTen { get; set; }
        public string SoNha { get; set; }
        public string MaCongTo { get; set; }

        public KhachHang(string hoTen, string soNha, string maCongTo)
        {
            HoTen = hoTen;
            SoNha = soNha;
            MaCongTo = maCongTo;
        }
    }

    class BienLai
    {
        public KhachHang KhachHang { get; set; }
        public int ChiSoCu { get; set; }
        public int ChiSoMoi { get; set; }

        public BienLai(KhachHang khachHang, int chiSoCu, int chiSoMoi)
        {
            KhachHang = khachHang;
            ChiSoCu = chiSoCu;
            ChiSoMoi = chiSoMoi;
        }

        public double TinhTienDien()
        {
            int soTien = (ChiSoMoi - ChiSoCu) * 5;
            return soTien;
        }
    }

    class QuanLyBienLai
    {
        public List<BienLai> danhSachBienLai = new List<BienLai>();

        public void ThemBienLai(BienLai bienLai)
        {
            danhSachBienLai.Add(bienLai);
        }

        public void XoaBienLai(string maCongToToDelete)
        {
            BienLai bienLaiCanXoa = danhSachBienLai.Find(bienLai => bienLai.KhachHang.MaCongTo == maCongToToDelete);
            if (bienLaiCanXoa != null)
            {
                danhSachBienLai.Remove(bienLaiCanXoa);
            }
        }

        public void SuaBienLai(string maCongToToEdit, int chiSoCuMoi, int chiSoMoiMoi)
        {
            BienLai bienLaiCanSua = danhSachBienLai.Find(bienLai => bienLai.KhachHang.MaCongTo == maCongToToEdit);
            if (bienLaiCanSua != null)
            {
                bienLaiCanSua.ChiSoCu = chiSoCuMoi;
                bienLaiCanSua.ChiSoMoi = chiSoMoiMoi;
            }
        }

        public void HienThiDanhSachBienLai()
        {
            foreach (BienLai bienLai in danhSachBienLai)
            {
                Console.WriteLine($"Ho ten chu ho: {bienLai.KhachHang.HoTen}");
                Console.WriteLine($"So nha: {bienLai.KhachHang.SoNha}");
                Console.WriteLine($"Ma cong to dien: {bienLai.KhachHang.MaCongTo}");
                Console.WriteLine($"Chi so dien cu: {bienLai.ChiSoCu}");
                Console.WriteLine($"Chi so dien moi: {bienLai.ChiSoMoi}");
                Console.WriteLine($"So tien phai tra: {bienLai.TinhTienDien()} VND");
                Console.WriteLine();
            }
        }
    }

    static class Bai10
    {
        // Tạo một đối tượng QuanLyBienLai để quản lý danh sách biên lai.
        public static void Main()
        {
            QuanLyBienLai quanLy = new QuanLyBienLai();

            while (true)
            {
                Console.WriteLine("Chon tac vu:");
                Console.WriteLine("1. Them bien lai");
                Console.WriteLine("2. Xoa bien lai");
                Console.WriteLine("3. Sua bien lai");
                Console.WriteLine("4. Hien thi danh sach bien lai");
                Console.WriteLine("5. Thoat");
                Console.Write("Chon: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Yêu cầu người dùng nhập thông tin để tạo một biên lai mới.
                        Console.Write("Nhap ho ten chu ho: ");
                        string hoTen = Console.ReadLine();
                        Console.Write("Nhap so nha: ");
                        string soNha = Console.ReadLine();
                        Console.Write("Nhap ma cong to dien: ");
                        string maCongTo = Console.ReadLine();
                        Console.Write("Nhap chi so dien cu: ");
                        int chiSoCu = int.Parse(Console.ReadLine());
                        Console.Write("Nhap chi so dien moi: ");
                        int chiSoMoi = int.Parse(Console.ReadLine());

                        // Tạo đối tượng KhachHang và BienLai, sau đó thêm biên lai vào danh sách.
                        KhachHang khachHang = new KhachHang(hoTen, soNha, maCongTo);
                        BienLai bienLai = new BienLai(khachHang, chiSoCu, chiSoMoi);
                        quanLy.ThemBienLai(bienLai);
                        Console.WriteLine("Them bien lai thanh cong.");
                        break;

                    case 2:
                        // Yêu cầu người dùng nhập mã công tơ điện của biên lai cần xóa.
                        Console.Write("Nhap ma cong to dien cua bien lai can xoa: ");
                        string maCongToToDelete = Console.ReadLine();

                        // Gọi phương thức XoaBienLai để xóa biên lai theo mã công tơ điện.
                        quanLy.XoaBienLai(maCongToToDelete);
                        Console.WriteLine("Bien lai da duoc xoa.");
                        break;

                    case 3:
                        // Yêu cầu người dùng nhập mã công tơ điện của biên lai cần sửa.
                        Console.Write("Nhap ma cong to dien cua bien lai can sua: ");
                        string maCongToToEdit = Console.ReadLine();
                        
                        // Yêu cầu người dùng nhập chỉ số điện cũ mới và chỉ số điện mới mới.
                        Console.Write("Nhap chỉ so dien cu moi: ");
                        int chiSoCuMoi = int.Parse(Console.ReadLine());
                        Console.Write("Nhap chi so dien moi moi: ");
                        int chiSoMoiMoi = int.Parse(Console.ReadLine());

                        // Gọi phương thức SuaBienLai để sửa biên lai theo mã công tơ điện và các thông số mới.
                        quanLy.SuaBienLai(maCongToToEdit, chiSoCuMoi, chiSoMoiMoi);
                        Console.WriteLine("Bien lai da duoc sua.");
                        break;

                    case 4:
                        // Hiển thị danh sách biên lai.
                        Console.WriteLine("Danh sach bien lai:");
                        quanLy.HienThiDanhSachBienLai();
                        break;

                    case 5:
                        // Thoát khỏi ứng dụng.
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