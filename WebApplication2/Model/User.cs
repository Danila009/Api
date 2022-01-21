using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class User
    {   [Key]
        public Int32 UserID { get; set; }
        [Required, MaxLength(128)]
        public String Name { get; set; }
        [Required]
        public DateTime DateOfBrith { get; set; }
        [Required, MaxLength(64)]
        public String Login { get; set; }
        [Required, MaxLength(64)]
        public String Password { get; set; }

        public List<Test> Test { get;set; }
    }

    public class Test 
    {
        [Key]
        public Int32 TestId { get; set; }

        [Required]
        public String Te4 { get; set; }
    }
}
