using SQLite; 

namespace Employee_CRUD_APP
{
    [Table("employee")]
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique,MaxLength(100)]    
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
