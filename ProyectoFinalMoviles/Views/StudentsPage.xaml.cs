using ProyectoFinalMoviles.Models;
using ProyectoFinalMoviles.ViewModels;
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
    public partial class StudentsPage : ContentPage
    {
        public StudentsPage()
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