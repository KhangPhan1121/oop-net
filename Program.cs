using System;

namespace netdemo;

interface IRun //Giao diện (Interface)
{
    public void Run();
} 

abstract class Animal //Lớp trừu tượng (Abstract Class)
{
    public string name { get; set; }

    public abstract void Bark();
}
class Dog : Animal, IRun //Kế thừa (Inheritance)
{
    public int Type { get; set; }

    public override void Bark()
    {
        Console.WriteLine("gau");
    }

    public void Run()
    {
        Console.WriteLine("runz");
    }
}
class Cat : Animal, IRun //Trừu tượng (Abstraction)
{
    public int Type { get; set; }

    public override void Bark()
    {
        Console.WriteLine("Meow");
    }

    public void Run()
    {
        Console.Write("run");
    }
}
class Program //Đa hình (Polymorphism)
{
    static Animal GetAnimal(int abc)
    {
        if (abc > 10)
        {
            return new Cat();
        }
        else
        {
            return new Dog();
        }
        QLCB quanLyCanBo = new QLCB();
            CanBo congnhan = new CongNhan("Pham Nhat Hoang", 20, "Nam", "HCM", 5);
            CanBo kysu = new KySu("Le Tan Dat", 21, "Nam", "LongAn","Khoa CNTT" );
            CanBo nhanvien = new NhanVien("Ho Hoang Khang", 22,"Nam", "TraVinh", "Quan Ly Nhan Vien");

            quanLyCanBo.ThemMoiCanBo(congnhan);
            quanLyCanBo.ThemMoiCanBo(kysu);
            quanLyCanBo.ThemMoiCanBo(nhanvien);

            Console.WriteLine("Danh sách cán bộ:");
            quanLyCanBo.HienThiDanhSachCanBo();

            Console.WriteLine("Thoát chương trình.");
            quanLyCanBo.ThoatChươngTrinh();
    }
    static void Main(string[] args)
    {
        int a = 1;
        Animal b = GetAnimal(2);
        b.Bark();


    }
}
