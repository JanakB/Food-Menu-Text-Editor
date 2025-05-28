using System.Security.Claims;

namespace SchoolManagementSystem.Models
{
    public class Section
    {
        internal int ClassroomId;

        public int Id { get; set; }
        public string Name { get; set; }

        public int ClassId { get; set; }
        public int Grade { get; set; }
    }
}
