using Student_MVC.Models;

namespace Student_MVC.Services
{
    public interface IStudentRepository
    {
        public List<Student> GetAll();
        public Student GetStd(int id);
        public void InsertStd (Student student);
        public void UpdateStd (int id, Student student);
        public void DeleteStd (int id);

        
    }
}
