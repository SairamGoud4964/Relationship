namespace CRUD_using_One_to_One_Relationship.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public float Fee { set; get; }

        public Mark mark { set; get; }  
    }
}
