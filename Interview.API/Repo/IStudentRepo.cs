using Interview.API.Models;

namespace Interview.API.Repo
{
    public interface IStudentRepo
    {
        Task<Student> GetStudent(int id);

        Task<Student> AddStudent(Student student);
    }
}
