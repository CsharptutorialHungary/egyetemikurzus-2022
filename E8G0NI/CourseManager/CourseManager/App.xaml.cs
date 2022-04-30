using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CourseManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            CourseModel course = new CourseModel("IB500g", "Programming Basics", "Nagy József", 4, 60, "Hungarian", "");
            MessageBox.Show(course.Name);

            base.OnStartup(e);
        }
    }
}
