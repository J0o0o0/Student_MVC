using Student_MVC.Models;

namespace Student_MVC.Services
{
    public class DepartmentRepoService : IDepartmentRepository
    {
        private readonly StdContext context;
        public DepartmentRepoService(StdContext context)
        {
            this.context = context;
        }
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetDept(int id)
        {
            return context.Departments.Find(id);
        }

        public void InsertDept(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }

        public void UpdateDept(int id, Department department)
        {
            Department deptUpdate = context.Departments.Find(id);
            deptUpdate.Name = department.Name;
            context.SaveChanges();
        }
        public void DeleteDept(int id)
        {
            context.Remove(context.Departments.Find(id));
            context.SaveChanges();
        }
    }
}
