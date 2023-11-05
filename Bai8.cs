using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace netdemo
{
    class Nguoi2
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string QueQuan { get; set; }
        public int MaSoGiaoVien { get; set; }
    }
    class CBGV : Nguoi2
    {
        public int LuongCung { get; set; }
        public int LuongThuong { get; set; }
        public int LuongPhat { get; set; }
        public int LuongThucLinh { get; set; }

        public CBGV(string hoTen, int tuoi, string queQuan, int maSoGiaoVien, int luongCung, int luongThuong, int luongPhat, int luongThucLinh)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            QueQuan = queQuan;
            MaSoGiaoVien = maSoGiaoVien;
            LuongCung = luongCung;
            LuongThuong = luongThuong;
            LuongPhat = luongPhat;
            TinhLuongThucLinh();
        }
        public void TinhLuongThucLinh()
        {
            LuongThucLinh = LuongCung + LuongThuong - LuongPhat;
        }

    }
    static class Bai8
    {
        static List<CBGV> DanhSachCBGV = new List<CBGV>();
        static void ThemCBGV(string hoTen, int tuoi, string queQuan, int maSoGiaoVien, int luongCung, int luongThuong, int tienPhat, int luongThucLinh)
        {
            CBGV cbgv = new CBGV(hoTen, tuoi, queQuan, maSoGiaoVien, luongCung, luongThuong, tienPhat, luongThucLinh);
            DanhSachCBGV.Add(cbgv);
            Console.WriteLine("Thêm thành công");
        }
        static void XoaCBGV(int maSoGiaoVien)
        {
            CBGV cbgv = DanhSachCBGV.Find(x => x.MaSoGiaoVien == maSoGiaoVien);
            if (cbgv != null)
            {
                DanhSachCBGV.Remove(cbgv);
                Console.WriteLine("Xóa thành công");
            }
            else
            {
                Console.WriteLine("Không tìm thấy");
            }
        }
        public static void Main()
        {
            CBGV cbgv1 = new CBGV("Nguyen Van A", 20, "Ha Noi", 1111, 1000, 500, 100, 1500);
            cbgv1.TinhLuongThucLinh(); // Gọi hàm tính lương thực lĩnh
            CBGV cbgv2 = new CBGV("Nguyen Van B", 21, "Ha Noi", 1112, 1000, 500, 700, 2000);
            cbgv2.TinhLuongThucLinh();
            CBGV cbgv3 = new CBGV("Nguyen Van C", 22, "Ha Noi", 1113, 1000, 500, 500, 2500);
            cbgv3.TinhLuongThucLinh();
            CBGV cbgv4 = new CBGV("Nguyen Van D", 23, "Ha Noi", 1114, 1000, 500, 400, 3000);
            cbgv4.TinhLuongThucLinh();
            CBGV cbgv5 = new CBGV("Nguyen Van E", 24, "Ha Noi", 1115, 1000, 500, 500, 3500);
            cbgv5.TinhLuongThucLinh();



            DanhSachCBGV.Add(cbgv1); // Thêm giáo viên vào danh sách
            DanhSachCBGV.Add(cbgv2);
            DanhSachCBGV.Add(cbgv3);
            DanhSachCBGV.Add(cbgv4);
            DanhSachCBGV.Add(cbgv5);
            Console.WriteLine("Danh sách giáo viên");
            foreach (CBGV cbgv in DanhSachCBGV)
            {
                Console.WriteLine(cbgv.MaSoGiaoVien + " " + cbgv.HoTen + " " + cbgv.Tuoi + " " + cbgv.QueQuan + " " + cbgv.LuongThucLinh);
                Console.WriteLine("Luong Thuc Linh: " + cbgv.LuongThucLinh);
                Console.WriteLine();
            }
            // Thêm một giáo viên mới
            ThemCBGV("Nguyen Van F", 25, "Ha Noi", 1116, 1000, 500, 600, 4000);
            // Xoá một giáo viên bằng mã số giáo viên
            XoaCBGV(1112);
            Console.WriteLine("Danh sách giáo viên sau thêm và xoá:");
            foreach (CBGV cbgv in DanhSachCBGV)
            {
                Console.WriteLine(cbgv.MaSoGiaoVien + " " + cbgv.HoTen + " " + cbgv.Tuoi + " " + cbgv.QueQuan + " " + cbgv.LuongThucLinh);
                Console.WriteLine("Luong Thuc Linh: " + cbgv.LuongThucLinh);
                Console.WriteLine();
            }
        }
    }
}