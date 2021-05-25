using ProyectoFinalMoviles.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProyectoFinalMoviles.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}