using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace SchoolManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
       

        [Required]
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }

        [Required]
        public int SectionId { get; set; }
        public Section Section { get; set; }

    }

}
