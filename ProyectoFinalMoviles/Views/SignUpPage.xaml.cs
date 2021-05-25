using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalMoviles.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalMoviles.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        IAuth auth;
        public SignUpPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }
        private async void SignUpClicked(object sender, EventArgs e)
        {
            if (EmailInput.Text != null && PasswordInput.Text != null)
            {
                var user = auth.SignUpWithEmailAndPassword(EmailInput.Text, PasswordInput.Text);
                if (user != null)
                {
                    await DisplayAlert("Creación Exitosa", "Usuario creado exitosamente", "Aceptar");
                    var signOut = auth.Signout();

                    if (signOut)
                    {
                        Application.Current.MainPage = new LoginPage();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Ha ocurrido un error intentelo mas tarde", "Aceptar");
                    }
                }
            }
            else
            {
                await DisplayAlert("Campos vacíos", "Ingrese los campos solicitados", "Aceptar");
            }
        }

        private async void LoginClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}