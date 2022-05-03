using CourseManager.Models;
using CourseManager.Stores;
using CourseManager.ViewModels;
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
        private readonly CourseModel _course;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _course = new CourseModel("IB500g", "Programming Basics", "Nagy József", 4, 60, "Hungarian", "");
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel();

            // CourseModel course = new CourseModel("IB500g", "Programming Basics", "Nagy József", 4, 60, "Hungarian", "");
            // MessageBox.Show(course.Name);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
