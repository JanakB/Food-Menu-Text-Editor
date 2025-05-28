using System.ComponentModel.DataAnnotations;
using static System.Collections.Specialized.BitVector32;

namespace SchoolManagementSystem.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        [Display(Name = "Room Number")]
        public string RoomNumber { get; set; }
        public ICollection<Section> Sections { get; set; }
    }
}
