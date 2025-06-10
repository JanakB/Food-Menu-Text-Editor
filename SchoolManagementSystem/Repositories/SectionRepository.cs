using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ApplicationDbContext _context;

        public SectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Section>> GetAllAsync()
        {
            return await _context.Sections.ToListAsync();
        }

        public async Task<IEnumerable<Section>> GetAllByClassroomIdAsync(int classroomId)
        {
            return await _context.Sections
                .Where(s => s.ClassroomId == classroomId)
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id); // Assumes you're using EF Core
        }

    }
}
