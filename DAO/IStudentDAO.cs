using StudentsWebApplication.Model;

namespace StudentsWebApplication.DAO
{
    public interface IStudentDAO
    {
        void Insert(Student? student);
        void Update(Student? student);

        void Delete(int id);
        Student? GetById(int id);
        List<Student> GetAll();
    }
}
