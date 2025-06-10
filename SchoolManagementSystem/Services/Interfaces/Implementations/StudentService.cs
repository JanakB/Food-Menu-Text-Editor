using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repositories;
using SchoolManagementSystem.Services.Interfaces;

namespace SchoolManagementSystem.Services.Interfaces.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _repository.GetAllWithIncludesAsync();
        }


        public async Task<Student> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Student student)
        {
            await _repository.AddAsync(student);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _repository.Update(student);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student != null)
            {
                _repository.Delete(student);
                await _repository.SaveAsync();
            }
        }


    }
}
