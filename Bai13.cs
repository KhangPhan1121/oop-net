using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace netdemo
{
    class Employee
    {
        public int ID;
        public string FullName;
        public int BirthDay;
        private string _Phone;
        public string Phone
        {
            get
            {

                return "+" + _Phone;
            }
            set
            {
                _Phone = value;
            }
        }
        public string Email { get; set; }
        public string EmployeeType;
        public string EmployeeCount;

        public Employee(int iD, string fullName, int birthDay, string phone, string email, string employeeType, string employeeCount)
        {
            ID = iD;
            FullName = fullName;
            BirthDay = birthDay;
            Phone = phone;
            Email = email;
            EmployeeType = employeeType;
            EmployeeCount = employeeCount;
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"ID {ID}");
            Console.WriteLine($"FullName {FullName}");
            Console.WriteLine($"BirthDay {BirthDay}");
            Console.WriteLine($"Phone {Phone}");
            Console.WriteLine($"Email {Email}");
            Console.WriteLine($"EmployeeType {EmployeeType}");
            Console.WriteLine($"EmployeeCount {EmployeeCount}");
        }
        //kiểm tra tính hợp lệ của ngày sinh, email, tên và số điện thoại của nhân viên.
        public bool IsValidBirthDay(int birthDay)
        {
            int currentYear = DateTime.Now.Year;
            return birthDay >= 1900 && birthDay <= currentYear;
        }
        public bool IsValidEmail(string email)
        {
            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(email, emailPattern);
        }
        public bool IsValidFullName(string fullName)
        {
            string fullNamePattern = @"^[a-zA-Z ]+$";
            return Regex.IsMatch(fullName, fullNamePattern);
        }
        public bool IsValidPhone(string phone)
        {
            string phonePattern = @"^[0-9]+$";
            return Regex.IsMatch(phone, phonePattern);
        }
    }
    class Experience : Employee
    {
        public string ExpInYear;
        public string ProSkill;

        public Experience(int iD, string fullName, int birthDay, string phone, string email, string employeeType, string employeeCount, string expInYear, string proSkill) : base(iD, fullName, birthDay, phone, email, employeeType, employeeCount)
        {
            ExpInYear = expInYear;
            ProSkill = proSkill;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"ExpInYear {ExpInYear}");
            Console.WriteLine($"ProSkill {ProSkill}");
        }
    }
    class Fresher : Employee
    {
        public string GraduationDate;
        public string GraduationRank;
        public string Education;

        public Fresher(int iD, string fullName, int birthDay, string phone, string email, string employeeType, string employeeCount, string graduationDate, string graduationRank, string education) : base(iD, fullName, birthDay, phone, email, employeeType, employeeCount)
        {
            GraduationDate = graduationDate;
            GraduationRank = graduationRank;
            Education = education;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"GraduationDate {GraduationDate}");
            Console.WriteLine($"GraduationRank {GraduationRank}");
            Console.WriteLine($"Education {Education}");
        }
    }
    class Intern : Employee
    {
        public string MaJors;
        public string SemeSter;
        public string UniversityName;

        public Intern(int iD, string fullName, int birthDay, string phone, string email, string employeeType, string employeeCount, string maJors, string semeSter, string universityName) : base(iD, fullName, birthDay, phone, email, employeeType, employeeCount)
        {
            MaJors = maJors;
            SemeSter = semeSter;
            UniversityName = universityName;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"MaJors {MaJors}");
            Console.WriteLine($"SemeSter {SemeSter}");
            Console.WriteLine($"UniversityName {UniversityName}");
        }
    }
    class Certificate
    {
        public int CretificatedID;
        public string CretificateName;
        public string CretificateRank;
        public string CretificateDate;

        public Certificate(int cretificatedID, string cretificateName, string cretificateRank, string cretificateDate)
        {
            CretificatedID = cretificatedID;
            CretificateName = cretificateName;
            CretificateRank = cretificateRank;
            CretificateDate = cretificateDate;
        }
    }
    class BoPhanTuyenDung
    {
        public List<Certificate> certificates = new List<Certificate>();
        public static List<Employee> employees = new List<Employee>();
        public void AddCertificate(Certificate certificate)
        {
            certificates.Add(certificate);
        }
        public void XoaNhanVien(int iD)
        {
            Employee employee = employees.Find(e => e.ID == iD);
            if (employee != null)
            {
                Console.WriteLine("Thong tin nhan vien truoc khi xoa:");
                employee.ShowInfo();

                employees.Remove(employee);
                Console.WriteLine("Xoa thanh cong.");
            }
            else
            {
                Console.WriteLine($"Khong tim thay nhan vien co  ID {iD}");
            }
        }
        public void SuaThongTinNhanVien(int iD)
        {
            Employee employee = employees.Find(e => e.ID == iD);
            if (employee != null)
            {
                Console.WriteLine("Thong tin nhan vien truoc khi sua:");
                employee.ShowInfo();

                Console.WriteLine("Nhạp thong tin moi:");

                Console.Write("Ten moi: ");
                string tenMoi = Console.ReadLine();
                employee.FullName = tenMoi;

                Console.Write("Ngay sinh moi: ");
                int ngaySinhMoi = int.Parse(Console.ReadLine());
                employee.BirthDay = ngaySinhMoi;

                Console.Write("So dien thoai moi: ");
                string sdtMoi = Console.ReadLine();
                employee.Phone = sdtMoi;

                Console.Write("Email moi: ");
                string emailMoi = Console.ReadLine();
                employee.Email = emailMoi;

                Console.WriteLine("Thong tin nhan vien sau khi sua:");
                employee.ShowInfo();
            }
            else
            {
                Console.WriteLine($"Khong tim thay nhan vien co ID {iD}");
            }
        }

        // public void SuaNhanVien(int iD)
        // {
        //     Certificate certificate = certificates.Find(c => c.CretificatedID == iD);
        //     if (certificate != null)
        //     {
        //         Console.WriteLine("Nhap ten moi");
        //         string tenMoi = Console.ReadLine();
        //         certificate.CretificateName = tenMoi;
        //         certificate.CretificateRank = "Xuat sac";
        //         certificate.CretificateDate = "12/12/2022";
        //         Console.WriteLine("Sua thanh cong");
        //         if (certificate.CretificateName == tenMoi)
        //         {
        //             Console.WriteLine("Sua thanh cong");
        //         }
        //         else
        //         {
        //             Console.WriteLine("Sua that bai");
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("Khong tim thay Certificate co ID " + iD);
        //     }
        // }
    }
    static class Bai13
    {
        public static void Main()
        {
            Experience experience = new Experience(1, "Nguyen Van A", 1999, "0987654321", "XXXXXXXXXXXXXXXXXXXX", "FullTime", "1", "1", "HTML, CSS, JS");
            experience.ShowInfo();

            Fresher fresher = new Fresher(2, "Nguyen Van B", 2000, "0987654321", "XXXXXXXXXXXXXXXXXXXX", "PartTime", "1", "12/12/2022", "Xuat sac", "Hoc sinh");
            fresher.ShowInfo();

            Intern intern = new Intern(3, "Nguyen Van C", 2001, "0987654321", "XXXXXXXXXXXXXXXXXXXX", "Intern", "1", "IT", "1", "HUST");
            intern.ShowInfo();

            BoPhanTuyenDung boPhanTuyenDung = new BoPhanTuyenDung();
            Certificate certificate = new Certificate(1, "HTML", "Xuat sac", "12/12/2022");
            boPhanTuyenDung.AddCertificate(certificate);
            boPhanTuyenDung.XoaNhanVien(1);
            boPhanTuyenDung.SuaThongTinNhanVien(2);
        }
    }
}