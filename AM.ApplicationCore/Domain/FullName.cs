using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain

{

    public class FullName
    {

        [MinLength(3, ErrorMessage = "First Name must be at least 3 characters long")]
        [MaxLength(25, ErrorMessage = "First Name cannot exceed 25 characters")]
        public string  FirstName { get; set; }
        public string LastName { get; set; }
    }
}
