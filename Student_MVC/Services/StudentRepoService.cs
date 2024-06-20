using Student_MVC.Models;


namespace Student_MVC.Services
{
    public class StudentRepoService : IStudentRepository
    {
        private readonly StdContext context;
        public StudentRepoService(StdContext context)
        {
            this.context = context;
        }
        
        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student GetStd(int id)
        {
            return context.Students.Find(id);
        }

        public void InsertStd(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void UpdateStd(int id, Student student)
        {
            Student stdUpdate = context.Students.Find(id);
            stdUpdate.Name = student.Name;
            stdUpdate.Email = student.Email;
            stdUpdate.Age = student.Age;
            stdUpdate.Gender = student.Gender;
            stdUpdate.IsActive = student.IsActive;
            stdUpdate.Password = student.Password;
            stdUpdate.DepId = student.DepId;

            context.SaveChanges();
        }
        public void DeleteStd(int id)
        {
            context.Remove(context.Students.Find(id));
            context.SaveChanges();
        }

    }
}
