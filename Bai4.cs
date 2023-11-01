using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace netdemo
{
    class ThiSinh
    {
        public int SoBaoDanh { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public int MucUuTien { get; set; }

        public ThiSinh(int soBaoDanh, string hoTen, string diaChi, int mucUuTien)
        {
            SoBaoDanh = soBaoDanh;
            HoTen = hoTen;
            DiaChi = diaChi;
            MucUuTien = mucUuTien;
        }
    }
    class ThiSinhKhoiA : ThiSinh
    {  
        public string Toan { get; set; }
        public string Ly { get; set; }
        public string Hoa { get; set; }

        public ThiSinhKhoiA(int soBaoDanh, string hoTen, string diaChi, int mucUuTien, string toan, string ly, string hoa) : base(soBaoDanh, hoTen, diaChi, mucUuTien)
        {
            Toan = toan;
            Ly = ly;
            Hoa = hoa;
        }

        public void ThiMonKhoiA()
        {
            Console.WriteLine("Thi các môn: Toán, Lý, Hoá");
        }
    }

    class ThiSinhKhoiB : ThiSinh
    {
        public string Toan { get; set; }
        public string Hoa { get; set; }
        public string Sinh { get; set; }

        public ThiSinhKhoiB(int soBaoDanh, string hoTen, string diaChi, int mucUuTien, string toan, string hoa, string sinh) : base(soBaoDanh, hoTen, diaChi, mucUuTien)
        {
            Toan = toan;
            Hoa = hoa;
            Sinh = sinh;
        }

        public void ThiMonKhoiB()
        {
            Console.WriteLine("Thi các môn: Toán, Hoá, Sinh");
        }
    }

    class ThiSinhKhoiC : ThiSinh
    {
        public string Van { get; set; }
        public string Su { get; set; }
        public string Dia { get; set; }
        public ThiSinhKhoiC(int soBaoDanh, string hoTen, string diaChi, int mucUuTien, string van, string su, string dia) : base(soBaoDanh, hoTen, diaChi, mucUuTien)
        {
            Van = van;
            Su = su;
            Dia = dia;
        }

        public void ThiMonKhoiC()
        {
            Console.WriteLine("Thi các môn: Văn, Sử, Địa");
        }
    }
    class TuyenSinh
    {
        private List<ThiSinh> danhSachThiSinh = new List<ThiSinh>();

        public void ThemMoiThiSinh(ThiSinh thiSinh)
        {
            danhSachThiSinh.Add(thiSinh);
        }

        public void HienThiThongTinThiSinh()
        {
            Console.WriteLine("Thông tin các thí sinh:");
            foreach (ThiSinh thiSinh in danhSachThiSinh)
            {
                Console.WriteLine($"Số báo danh: {thiSinh.SoBaoDanh}");
                Console.WriteLine($"Họ tên: {thiSinh.HoTen}");
                Console.WriteLine($"Địa chỉ: {thiSinh.DiaChi}");
                Console.WriteLine($"Mức ưu tiên: {thiSinh.MucUuTien}");
                if (thiSinh is ThiSinhKhoiA)
                {
                    Console.WriteLine("Khối thi: A");
                    ((ThiSinhKhoiA)thiSinh).ThiMonKhoiA();
                }
                else if (thiSinh is ThiSinhKhoiB)
                {
                    Console.WriteLine("Khối thi: B");
                    ((ThiSinhKhoiB)thiSinh).ThiMonKhoiB();
                }
                else if (thiSinh is ThiSinhKhoiC)
                {
                    Console.WriteLine("Khối thi: C");
                    ((ThiSinhKhoiC)thiSinh).ThiMonKhoiC();
                }
                Console.WriteLine();
            }
        }

        public ThiSinh TimKiemTheoSoBaoDanh(int soBaoDanh)
        {
            return danhSachThiSinh.Find(thiSinh => thiSinh.SoBaoDanh == soBaoDanh);
        }
        public void ThoatChuongtrinh()
        {
            Environment.Exit(0);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TuyenSinh tuyenSinh = new TuyenSinh();

            // Tạo ra các thí sinh thuộc từng khối và thêm vào danh sách
            ThiSinhKhoiA thiSinhA = new ThiSinhKhoiA(1, "Nguyen Van A", "Hanoi", 0, "ToanA", "LyA", "HoaA");
            ThiSinhKhoiB thiSinhB = new ThiSinhKhoiB(2, "Tran Thi B", "HCMC", 1, "ToanB", "HoaB", "SinhB");
            ThiSinhKhoiC thiSinhC = new ThiSinhKhoiC(3, "Le Van C", "Da Nang", 2, "VanC", "SuC", "DiaC");

            // Thêm các thí sinh vào danh sách quản lý
            tuyenSinh.ThemMoiThiSinh(thiSinhA);
            tuyenSinh.ThemMoiThiSinh(thiSinhB);
            tuyenSinh.ThemMoiThiSinh(thiSinhC);

            Console.WriteLine("Danh sách thí sinh:");
            tuyenSinh.HienThiThongTinThiSinh();

            Console.WriteLine("Tìm kiếm thí sinh theo số báo danh:");
            int soBaoDanhCanTim = 2;
            ThiSinh timThiSinh = tuyenSinh.TimKiemTheoSoBaoDanh(soBaoDanhCanTim);
            if (timThiSinh != null)
            {
                Console.WriteLine("Thí sinh được tìm thấy:");
                Console.WriteLine($"Số báo danh: {timThiSinh.SoBaoDanh}");
                Console.WriteLine($"Họ tên: {timThiSinh.HoTen}");
                Console.WriteLine($"Địa chỉ: {timThiSinh.DiaChi}");
                Console.WriteLine($"Mức ưu tiên: {timThiSinh.MucUuTien}");
                if (timThiSinh is ThiSinhKhoiA)
                {
                    Console.WriteLine("Khối thi: A");
                    ((ThiSinhKhoiA)timThiSinh).ThiMonKhoiA();
                }
                else if (timThiSinh is ThiSinhKhoiB)
                {
                    Console.WriteLine("Khối thi: B");
                    ((ThiSinhKhoiB)timThiSinh).ThiMonKhoiB();
                }
                else if (timThiSinh is ThiSinhKhoiC)
                {
                    Console.WriteLine("Khối thi: C");
                    ((ThiSinhKhoiC)timThiSinh).ThiMonKhoiC();
                }
            }
            else
            {
                Console.WriteLine($"Không tìm thấy thí sinh có số báo danh {soBaoDanhCanTim}.");
            }
            
            Console.WriteLine("Bấm phím Enter thoát chương trình.");
            Console.ReadLine();
            tuyenSinh.ThoatChuongtrinh();
            
        }
    
    }
}
//