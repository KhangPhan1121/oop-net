using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using netdemo;

namespace netdemo
{
    public class Person
    {
        public string StudentID { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public int AdmissionYear { get; set; }
        public float EntranceScore { get; set; }

        public Person()
        {
        }

        public Person(string studentID, string fullName, DateTime dob, int admissionYear, float entranceScore)
        {
            StudentID = studentID;
            FullName = fullName;
            Dob = dob;
            AdmissionYear = admissionYear;
            EntranceScore = entranceScore;
        }

        public Person(Person other)
        {
            StudentID = other.StudentID;
            FullName = other.FullName;
            Dob = other.Dob;
            AdmissionYear = other.AdmissionYear;
            EntranceScore = other.EntranceScore;
        }
    }

    public class RegularStudent : Person
    {
        public List<Result> AcademicResults { get; set; }

        public RegularStudent()
        {
            AcademicResults = new List<Result>();
        }

        public RegularStudent(string studentID, string fullName, DateTime dob, int admissionYear, float entranceScore, List<Result> academicResults)
            : base(studentID, fullName, dob, admissionYear, entranceScore)
        {
            AcademicResults = academicResults;
        }

        public RegularStudent(RegularStudent other) : base(other)
        {
            AcademicResults = new List<Result>(other.AcademicResults);
        }
    }

    public class PartTimeStudent : Person
    {
        public string TrainingLocation { get; set; }

        public PartTimeStudent()
        {
        }

        public PartTimeStudent(string studentID, string fullName, DateTime dob, int admissionYear, float entranceScore, string trainingLocation)
            : base(studentID, fullName, dob, admissionYear, entranceScore)
        {
            TrainingLocation = trainingLocation;
        }

        public PartTimeStudent(PartTimeStudent other) : base(other)
        {
            TrainingLocation = other.TrainingLocation;
        }
    }

    public class Result
    {
        public string Semester { get; set; }
        public float AvgScore { get; set; }

        public Result()
        {
        }

        public Result(string semester, float avgScore)
        {
            Semester = semester;
            AvgScore = avgScore;
        }

        public Result(Result other)
        {
            Semester = other.Semester;
            AvgScore = other.AvgScore;
        }
    }

    public static class Bai15
    {
        //xác định tổng số sinh viên chính quy của khoa
        public static int TongSoSinhVienChinhQuy(List<RegularStudent> regularStudents)
        {
            return regularStudents.Count;
        }

        //Tìm ra sinh viên có điểm đầu vào cao nhất ở mỗi khoa
        public static Dictionary<string, RegularStudent> SinhVienDiemCaoNhatTheoKhoa(List<RegularStudent> regularStudents)
        {
            Dictionary<string, RegularStudent> sinhVienDiemCaoNhat = new Dictionary<string, RegularStudent>();

            foreach (var regularStudent in regularStudents)
            {
                string key = regularStudent.AdmissionYear.ToString(); // Sử dụng AdmissionYear làm khóa
                if (!sinhVienDiemCaoNhat.ContainsKey(key))
                {
                    sinhVienDiemCaoNhat[key] = regularStudent;
                }
                else
                {
                    if (regularStudent.EntranceScore > sinhVienDiemCaoNhat[key].EntranceScore)
                    {
                        sinhVienDiemCaoNhat[key] = regularStudent;
                    }
                }
            }

            return sinhVienDiemCaoNhat;
        }

        public static Dictionary<string, List<PartTimeStudent>> SinhVienTaiChucTheoNoiDaoTao(List<PartTimeStudent> partTimeStudents)
        {
            Dictionary<string, List<PartTimeStudent>> sinhVienTaiChucTheoNoiDaoTao = new Dictionary<string, List<PartTimeStudent>>();

            foreach (var partTimeStudent in partTimeStudents)
            {
                if (partTimeStudent.TrainingLocation != null) // Kiểm tra null
                {
                    if (!sinhVienTaiChucTheoNoiDaoTao.ContainsKey(partTimeStudent.TrainingLocation))
                    {
                        sinhVienTaiChucTheoNoiDaoTao[partTimeStudent.TrainingLocation] = new List<PartTimeStudent>();
                    }

                    sinhVienTaiChucTheoNoiDaoTao[partTimeStudent.TrainingLocation].Add(partTimeStudent);
                }
            }

            return sinhVienTaiChucTheoNoiDaoTao;
        }

        //danh sách sinh viên có điểm trung bình ở học kỳ gần nhất từ 8.0 trở lên
        public static Dictionary<string, List<RegularStudent>> SinhVienDiemCaoNhatTheoKhoa(List<RegularStudent> regularStudents, List<PartTimeStudent> partTimeStudents)
        {
            Dictionary<string, List<RegularStudent>> sinhVienDiemCaoNhatTheoKhoa = new Dictionary<string, List<RegularStudent>>();

            foreach (var regularStudent in regularStudents)
            {
                string key = regularStudent.AdmissionYear.ToString(); // Sử dụng AdmissionYear làm khóa

                // Kiểm tra xem có danh sách kết quả học tập không
                if (regularStudent.AcademicResults.Any())
                {
                    // Lấy học kỳ cuối cùng
                    Result latestResult = regularStudent.AcademicResults.Last();

                    // Kiểm tra điều kiện điểm trung bình từ 8.0 trở lên
                    if (latestResult.AvgScore >= 8.0f && latestResult.AvgScore <=10.0f)
                    {
                        if (!sinhVienDiemCaoNhatTheoKhoa.ContainsKey(key))
                        {
                            sinhVienDiemCaoNhatTheoKhoa[key] = new List<RegularStudent>();
                        }
                            RegularStudent cloneStudent = new RegularStudent(regularStudent);
                            cloneStudent.AcademicResults.Clear();
                            cloneStudent.AcademicResults.Add(latestResult);

                        sinhVienDiemCaoNhatTheoKhoa[key].Add(cloneStudent);
                    }
                }
            }
            return sinhVienDiemCaoNhatTheoKhoa;
        }

        //sinh viên có điểm trung bình học kỳ cao nhất (ở bất kỳ học kỳ nào)
        public static Dictionary<string, RegularStudent> SinhVienDiemCaoNhats(List<RegularStudent> regularStudents)
        {
            Dictionary<string, RegularStudent> sinhVienDiemCaoNhat = new Dictionary<string, RegularStudent>();
            foreach (var regularStudent in regularStudents)
            {
                string key = regularStudent.AdmissionYear.ToString(); // Sử dụng AdmissionYear làm khóa

                //Kiểm tra xem có trong danh sách kêt quả học tập không
                if (regularStudent.AcademicResults.Any())
                {
                    //Tìm học kì có điểm trung bình cao nhất
                    Result hightestAvgScoreResult = regularStudent.AcademicResults.OrderByDescending(r => r.AvgScore).First();
                    //Kiểm tra sinh viên này có điểm cao nhất hay chưa
                    if (!sinhVienDiemCaoNhat.ContainsKey(key) || hightestAvgScoreResult.AvgScore > sinhVienDiemCaoNhat[key].AcademicResults.Max(r => r.AvgScore))
                    {
                        //Sao chép sinh viên để tránh thay đổi thông tin gốc
                        RegularStudent cloneStudent = new RegularStudent(regularStudent);
                        cloneStudent.AcademicResults.Clear();
                        cloneStudent.AcademicResults.Add(hightestAvgScoreResult);

                        sinhVienDiemCaoNhat[key] = cloneStudent;
                    }
                }
            }
            return sinhVienDiemCaoNhat;
        }

        public static void Main()
        {
            List<RegularStudent> regularStudents = new List<RegularStudent>
            {
                new RegularStudent("SV001", "Nguyen Van A", new DateTime(2000, 1, 1), 2021, 8.5f, new List<Result>
                {
                    new Result("HKI", 8.5f),
                    new Result("HKII", 9.0f)
                }),
                new RegularStudent("SV002", "Nguyen Van B", new DateTime(2000, 1, 1), 2021, 7.5f, new List<Result>
                {
                    new Result("HKI", 7.5f),
                    new Result("HKII", 8.0f)
                }),
                new RegularStudent("SV003", "Nguyen Van C", new DateTime(2000, 1, 1), 2021, 9.0f, new List<Result>
                {
                    new Result("HKI", 9.0f),
                    new Result("HKII", 9.5f)
                }),
                new RegularStudent("SV004", "Nguyen Van D", new DateTime(2000, 1, 1), 2021, 8.0f, new List<Result>
                {
                    new Result("HKI", 8.0f),
                    new Result("HKII", 8.5f)
                })
            };
            List<PartTimeStudent> partTimeStudents = new List<PartTimeStudent>
            {
                new PartTimeStudent("SV005", "Nguyen Van E", new DateTime(2000, 1, 1), 2021, 8.5f, "HN"),
                new PartTimeStudent("SV006", "Nguyen Van F", new DateTime(2000, 1, 1), 2021, 7.5f, "HN"),
                new PartTimeStudent("SV007", "Nguyen Van G", new DateTime(2000, 1, 1), 2021, 9.0f, "HN"),
                new PartTimeStudent("SV008", "Nguyen Van H", new DateTime(2000, 1, 1), 2021, 8.0f, "HN")
            };

            //Phương thức xác định tổng số sinh viên chính quy của khoa
            Console.WriteLine($"Tong so sinh vien chinh quy cua khoa: {TongSoSinhVienChinhQuy(regularStudents)}");

            //Tìm ra sinh viên có điểm đầu vào cao nhất ở mỗi khoa
            var sinhVienDiemCaoNhat = SinhVienDiemCaoNhatTheoKhoa(regularStudents);
            Console.WriteLine("Sinh vien co diem cao nhat theo khoa:");
            foreach (var kvp in sinhVienDiemCaoNhat)
            {
                Console.WriteLine($"Khoa {kvp.Key}: {kvp.Value.FullName} - Diem: {kvp.Value.EntranceScore}");
            }

            //danh sách các sinh viên tại chức tại nơi liên kết đào tạo cho trước
            var sinhVienTaiChucTheoNoiDaoTao = SinhVienTaiChucTheoNoiDaoTao(partTimeStudents);
            Console.WriteLine("Danh sach sinh vien tai chuc theo noi dao tao:");
            foreach (var kvp in sinhVienTaiChucTheoNoiDaoTao)
            {
                Console.WriteLine($"Noi dao tao: {kvp.Key}");
                foreach (var partTimeStudent in kvp.Value)
                {
                    Console.WriteLine($"  - {partTimeStudent.FullName}");
                }
            }

            //danh sách sinh viên có điểm trung bình ở học kỳ gần nhất từ 8.0 trở lên
            var sinhVienDiemCaoNhatTheoKhoa = SinhVienDiemCaoNhatTheoKhoa(regularStudents, partTimeStudents);
            Console.WriteLine("Danh sach sinh vien co diem cao nhat theo khoa >=8.0:");
            foreach (var kvp in sinhVienDiemCaoNhatTheoKhoa)
            {
                Console.WriteLine($"Khoa {kvp.Key}:");
                foreach (var regularStudent in kvp.Value)
                {
                    Console.WriteLine($"  - {regularStudent.FullName} - Diem: {regularStudent.EntranceScore}");
                }
            }
            //sinh viên có điểm trung bình học kỳ cao nhất (ở bất kỳ học kỳ nào)
            var sinhVienDiemCaoNhats = SinhVienDiemCaoNhats(regularStudents);
            Console.WriteLine("Sinh vien co diem cao nhat:");
            foreach (var kvp in sinhVienDiemCaoNhats)
            {
                Console.WriteLine($"Khoa {kvp.Key}: {kvp.Value.FullName} - Diem: {kvp.Value.EntranceScore}");
            }
        }
    }
}
