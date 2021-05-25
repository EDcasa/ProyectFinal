using ProyectoFinalMoviles.Models;
using ProyectoFinalMoviles.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProyectoFinalMoviles.Views;

namespace ProyectoFinalMoviles.ViewModels
{
    class StudentsViewModel :BaseViewModel
    {
        public string NumberDocument { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime LastView { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }

        private DBFirebase services;
        public Command AddStudentCommand { get; }
        public Command SearchStudentCommand { get; }
        private ObservableCollection<Student> _students = new ObservableCollection<Student>();
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();

            }
        }

        public StudentsViewModel()
        {
            services = new DBFirebase();
            Students = services.getStudent();
            AddStudentCommand = new Command(async () => await addStudentAsync(NumberDocument, FirstName, LastName, Age, LastView, Description,Observation));
            SearchStudentCommand = new Command(async () => await SearchStudentAsync(NumberDocument));

        }
        public async Task addStudentAsync (string NumberDocument, string FirstName, string LastName, int Age, DateTime LastView, string description, string observations)
        {
            await services.AddStudent(NumberDocument, FirstName, LastName,Age, LastView, description, observations);
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
        public async Task SearchStudentAsync (string NumberDocument)
        {
            
            await services.FindStudent(NumberDocument);
            //  await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
