using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppReclama.ViewModels;

namespace AppReclama.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeuPerfil : ContentPage
    {
        public MeuPerfil()
        {
            BindingContext = new MeuPerfilViewModel();

            InitializeComponent();
            perfil_pequeno.Source = ImageSource.FromResource("AppReclama.Img.perfil_pequeno.png");
         
        }

        protected override void OnAppearing()
        {
            //DisplayAlert("teste", "teste", "ok");

            var vm = (MeuPerfilViewModel)BindingContext;

            vm.AtualizarLista.Execute(null);
        }
    }
}