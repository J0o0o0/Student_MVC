using System.Text.Json.Serialization;

namespace Student_MVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Student> ? Students { get; set; }

    }
}
