using ADO.NET_DATA_VIEW.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ADO.NET_DATA_VIEW.Service
{
    public class StudentService : IStudentService
    {
        private readonly IConfiguration _Configuration;
        public string CString;
        public StudentService(IConfiguration configuration)
        {
            _Configuration = configuration;
            CString = _Configuration["ConnectionString:DefualtConnection"];
        }
        public List<Student> SortStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(CString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from students", connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet,"Students");
                DataView dataView = new DataView(dataSet.Tables["Students"]);
                dataView.Sort = "LastName DESC";
                foreach(DataRowView row in  dataView)
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(row["StudentID"]);
                    student.FirstName = row["FirstName"].ToString();
                    student.LastName = row["LastName"].ToString();
                    student.Age = Convert.ToInt32(row["Age"]);
                    students.Add(student);
                }
            }
            return students;
        }
        public List<Student> FilterStudent()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(CString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from students", connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Students");
                DataView dataView = new DataView(dataSet.Tables["Students"]);
                dataView.RowFilter = "Age > 21";
                foreach (DataRowView row in dataView)
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(row["StudentID"]);
                    student.FirstName = row["FirstName"].ToString();
                    student.LastName = row["LastName"].ToString();
                    student.Age = Convert.ToInt32(row["Age"]);
                    students.Add(student);
                }
            }
            return students;
        }
    }
}
