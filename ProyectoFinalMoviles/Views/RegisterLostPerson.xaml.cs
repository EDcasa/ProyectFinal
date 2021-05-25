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
    public partial class RegisterLostPerson : ContentPage
    {
        public RegisterLostPerson()
        {
            InitializeComponent();
            BindingContext = new StudentsViewModel();
        }
    }
}