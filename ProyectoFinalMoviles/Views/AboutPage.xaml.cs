using ProyectoFinalMoviles.Models;
using ProyectoFinalMoviles.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalMoviles.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = new StudentsViewModel();
        }
        public async void OnItemSelected(Object sender, ItemTappedEventArgs args)
        {
            var student = args.Item as Student;
            if (student == null) return;
            await Navigation.PushAsync(new StudentDetailsPage(student));
            lstStudents.SelectedItem = null;
        }
    }
}