using CRUD_using_One_to_One_Relationship.Models;

namespace CRUD_using_One_to_One_Relationship.Services
{
    public interface IStudent
    {
        public string Save(Student student);
        public Student GetStudentById(int id);
        public string Delete(int id);

        public string Update(Student student);
        public List<Student> GetAllStudents();
    }
}
