using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Student_MVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Range(18,60)]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]+" , ErrorMessage = "Name must be only characters")]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("Department")]
        public int DepId { get; set; }

        [JsonIgnore]
        public virtual Department ? Department { get; set; }


    }

    public enum Gender
    {
        Male = 0, Female = 1
    }
}
