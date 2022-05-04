using CourseManager.DbContexts;
using CourseManager.Models;
using CourseManager.Services;
using CourseManager.Stores;
using CourseManager.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        private const string CONNECTION_STRING = "Data Source=coursemanager.db";
        private readonly CourseModel _course;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _course = new CourseModel("IB500g", "Programming Basics", "Nagy József", 4, 60, "Hungarian", "");
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            using (CourseDbContext dbContext = new CourseDbContext(options)) 
            {
                dbContext.Database.Migrate();

            }

            // starting view
            _navigationStore.CurrentViewModel = CreateCourseListingViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private CreateCourseViewModel CreateCreateCourseViewModel()
        {
            return new CreateCourseViewModel(_course, new NavigationService(_navigationStore, CreateCourseListingViewModel));
        }

        private CourseListingViewModel CreateCourseListingViewModel()
        {
            return new CourseListingViewModel(_course, new NavigationService(_navigationStore, CreateCreateCourseViewModel));
        }

        //private HomeViewModel CreateHomeViewModel()
        //{
        //    return new HomeViewModel(_navigationStore, HomeViewModel);
        //}
    }
}
