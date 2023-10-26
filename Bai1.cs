using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace netdemo
{
    class CanBo
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set;}
        public string DiaChi { get; set; }

        public CanBo(string hoTen, int tuoi, string gioiTinh, string diaChi)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
        }
    }
    class CongNhan : CanBo
    {
        public int Bac { get; set; }

        public CongNhan(string hoTen, int tuoi, string gioiTinh, string diaChi, int bac) : base(hoTen, tuoi, gioiTinh, diaChi)
        {
            Bac = bac;
        }
    }
    class KySu : CanBo
    {
        public string NganhDaoTao { get; set; }

        public KySu(string hoTen, int tuoi, string gioiTinh, string diaChi, string nganhDaoTao) : base(hoTen, tuoi, gioiTinh, diaChi)
        {
            NganhDaoTao = nganhDaoTao;
        }
    }
    class NhanVien : CanBo
    {
        public string CongViec { get; set; }

        public NhanVien(string hoTen, int tuoi, string gioiTinh, string diaChi, string congViec) : base(hoTen, tuoi, gioiTinh, diaChi)
        {
            CongViec = congViec;
        }
    }
    class QLCB
    {
        private List<CanBo> danhsachCanBo = new List<CanBo>(); 
        public void ThemMoiCanBo(CanBo canBo)
        {
            danhsachCanBo.Add(canBo);
        }
        public List<CanBo> TimKiemTheoHoTen(string hoTen)
        {
            return danhsachCanBo.Where(canBo => canBo.HoTen.ToLower().Contains(hoTen.ToLower())).ToList();
        }    
        public void HienThiDanhSachCanBo()
        {
            Console.WriteLine("Danh sách cán bộ: ");
            foreach (var canBo in danhsachCanBo)
            {
                Console.WriteLine($"Họ tên: {canBo.HoTen}, Tuổi: {canBo.Tuoi}, Giới tính: {canBo.GioiTinh}, địa chỉ: {canBo.DiaChi}");
                if (canBo is CongNhan)
                {
                    Console.WriteLine($"Bậc: {(canBo as CongNhan).Bac}");
                }
                else if (canBo is KySu)
                {
                    Console.WriteLine($"Ngành đào tạo: {(canBo as KySu).NganhDaoTao}");
                }
                else if (canBo is NhanVien)
                {
                    Console.WriteLine($"Công việc: {(canBo as NhanVien).CongViec}");
                }
            }
        }
        public void ThoatChươngTrinh()
        {
            Environment.Exit(0);
        }
    }
}