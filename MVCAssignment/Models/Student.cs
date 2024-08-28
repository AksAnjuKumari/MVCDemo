using System.ComponentModel.DataAnnotations;

namespace MVCAssignment.Models
{
    public class Student
    {
        //    [Required] public int Id { get; set; }
        public int SId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }


        

        public Student()
        {

        }

        public Student(int sId, string name, string gender, int age)
        {
            SId = sId;
            Name = name;
            Gender = gender;
            Age = age;

        }
    }
}
