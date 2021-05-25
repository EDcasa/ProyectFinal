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
    public partial class LoginPage : ContentPage
    {
        IAuth auth;
        public LoginPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
            this.BindingContext = new LoginViewModel();
        }
        

        private async void LoginClicked(object sender, EventArgs e)
        {
            if (EmailInput.Text != null && PasswordInput.Text != null)
            {
                string token = await auth.LoginWithEmailAndPassword(EmailInput.Text, PasswordInput.Text);
                if (token != string.Empty)
                {
                    //Application.Current.MainPage = new LoggedPage();
                    //Application.Current.MainPage = new AboutPage();
                    await Shell.Current.GoToAsync("//AboutPage");

                }
                else
                {
                    await DisplayAlert("Falló la autenticación", "La clave o correo electrónico son incorrectos", "Aceptar");
                }
            }
            else
            {
                await DisplayAlert("Campos vacíos", "Ingrese los datos solicitados", "Aceptar");
            }

        }

        private async void SignUpClicked(object sender, EventArgs e)
        {
            var singOut = auth.Signout();
            if (singOut)
            {
                //Application.Current.MainPage = new SignUpPage();
                //await Shell.Current.GoToAsync("//SignUpPage");
                await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
            }
        }
    }
}