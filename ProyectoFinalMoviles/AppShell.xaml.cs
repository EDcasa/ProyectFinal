using ProyectoFinalMoviles.Models;
using ProyectoFinalMoviles.ViewModels;
using ProyectoFinalMoviles.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ProyectoFinalMoviles
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        IAuth auth;
        public AppShell()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
          //  Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            //Routing.RegisterRoute(nameof(StudentsPage), typeof(StudentsPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            var singOut = auth.Signout();
            if (singOut)
            {
                await Shell.Current.GoToAsync("//LoginPage");
            }
        }
    }
}
