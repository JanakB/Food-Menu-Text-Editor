using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace SchoolManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Classroom")]
        public int ClassroomId { get; set; }

        [ForeignKey("ClassroomId")]
        public Classroom Classroom { get; set; }

        [Required]
        [Display(Name = "Section")]
        public int SectionId { get; set; }

        [ForeignKey("SectionId")]
        public Section Section { get; set; }
    }
}
