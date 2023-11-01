using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace netdemo
{
    public class Bai5
    {
        class Nguoi
        {
            public string HoTen { get; set; }
            public int Tuoi { get; set; }
            public string NgheNghiep { get; set; }
            public string SoCMND { get; set; }

            public Nguoi(string hoTen, int tuoi, string ngheNgiep, string soCMND)
            {
                HoTen = hoTen;
                Tuoi = tuoi;
                NgheNghiep = ngheNgiep;
                SoCMND = soCMND;
            }
        }
        class HoGiaDinh
        {
            public int SoThanhVienTGD { get; set; }
            public int SoNha { get; set; }
            public List<Nguoi> DanhSachNguoi { get; set; }
            
            public HoGiaDinh(int soThanhVienTGD, int soNha)
            {
                SoThanhVienTGD = soThanhVienTGD;
                SoNha = soNha;
                DanhSachNguoi = new List<Nguoi>();
            }

            public void ThemNguoi (Nguoi nguoi)
            {
                DanhSachNguoi.Add(nguoi);
            }
        }
        class KhuPho
        {
            public List<HoGiaDinh> DanhSachHoGiaDinh { get; set; }
            public KhuPho()
            {
                DanhSachHoGiaDinh = new List<HoGiaDinh>();
            }
            public void ThemHoGiaDinh(HoGiaDinh hoGiaDinh)
            {
                DanhSachHoGiaDinh.Add(hoGiaDinh);
            }
            public void HienThongTinKhuPho()
            {
                Console.WriteLine("Thông tin khu phố: ");
                foreach (var hoGiaDinh in DanhSachHoGiaDinh)
                {
                    Console.WriteLine($"Số nhà: {hoGiaDinh.SoNha}");
                    Console.WriteLine($"Số thành viên: {hoGiaDinh.SoThanhVienTGD}");
                    Console.WriteLine("Danh sách các người trong hộ gia đình:");
                    foreach (var nguoi in hoGiaDinh.DanhSachNguoi)
                    {
                        Console.WriteLine($"Họ tên: {nguoi.HoTen}");
                        Console.WriteLine($"Tuổi: {nguoi.Tuoi}");
                        Console.WriteLine($"Nghề nghiệp: {nguoi.NgheNghiep}");
                        Console.WriteLine($"Số CMND: {nguoi.SoCMND}");
                    }
                    Console.WriteLine();
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Nhập số hộ dân trong khu phố:");
                int n = int.Parse(Console.ReadLine());

                KhuPho khuPho = new KhuPho();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Nhập thông tin hộ gia đình {i + 1}:");

                    Console.Write("Số nhà: ");
                    int soNha = int.Parse(Console.ReadLine());

                    Console.Write("Số thành viên trong hộ: ");
                    int soThanhVien = int.Parse(Console.ReadLine());

                    HoGiaDinh hoGiaDinh = new HoGiaDinh(soThanhVien, soNha);

                    for (int j = 0; j < soThanhVien; j++)
                    {
                        Console.WriteLine($"Nhập thông tin cá nhân {j + 1} trong hộ gia đình:");

                        Console.Write("Họ tên: ");
                        string hoTen = Console.ReadLine();

                        Console.Write("Tuổi: ");
                        int tuoi = int.Parse(Console.ReadLine());

                        Console.Write("Nghề nghiệp: ");
                        string ngheNghiep = Console.ReadLine();

                        Console.Write("Số CMND: ");
                        string soCMND = Console.ReadLine();

                        Nguoi nguoi = new Nguoi(hoTen, tuoi, ngheNghiep, soCMND);

                        hoGiaDinh.ThemNguoi(nguoi);
                    }
                    khuPho.ThemHoGiaDinh(hoGiaDinh);
                }
                khuPho.HienThongTinKhuPho();
            }
        }
    }
}
//Parse là một phương thức được sử dụng để chuyển đổi một chuỗi thành một giá trị của kiểu dữ liệu cụ thể.