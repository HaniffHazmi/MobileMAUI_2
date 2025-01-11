using System;
using SQLite;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileMAUI_2.Model
{
    [Table("Friend")]
    public class Friend
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50), Unique]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        public int Age { get; set; }
    }
}
