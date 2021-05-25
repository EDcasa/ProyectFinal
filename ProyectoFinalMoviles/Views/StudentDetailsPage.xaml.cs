using ProyectoFinalMoviles.Models;
using ProyectoFinalMoviles.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalMoviles.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentDetailsPage : ContentPage
    {
        DBFirebase services;
        public StudentDetailsPage(Student student)
        {
            InitializeComponent();
            BindingContext = student;
            services = new DBFirebase();
        }

        private async void BtnUpdate_Student(object sender, EventArgs e)
        {
            await services.UpdateStudent(
                FirstName.Text, LastName.Text, int.Parse(Age.Text));
            await Navigation.PushAsync(new AboutPage());
        }
        private async void BtnDelete_Student(object sender, EventArgs e)
        {
            await services.DeleteStudent(FirstName.Text, LastName.Text, int.Parse(Age.Text));
            await Navigation.PushAsync(new AboutPage());
        }
    }
}