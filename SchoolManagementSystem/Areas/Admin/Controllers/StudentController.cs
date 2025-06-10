using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repositories;
using SchoolManagementSystem.Services.Interfaces;


namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;
        private readonly IClassroomRepository _classroomRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly ApplicationDbContext _context;

        public StudentController(
            IStudentService studentService,
            IStudentRepository studentRepository,
            IClassroomRepository classroomRepository,
            ISectionRepository sectionRepository,
            ApplicationDbContext context)
        {
            _studentService = studentService;
            _studentRepository = studentRepository;
            _classroomRepository = classroomRepository;
            _sectionRepository = sectionRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllAsync();
            return View(students);
        }
        public IActionResult Test()
        {
            return Content("Routing to StudentController in Admin area works!");
        }

        [HttpGet]
        public JsonResult GetSectionsByClassroom(int id)
        {
            var sections = _context.Sections
                .Where(s => s.ClassroomId == id)
                .Select(s => new { id = s.Id, name = s.Name })
                .ToList();

            return Json(sections);
        }

        public IActionResult Create()
        {
            ViewBag.Classrooms = new SelectList(_context.Classrooms, "Id", "Name");
            ViewBag.Sections = new SelectList(_context.Sections, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.CreateAsync(student);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Classrooms = new SelectList(_context.Classrooms, "Id", "Name");
            ViewBag.Sections = new SelectList(_context.Sections, "Id", "Name");
            return View(student);
        }

        // ----------- ✅ EDIT ACTIONS BELOW -----------

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return NotFound();

            ViewBag.Classrooms = await _classroomRepository.GetAllAsync();
            ViewBag.Sections = await _sectionRepository.GetAllByClassroomIdAsync(student.ClassroomId);

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _studentRepository.UpdateAsync(student);
                await _studentRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Classrooms = await _classroomRepository.GetAllAsync();
            ViewBag.Sections = await _sectionRepository.GetAllByClassroomIdAsync(student.ClassroomId);
            return View(student);
        }

        // TODO: Add Delete action later
        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        
           



    }
}
