using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netdemo
{
    class HocSinh
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string QueQuan { get; set; }

        public HocSinh(string hoTen, int tuoi, string queQuan)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            QueQuan = queQuan;
        }
    }
    static class Bai7
    {
        static List<HocSinh> danhSachHocSinh = new List<HocSinh>();
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Chuong trinh quan ly ho so hoc sinh");
                Console.WriteLine("1. Them hoc sinh moi");
                Console.WriteLine("2. Hien thi cac hoc sinh 20 tuoi");
                Console.WriteLine("3. Hien thi so luong hoc sinh có tuoi la 23 va que o Da Nang");
                Console.WriteLine("4. Thoát");

                Console.WriteLine("Chon chuc nang: ");
                int chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1:
                        ThemHocSinh();
                        break;
                    case 2:
                        HienThiHocSinh20Tuoi();
                        break;
                    case 3:
                        HienThiSoLuongHocSinh23TuoiQuaDaNang();
                        break;
                    case 4:
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("chọn chức năng không hợp lệ. vui lòng chọn lại.");
                        break;
                }
            }
        }
        static void ThemHocSinh()
        {
            Console.WriteLine("Nhap ho ten: ");
            string hoTen = Console.ReadLine();

            Console.WriteLine("Nhap tuoi: ");
            int tuoi = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhap que quan: ");
            string queQuan = Console.ReadLine();

            HocSinh hocSinh = new HocSinh(hoTen, tuoi, queQuan);
            danhSachHocSinh.Add(hocSinh);
            Console.WriteLine("Them hoc sinh moi thanh cong.");
        }
        static void HienThiHocSinh20Tuoi()
        {
            Console.WriteLine("Danh sach hoc sinh 20 tuoi: ");
            foreach (HocSinh hocSinh in danhSachHocSinh)
            {
                if (hocSinh.Tuoi == 20)
                {
                    Console.WriteLine(hocSinh.HoTen);
                }
            }
        }
        static void HienThiSoLuongHocSinh23TuoiQuaDaNang()
        {
            int Count = danhSachHocSinh.Count(hocSinh => hocSinh.Tuoi == 23 && hocSinh.QueQuan == ("ĐaNang"));
            Console.WriteLine("So luong hoc sinh co tuoi la 23 va que o Da Nang: " + Count);
        }
    }
}