namespace CRUD_using_One_to_One_Relationship.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public int M1 { set; get; }
        public int M2 { set; get; }
        public int M3 { set; get; }

        public int StudentId { set; get; } // Foreign key
        public Student Student { get; set; }

    }
}
