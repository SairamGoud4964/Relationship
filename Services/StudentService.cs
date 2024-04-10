using CRUD_using_One_to_One_Relationship.Context;
using CRUD_using_One_to_One_Relationship.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_using_One_to_One_Relationship.Services
{
    public class StudentService :IStudent
    {
        private MyDbContext ctx;

        public StudentService(MyDbContext ctx)
        {
            this.ctx = ctx;
        }

        public string Delete(int id)
        {
            Student deletestudent=GetStudentById(id);
            if(deletestudent!=null)
            {
                ctx.Students.Remove(deletestudent); 
                int rowsimpacted=ctx.SaveChanges();
                if(rowsimpacted>0)
                {
                    return "Data deleted Successfully!!!";
                }
                else
                {
                    return "Data not deleted successfully!!!";
                }
            }
            return "Student Connot be Found!!!";
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = ctx.Students.Include(val=>val.mark).ToList();
            return students;    
        }

        public Student GetStudentById(int id)
        {
            Student student = ctx.Students.Include(val=>val.mark).Where(val => val.Id == id).FirstOrDefault();
            if(student!=null) 
            {
                return student;
            }
            return null;
        }

        public string Save(Student student)
        {
            if(student!=null)
            {
                ctx.Students.Add(student);
                int rowsimpacted=ctx.SaveChanges();
                if(rowsimpacted>0)
                {
                    return "Data Saved Successfully!!!";
                }
                else
                {
                    return "Data not saved successfully!!!";
                }
            }
            return "Student Cannot be Null!!!";
        }

        public string Update(Student student)
        {
            if(student!=null)
            {
                ctx.Students.Update(student);
                int rowsimpacted=ctx.SaveChanges();
                if(rowsimpacted>0)
                {
                    return "Data updated Successfully!!!";
                }
                else
                {
                    return "Data not updated successfully!!!";
                }
            }
            return "Student Connot be null!!!";
        }
    }
}
