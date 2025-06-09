using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student student);
        void Update(Student student);
        void Delete(Student student);
        Task UpdateAsync(Student student);  // ✅ Add this
        Task DeleteAsync(int id);
        Task SaveAsync();
        Task<List<Student>> GetAllWithIncludesAsync();


    }


}
