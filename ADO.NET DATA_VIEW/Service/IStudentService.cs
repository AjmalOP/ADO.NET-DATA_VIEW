using ADO.NET_DATA_VIEW.Model;

namespace ADO.NET_DATA_VIEW.Service
{
    public interface IStudentService
    {
        public List<Student> SortStudents();
        public List<Student> FilterStudent();
    }
}
