using SQLite;
using System;

namespace MobileMAUI_2.Model
{
    [Table("Places")]  // Specifies the table name in the database
    public class Places
    {
        [PrimaryKey, AutoIncrement]  // Marks 'id' as the primary key with auto-increment
        public int Id { get; set; }

        [MaxLength(50)]  // Restricts the 'name' field to 100 characters
        public string Name { get; set; }

        [MaxLength(255)]  // Restricts the 'description' field to 255 characters
        public string Description { get; set; }

        [MaxLength(50)]  // Restricts the 'city' field to 100 characters
        public string City { get; set; }
    }
}
