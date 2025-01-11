using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileMAUI_2.Model
{
    [Table("Food")]
    public class Food
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50), Unique]  // MaxLength and Unique constraint for Name field
        public string Name { get; set; }

        [MaxLength(200)]  // MaxLength for Description field
        public string Description { get; set; }

        public int Rating { get; set; }
    }
}
