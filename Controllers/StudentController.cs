using CRUD_using_One_to_One_Relationship.Models;
using CRUD_using_One_to_One_Relationship.Services;
using CRUD_using_One_to_One_Relationship.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_using_One_to_One_Relationship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudent studentservice;

        public StudentController(IStudent studentservice)
        {
            this.studentservice = studentservice;
        }

        [HttpPost]
        [Route("Save")]
        public string Save([FromForm]StudentVM studentvm)
        {
            Student newstudent=new Student();
            newstudent.Name = studentvm.Name;
            newstudent.Fee  =  studentvm.Fee;
            newstudent.mark = new Mark();
            newstudent.mark.M1 = studentvm.M1;
            newstudent.mark.M2=studentvm.M2;
            newstudent.mark.M3=studentvm.M3;

            string message = studentservice.Save(newstudent);
            if (message != null)
            {
                return message;
            }
            return null;
        }

        [HttpGet]
        [Route("Get/{id}")]
       
        public Student GetStudent(int id) 
        { 
            Student student=studentservice.GetStudentById(id);  
            return student;
        }

        [HttpGet]
        [Route("GetStudentsList")]
        public List<Student> GetStudentsList()
        {
            List<Student> students=studentservice.GetAllStudents();
            return students;
        }

        [HttpPut]
        [Route("Update")]

        public string Update([FromForm]StudentVM updatestudent,int id)
        {
            Student foundstudent=studentservice.GetStudentById(id);
            foundstudent.Name = updatestudent.Name;
            foundstudent.Fee= updatestudent.Fee;
            foundstudent.mark.M1 = updatestudent.M1;
            foundstudent.mark.M2=updatestudent.M2;
            foundstudent.mark.M3=updatestudent.M3;
            string message=studentservice.Update(foundstudent);
            return message;
        }

        [HttpDelete]
        [Route("Delete{id}")]
        public string Delete(int id) 
        {
            string message = studentservice.Delete(id);
            return message; 
        }

    }
}
