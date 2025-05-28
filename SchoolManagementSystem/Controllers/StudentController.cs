using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repositories;
using SchoolManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace SchoolManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
         // All actions here are restricted to Admins
        
        private readonly IStudentRepository _studentRepository;
        private readonly ApplicationDbContext _context;

        public StudentController(IStudentRepository studentRepository, ApplicationDbContext context)
        {
            _studentRepository = studentRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetAllAsync();
            return View(students);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Classrooms = new SelectList(await _context.Classrooms.ToListAsync(), "Id", "Name");
            ViewBag.Sections = new SelectList(Enumerable.Empty<Section>(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.AddAsync(student);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Classrooms = new SelectList(await _context.Classrooms.ToListAsync(), "Id", "Name", student.ClassroomId);
            ViewBag.Sections = new SelectList(await _context.Sections
                .Where(s => s.ClassroomId == student.ClassroomId).ToListAsync(), "Id", "Name", student.SectionId);

            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return NotFound();

            ViewBag.Classrooms = new SelectList(await _context.Classrooms.ToListAsync(), "Id", "Name", student.ClassroomId);
            ViewBag.Sections = new SelectList(await _context.Sections
                .Where(s => s.ClassroomId == student.ClassroomId).ToListAsync(), "Id", "Name", student.SectionId);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.UpdateAsync(student);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Classrooms = new SelectList(await _context.Classrooms.ToListAsync(), "Id", "Name", student.ClassroomId);
            ViewBag.Sections = new SelectList(await _context.Sections
                .Where(s => s.ClassroomId == student.ClassroomId).ToListAsync(), "Id", "Name", student.SectionId);

            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // AJAX: Get Sections for a Classroom
        public async Task<IActionResult> GetSectionsByClassroom(int classroomId)
        {
            var sections = await _context.Sections
                .Where(s => s.ClassroomId == classroomId)
                .Select(s => new { s.Id, s.Name })
                .ToListAsync();

            return Json(sections);
        }
    }
}
