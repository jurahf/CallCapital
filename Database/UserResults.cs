using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database
{
    public class UserResults
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int BestResult { get; set; }
    }
}
