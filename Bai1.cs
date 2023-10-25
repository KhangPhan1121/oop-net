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
        public string hoten { get; set; }
        public int tuoi { get; set; }
        public string gioitinh { get; set;}
        public string diachi { get; set; }
    }
    class CongNhan : CanBo
    {
        public int Bac { get; set; }
    }
    class KySu : CanBo
    {
        public string nganhdaotao { get; set; }
    }
    class NhanVien : CanBo
    {
        public string congviec { get; set; }
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
            List<CanBo> ketQuaTimKiem = danhsachCanBo.FindAll(canBo => canBo.hoten.Equals(hoTen, StringComparison.OrdinalIgnoreCase));
            return ketQuaTimKiem;
        }    
        public void HienThiDanhSachCanBo()
        {
            Console.WriteLine("Danh sách cán bộ: ");
            
        }
    }
}