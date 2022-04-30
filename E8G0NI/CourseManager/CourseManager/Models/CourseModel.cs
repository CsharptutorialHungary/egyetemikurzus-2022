using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Models
{
    public sealed record class CourseModel(string Code, string Name, string Lecturer, int Credit, int Limit, string Language, string Description);
}
