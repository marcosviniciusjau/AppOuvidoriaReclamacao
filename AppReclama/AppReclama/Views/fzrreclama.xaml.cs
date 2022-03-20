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
    public partial class fzrreclama : ContentPage
    {
        public fzrreclama()
        {
            InitializeComponent();

            BindingContext = new CadastroReclamacaoViewModel();
        }

        protected override async void OnAppearing()
        {
            var vm = (CadastroReclamacaoViewModel)BindingContext;

            if (vm.Id == 0)
            {
                vm.NovaReclamacao.Execute(null);
            }
        }

        private void btnImage_Clicked(object sender, EventArgs e)
        {

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private void ListaReclamacoes_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new Views.ListaReclamacoes());

            }
            catch (Exception ex)
            {
                DisplayAlert("Deu erro", ex.Message, "ok");
            }
        }
       
    }
}