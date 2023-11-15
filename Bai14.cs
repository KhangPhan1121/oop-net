using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace netdemo
{
    public abstract class Student
    {
        public string FullName { get; set; }
        public DateTime DoB { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string UniversityName { get; set; }
        public string GradeLevel { get; set; }

        public abstract void ShowMyInfo();
    }

    // Kiểm tra ràng buộc dữ liệu cho chương trình
    public class InvalidFullNameException : Exception
    {
        public InvalidFullNameException(string message) : base(message)
        {
        }
    }

    public class InvalidDoBException : Exception
    {
        public InvalidDoBException(string message) : base(message)
        {
        }
    }

    public class InvalidPhoneNumberException : Exception
    {
        public InvalidPhoneNumberException(string message) : base(message)
        {
        }
    }

    public class GoodStudent : Student
    {
        public double GPA { get; set; }
        public string BestRewardName { get; set; }

        // ShowMyInfo cho sinh viên khá giỏi
        public override void ShowMyInfo()
        {
            //kiểm tra ràng buộc dữ liệu

            if (FullName.Length < 10 || FullName.Length > 50)
            {
                throw new InvalidFullNameException("Ten phai co chieu dai tu 10 => 50 ki tu ");
            }
            if (DoB > DateTime.Now)
            {
                throw new InvalidDoBException("Ngay thang nam sinh khong hop le");
            }
            if (PhoneNumber.Length != 10 || !PhoneNumber.StartsWith("090") &&
                                            !PhoneNumber.StartsWith("098") &&
                                            !PhoneNumber.StartsWith("091") &&
                                            !PhoneNumber.StartsWith("031") &&
                                            !PhoneNumber.StartsWith("035") &&
                                            !PhoneNumber.StartsWith("038"))
            {
                throw new InvalidPhoneNumberException("So dien thoai khong dung dinh dang");
            }
            Console.WriteLine($"Ten: {FullName}");
            Console.WriteLine($"Ngay sinh: {DoB}");
            Console.WriteLine($"Giii tinh: {Sex}");
            Console.WriteLine($"So đien thoai: {PhoneNumber}");
            Console.WriteLine($"Ten truong: {UniversityName}");
            Console.WriteLine($"Khoi: {GradeLevel}");
            Console.WriteLine($"Diem trung binh hoc tap: {GPA}");
            Console.WriteLine($"Ten hoc bong/giai thuong cao nhat: {BestRewardName}");
            Console.WriteLine("------------------------------------");
        }
    }

    public class NormalStudent : Student
    {
        public int EnglishScore { get; set; }
        public int EntryTestScore { get; set; }

        // ShowMyInfo cho sinh viên trung bình
        public override void ShowMyInfo()
        {
            if (FullName.Length < 10 || FullName.Length > 50)
            {
                throw new InvalidFullNameException("Ten phai co chieu dai tu 10 => 50 ki tu ");
            }
            if (DoB > DateTime.Now)
            {
                throw new InvalidDoBException("Ngay thang nam sinh khong hop le");
            }
            if (PhoneNumber.Length != 10 || !PhoneNumber.StartsWith("090") &&
                                            !PhoneNumber.StartsWith("098") &&
                                            !PhoneNumber.StartsWith("091") &&
                                            !PhoneNumber.StartsWith("031") &&
                                            !PhoneNumber.StartsWith("035") &&
                                            !PhoneNumber.StartsWith("038"))
            {
                throw new InvalidPhoneNumberException("So dien thoai khong dung dinh dang");
            }
            Console.WriteLine($"Ten: {FullName}");
            Console.WriteLine($"Ngay sinh: {DoB}");
            Console.WriteLine($"Gioi tinh: {Sex}");
            Console.WriteLine($"So đien thoai: {PhoneNumber}");
            Console.WriteLine($"Ten truong: {UniversityName}");
            Console.WriteLine($"Khoi: {GradeLevel}");
            Console.WriteLine($"Điem TOEIC: {EnglishScore}");
            Console.WriteLine($"Điem thi đau vao chuyen mon: {EntryTestScore}");
            Console.WriteLine("-----------------------------------------");
        }
    }

    public class Class
    {
        private List<Student> students;

        public Class()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        // Phương thức để hiển thị thông tin của tất cả sinh viên trong lớp
        public void ShowClassInfo()
        {
            Console.WriteLine("======== Thong tin lop ========");
            foreach (var student in students)
            {
                try
                {
                    student.ShowMyInfo();
                }
                catch (InvalidFullNameException ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                }
                catch (InvalidDoBException ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                }
                catch (InvalidPhoneNumberException ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Input khong hop le!!!");
                }
            }
            Console.WriteLine("===============================");
        }

        public List<Student> SelectCandidates(int numCandidatesNeeded)
        {
            List<Student> selectedCandidates = new List<Student>();
            var goodStudents = students.OfType<GoodStudent>().OrderByDescending(g => g.GPA).ThenBy(g => g.FullName).ToList();
            // Chọn ứng viên khá giỏi
            int goodStudentsNeeded = Math.Min(numCandidatesNeeded, goodStudents.Count);
            selectedCandidates.AddRange(goodStudents.Take(goodStudentsNeeded));

            // Giảm số lượng ứng viên cần tuyển
            numCandidatesNeeded -= goodStudentsNeeded;

            // Nếu vẫn cần tuyển thêm ứng viên, lấy sinh viên trung bình và sắp xếp theo điểm thi đầu vào, TOEIC và họ tên
            if (numCandidatesNeeded > 0)
            {
                var normalStudents = students.OfType<NormalStudent>().OrderByDescending(n => n.EntryTestScore).ThenByDescending(n => n.EnglishScore).ThenBy(n => n.FullName).ToList();

                // Chọn ứng viên trung bình
                int normalStudentsNeeded = Math.Min(numCandidatesNeeded, normalStudents.Count);
                selectedCandidates.AddRange(normalStudents.Take(normalStudentsNeeded));
            }

            return selectedCandidates;
        }
    }

    static class Bai14
    {
        public static void Main()
        {
            Class myClass = new Class();

            // Tạo và thêm sinh viên khá giỏi
            GoodStudent goodStudent1 = new GoodStudent
            {
                FullName = "Nguyen Van A",
                DoB = new DateTime(1995, 5, 10),
                Sex = "Nam",
                PhoneNumber = "0983456789",
                UniversityName = "Dai hoc ABC",
                GradeLevel = "Kha",
                GPA = 8.5,
                BestRewardName = "Hoc bong xuat sac"
            };
            GoodStudent goodStudent2 = new GoodStudent
            {
                FullName = "Nguyen Van B",
                DoB = new DateTime(1995, 5, 10),
                Sex = "Nam",
                PhoneNumber = "0903456788",
                UniversityName = "Dai hoc ABC",
                GradeLevel = "Kha",
                GPA = 8.6,
                BestRewardName = "Hoc bong xuat sac"
            };
            GoodStudent goodStudent3 = new GoodStudent
            {
                FullName = "Nguyen Van C",
                DoB = new DateTime(1995, 5, 10),
                Sex = "Nam",
                PhoneNumber = "0913456787",
                UniversityName = "Dai hoc ABC",
                GradeLevel = "Kha",
                GPA = 8.7,
                BestRewardName = "Hoc bong xuat sac"
            };
            GoodStudent goodStudent4 = new GoodStudent
            {
                FullName = "Nguyen Van D",
                DoB = new DateTime(1995, 5, 10),
                Sex = "Nam",
                PhoneNumber = "0313456786",
                UniversityName = "Dai hoc ABC",
                GradeLevel = "Kha",
                GPA = 8.8,
                BestRewardName = "Hoc bong xuat sac"
            };
            GoodStudent goodStudent5 = new GoodStudent
            {
                FullName = "Nguyen Van E",
                DoB = new DateTime(1995, 5, 10),
                Sex = "Nam",
                PhoneNumber = "0383456785",
                UniversityName = "Dai hoc ABC",
                GradeLevel = "Kha",
                GPA = 8.9,
                BestRewardName = "Hoc bong xuat sac"
            };
            GoodStudent goodStudent6 = new GoodStudent
            {
                FullName = "Nguyen Van F",
                DoB = new DateTime(1995, 5, 10),
                Sex = "Nam",
                PhoneNumber = "0353456785",
                UniversityName = "Dai hoc ABC",
                GradeLevel = "Kha",
                GPA = 8.6,
                BestRewardName = "Hoc bong xuat sac"
            };

            myClass.AddStudent(goodStudent1);
            myClass.AddStudent(goodStudent2);
            myClass.AddStudent(goodStudent3);
            myClass.AddStudent(goodStudent4);
            myClass.AddStudent(goodStudent5);
            myClass.AddStudent(goodStudent6);
            // Tạo và thêm sinh viên trung bình
            NormalStudent normalStudent1 = new NormalStudent
            {
                FullName = "Nguyen Thi A",
                DoB = new DateTime(1998, 8, 20),
                Sex = "Nu",
                PhoneNumber = "0987654321",
                UniversityName = "Dai hoc XYZ",
                GradeLevel = "Trung binh",
                EnglishScore = 700,
                EntryTestScore = 7
            };
            NormalStudent normalStudent2 = new NormalStudent
            {
                FullName = "Nguyen Thi B",
                DoB = new DateTime(1997, 7, 21),
                Sex = "Nu",
                PhoneNumber = "0987654322",
                UniversityName = "Dai hoc HKJ",
                GradeLevel = "Trung binh",
                EnglishScore = 700,
                EntryTestScore = 7
            };
            NormalStudent normalStudent3 = new NormalStudent
            {
                FullName = "Nguyen Thi C",
                DoB = new DateTime(1996, 6, 22),
                Sex = "Nu",
                PhoneNumber = "0987654323",
                UniversityName = "Dai hoc KUJ",
                GradeLevel = "Trung binh",
                EnglishScore = 700,
                EntryTestScore = 7
            };
            NormalStudent normalStudent4 = new NormalStudent
            {
                FullName = "Nguyen Thi D",
                DoB = new DateTime(1995, 5, 23),
                Sex = "Nu",
                PhoneNumber = "0987654324",
                UniversityName = "Dai hoc LKE",
                GradeLevel = "Trung binh",
                EnglishScore = 700,
                EntryTestScore = 7
            };
            NormalStudent normalStudent5 = new NormalStudent
            {
                FullName = "Nguyen Thi E",
                DoB = new DateTime(1994, 4, 24),
                Sex = "Nu",
                PhoneNumber = "0987654325",
                UniversityName = "Dai hoc PLK",
                GradeLevel = "Trung binh",
                EnglishScore = 700,
                EntryTestScore = 7
            };
            NormalStudent normalStudent6 = new NormalStudent
            {
                FullName = "Nguyen Thi F",
                DoB = new DateTime(1994, 4, 24),
                Sex = "Nu",
                PhoneNumber = "0987654325",
                UniversityName = "Dai hoc PLK",
                GradeLevel = "Trung binh",
                EnglishScore = 700,
                EntryTestScore = 7
            };
            myClass.AddStudent(normalStudent1);
            myClass.AddStudent(normalStudent2);
            myClass.AddStudent(normalStudent3);
            myClass.AddStudent(normalStudent4);
            myClass.AddStudent(normalStudent5);
            myClass.AddStudent(normalStudent6);
            myClass.ShowClassInfo();

            int numCandidatesNeeded = 11;
            List<Student> selectedCandidates = myClass.SelectCandidates(numCandidatesNeeded);
            Console.WriteLine("======== Ds sinh vien duoc chon ========");
            foreach (var student in selectedCandidates)
            {
                try
                {
                    student.ShowMyInfo();
                }
                catch (InvalidFullNameException ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                }
                catch (InvalidDoBException ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                }
                catch (InvalidPhoneNumberException ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Input khong hop le!!!");
                }
            }
        }
    }
}