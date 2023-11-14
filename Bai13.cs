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
                // Trả về số điện thoại với dấu "+" đằng trước
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

        // Phương thức hiển thị thông tin của nhân viên
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

        public bool IsValidBirthDay(int birthDay)
        {
            int currentYear = DateTime.Now.Year;
            int minBirthYear = 1900;

            if (birthDay < minBirthYear || birthDay > currentYear)
            {
                throw new BirthDayException("Ngay sinh khong hop le.");
            }

            return true;
        }

        // kiểm tra tính hợp lệ của số điện thoại
        public bool IsValidPhone(string phone)
        {
            string phonePattern = @"^[0-9]+$";

            if (!Regex.IsMatch(phone, phonePattern))
            {
                throw new PhoneException("So dien thoai khong hop le.");
            }

            return true;
        }

        // kiểm tra tính hợp lệ của email
        public bool IsValidEmail(string email)
        {
            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                throw new EmailException("Email khong hop le.");
            }

            return true;
        }

        // kiểm tra tính hợp lệ của tên
        public bool IsValidFullName(string fullName)
        {
            string fullNamePattern = @"^[a-zA-Z ]+$";

            if (!Regex.IsMatch(fullName, fullNamePattern))
            {
                throw new FullNameException("Ten khong hop le.");
            }

            return true;
        }
    }

    // Lớp Exception đại diện cho ngoại lệ liên quan đến Ngày sinh
    [Serializable] //Một attribute
    public class BirthDayException : Exception //(Ngoại lệ)
    {
        public BirthDayException() { }
        public BirthDayException(string message) : base(message) { }
        public BirthDayException(string message, Exception inner) : base(message, inner) { }
        protected BirthDayException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    // Lớp Exception đại diện cho ngoại lệ liên quan đến Số điện thoại
    [Serializable]
    public class PhoneException : Exception
    {
        public PhoneException() { }
        public PhoneException(string message) : base(message) { }
        public PhoneException(string message, Exception inner) : base(message, inner) { }
        protected PhoneException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    // Lớp Exception đại diện cho ngoại lệ liên quan đến Email
    [Serializable]
    public class EmailException : Exception
    {
        public EmailException() { }
        public EmailException(string message) : base(message) { }
        public EmailException(string message, Exception inner) : base(message, inner) { }
        protected EmailException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

     // Lớp Exception đại diện cho ngoại lệ liên quan đến Tên
    [Serializable]
    public class FullNameException : Exception
    {
        public FullNameException() { }
        public FullNameException(string message) : base(message) { }
        public FullNameException(string message, Exception inner) : base(message, inner) { }
        protected FullNameException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
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

        // Phương thức hiển thị thông tin của nhân viên có kinh nghiệm
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

        // Phương thức hiển thị thông tin của nhân viên mới ra trường
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

        // Phương thức hiển thị thông tin của nhân viên thực tập
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
        public List<Employee> employees = new List<Employee>();

        // Thêm chứng chỉ mới 
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

                // Xóa chứng chỉ liên quan nếu có
                if (employee is Experience experience)
                {
                    certificates.RemoveAll(c => c.CretificatedID == experience.ID);
                }
                else if (employee is Fresher fresher)
                {
                    certificates.RemoveAll(c => c.CretificatedID == fresher.ID);
                }
                else if (employee is Intern intern)
                {
                    certificates.RemoveAll(c => c.CretificatedID == intern.ID);
                }

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

                Console.WriteLine("Nhap thong tin moi:");

                // Nhập thông tin chung
                Console.Write("Ten moi: ");
                string tenMoi = Console.ReadLine();
                if (employee.IsValidFullName(tenMoi))
                {
                    employee.FullName = tenMoi;
                }
                else
                {
                    Console.WriteLine("Ten khong hop le. Sua thong tin that bai.");
                    return;
                }

                Console.Write("Ngay sinh moi: ");
                int ngaySinhMoi;
                if (int.TryParse(Console.ReadLine(), out ngaySinhMoi) && employee.IsValidBirthDay(ngaySinhMoi))
                {
                    employee.BirthDay = ngaySinhMoi;
                }
                else
                {
                    Console.WriteLine("Ngay sinh khong hop le. Sua thong tin that bai.");
                    return;
                }

                Console.Write("So dien thoai moi: ");
                string sdtMoi = Console.ReadLine();
                if (employee.IsValidPhone(sdtMoi))
                {
                    employee.Phone = sdtMoi;
                }
                else
                {
                    Console.WriteLine("So dien thoai khong hop le. Sua thong tin that bai.");
                    return;
                }

                Console.Write("Email moi: ");
                string emailMoi = Console.ReadLine();
                if (employee.IsValidEmail(emailMoi))
                {
                    employee.Email = emailMoi;
                }
                else
                {
                    Console.WriteLine("Email khong hop le. Sua thong tin that bai.");
                    return;
                }

                // Xử lý thông tin cho từng loại Employee cụ thể
                if (employee is Experience)
                {
                    Experience experience = (Experience)employee;

                    Console.Write("ExpInYear moi: ");
                    string expInYearMoi = Console.ReadLine();
                    experience.ExpInYear = expInYearMoi;

                    Console.Write("ProSkill moi: ");
                    string proSkillMoi = Console.ReadLine();
                    experience.ProSkill = proSkillMoi;
                }
                else if (employee is Fresher)
                {
                    Fresher fresher = (Fresher)employee;

                    Console.Write("GraduationDate moi: ");
                    string graduationDateMoi = Console.ReadLine();
                    if (DateTime.TryParse(graduationDateMoi, out DateTime validGraduationDate))
                    {
                        fresher.GraduationDate = validGraduationDate.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        Console.WriteLine("Ngay thang nam khong hop le. Sua thong tin that bai.");
                        return;
                    }

                    Console.Write("GraduationRank moi: ");
                    string graduationRankMoi = Console.ReadLine();
                    fresher.GraduationRank = graduationRankMoi;

                    Console.Write("Education moi: ");
                    string educationMoi = Console.ReadLine();
                    fresher.Education = educationMoi;
                }
                else if (employee is Intern)
                {
                    Intern intern = (Intern)employee;

                    Console.Write("MaJors moi: ");
                    string maJorsMoi = Console.ReadLine();
                    intern.MaJors = maJorsMoi;

                    Console.Write("SemeSter moi: ");
                    string semeSterMoi = Console.ReadLine();
                    intern.SemeSter = semeSterMoi;

                    Console.Write("UniversityName moi: ");
                    string universityNameMoi = Console.ReadLine();
                    intern.UniversityName = universityNameMoi;
                }

                Console.WriteLine("Thong tin nhan vien sau khi sua:");
                employee.ShowInfo();
            }
            else
            {
                Console.WriteLine($"Khong tim thay nhan vien co ID {iD}");
            }
        }
    }
    static class Bai13
        {
            public static void Main()
            {
                BoPhanTuyenDung boPhanTuyenDung = new BoPhanTuyenDung();

                Experience experience = new Experience(1, "Nguyen Van A", 1999, "0987654321", "test@gmail.com", "FullTime", "1", "1", "HTML, CSS, JS");
                boPhanTuyenDung.employees.Add(experience);

                Fresher fresher = new Fresher(2, "Nguyen Van B", 2000, "0987654321", "test2@gmail.com", "PartTime", "1", "12/12/2022", "Xuat sac", "Hoc sinh");
                boPhanTuyenDung.employees.Add(fresher);

                Intern intern = new Intern(3, "Nguyen Van C", 2001, "0987654321", "test3@gmail.com", "Intern", "1", "IT", "1", "HUST");
                boPhanTuyenDung.employees.Add(intern);

                Certificate certificate = new Certificate(1, "HTML", "Xuat sac", "12/12/2022");
                boPhanTuyenDung.AddCertificate(certificate);

                while (true)
                {
                    Console.WriteLine("========== MENU ==========");
                    Console.WriteLine("1. Them nhan vien moi");
                    Console.WriteLine("2. Xoa nhan vien");
                    Console.WriteLine("3. Sua thong tin nhan vien");
                    Console.WriteLine("4. Hien thi thong tin nhan vien");
                    Console.WriteLine("5. Hien thi thong tin nhan vien intern");
                    Console.WriteLine("6. Hien thi thong tin nhan vien experience");
                    Console.WriteLine("7. Hien thi thong tin nhan vien fresher");
                    Console.WriteLine("8. Hien thi danh sach tat ca nhan vien");
                    Console.WriteLine("0. Thoat");

                    Console.Write("Chon chuc nang (0-9): ");
                    int choice;
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        // Xử lý lựa chọn người dùng
                        switch (choice)
                        {
                            case 1:
                                // Thêm nhân viên mới
                                Console.WriteLine("Chon loai nhan vien moi (1: Experience, 2: Fresher, 3: Intern): ");
                                int typeChoice = int.Parse(Console.ReadLine());
                                switch (typeChoice)
                                {
                                    case 1:
                                        // Nhập thông tin cho nhân viên kinh nghiệm
                                        Console.Write("Nhap ExpInYear: ");
                                        string expInYear = Console.ReadLine();
                                        Console.Write("Nhap ProSkill: ");
                                        string proSkill = Console.ReadLine();
                                        boPhanTuyenDung.employees.Add(new Experience(boPhanTuyenDung.employees.Count + 1, "New Employee", 2000, "123456789", "newemployee@example.com", "FullTime", "1", expInYear, proSkill));
                                        break;

                                    case 2:
                                        // Nhập thông tin cho nhân viên mới tốt nghiệp
                                        Console.Write("Nhap GraduationDate: ");
                                        string graduationDate = Console.ReadLine();
                                        Console.Write("Nhap GraduationRank: ");
                                        string graduationRank = Console.ReadLine();
                                        Console.Write("Nhap Education: ");
                                        string education = Console.ReadLine();
                                        boPhanTuyenDung.employees.Add(new Fresher(boPhanTuyenDung.employees.Count + 1, "New Employee", 2000, "123456789", "newemployee@example.com", "PartTime", "1", graduationDate, graduationRank, education));
                                        break;

                                    case 3:
                                        // Nhập thông tin cho thực tập sinh
                                        Console.Write("Nhap MaJors: ");
                                        string maJors = Console.ReadLine();
                                        Console.Write("Nhap SemeSter: ");
                                        string semeSter = Console.ReadLine();
                                        Console.Write("Nhap UniversityName: ");
                                        string universityName = Console.ReadLine();
                                        boPhanTuyenDung.employees.Add(new Intern(boPhanTuyenDung.employees.Count + 1, "New Employee", 2000, "123456789", "newemployee@example.com", "Intern", "1", maJors, semeSter, universityName));
                                        break;
                                    default:
                                        Console.WriteLine("Lua chon khong hop le");
                                        break;
                                }
                                break;

                            case 2:
                                // Xóa nhân viên
                                Console.Write("Nhap ID nhan vien can xoa: ");
                                int idToDelete;
                                if (int.TryParse(Console.ReadLine(), out idToDelete))
                                {
                                    boPhanTuyenDung.XoaNhanVien(idToDelete);
                                }
                                else
                                {
                                    Console.WriteLine("ID khong hop le.");
                                }
                                break;

                            case 3:
                                // Sửa thông tin nhân viên
                                Console.Write("Nhap ID nhan vien can sua: ");
                                int idToEdit;
                                if (int.TryParse(Console.ReadLine(), out idToEdit))
                                {
                                    boPhanTuyenDung.SuaThongTinNhanVien(idToEdit);
                                }
                                else
                                {
                                    Console.WriteLine("ID khong hop le.");
                                }
                                break;

                            case 4:
                                // Hiển thị thông tin nhân viên
                                Console.Write("Nhap ID nhan vien can hien thi thong tin: ");
                                int idToDisplay;
                                if (int.TryParse(Console.ReadLine(), out idToDisplay))
                                {
                                    Employee employeeToDisplay = boPhanTuyenDung.employees.FirstOrDefault(e => e.ID == idToDisplay);
                                    if (employeeToDisplay != null)
                                    {
                                        Console.WriteLine("========== THONG TIN NHAN VIEN ==========");
                                        employeeToDisplay.ShowInfo();
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Khong tim thay nhan vien co ID {idToDisplay}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ID khong hop le.");
                                }
                                break;
                            case 5:
                                // Tìm và hiển thị tất cả nhân viên intern
                                Console.WriteLine("========== NHAN VIEN INTERN ==========");
                                foreach (var employee in boPhanTuyenDung.employees)
                                {
                                    if (employee is Intern internEmployee)
                                    {
                                        Console.WriteLine($"ID: {internEmployee.ID}, FullName: {internEmployee.FullName}, EmployeeType: {internEmployee.EmployeeType}");
                                        Console.WriteLine();
                                    }
                                }
                                break;
                            case 6:
                                // Tìm và hiển thị tất cả nhân viên experience
                                Console.WriteLine("========== NHAN VIEN EXPERIENCE ==========");
                                foreach (var employee in boPhanTuyenDung.employees)
                                {
                                    if (employee is Experience experienceEmployee)
                                    {
                                        Console.WriteLine($"ID: {experienceEmployee.ID}, FullName: {experienceEmployee.FullName}, EmployeeType: {experienceEmployee.EmployeeType}");
                                        Console.WriteLine();
                                    }
                                }
                                break;
                            case 7:
                                // Tìm và hiển thị tất cả nhân viên fresher
                                Console.WriteLine("========== NHAN VIEN FRESHER ==========");
                                foreach (var employee in boPhanTuyenDung.employees)
                                {
                                    if (employee is Fresher fresherEmployee)
                                    {
                                        Console.WriteLine($"ID: {fresherEmployee.ID}, FullName: {fresherEmployee.FullName}, EmployeeType: {fresherEmployee.EmployeeType}");
                                        Console.WriteLine();
                                    }
                                }
                                break;
                            case 8:
                                // Hiển thị danh sách tất cả nhân viên
                                Console.WriteLine("========== DANH SACH TAT CA NHAN VIEN ==========");
                                foreach (var employee in boPhanTuyenDung.employees)
                                {
                                    Console.WriteLine($"ID: {employee.ID}, FullName: {employee.FullName}, EmployeeType: {employee.EmployeeType}");
                                    Console.WriteLine();
                                }
                                break;

                            case 0:
                                Console.WriteLine("Thoat chuong trinh.");
                                return;

                            default:
                                Console.WriteLine("Lua chon khong hop le");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lua chon khong hop le");
                    }

                    Console.WriteLine();
                }
            }
        }
}