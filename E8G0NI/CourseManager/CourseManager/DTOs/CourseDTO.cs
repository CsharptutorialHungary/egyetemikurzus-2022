using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.DTOs
{
    public class CourseDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Lecturer { get; set; }
        public int Credit { get; set; }
        public int Limit { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
    }
}
