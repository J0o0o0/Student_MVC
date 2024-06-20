using Student_MVC.Models;

namespace Student_MVC.Services
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAll();
        public Department GetDept(int id);
        public void InsertDept (Department department);
        public void UpdateDept (int id, Department department);
        public void DeleteDept (int id);

    }
}
