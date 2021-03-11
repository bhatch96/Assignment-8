using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        [RegularExpression(@"^\d{2,3}[-]{0,1}\d{11}|\d{9,11}$")]
        public string ISBN { get; set; }
        public string ClassificationCategory { get; set; }
        public double Price { get; set; }
        public int PageLength { get; set; }

}
}
