using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
}