using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Models
{
    public sealed record class CourseModel(string code, string name, string lecturer, int credit, int limit, string language, string description);
}
