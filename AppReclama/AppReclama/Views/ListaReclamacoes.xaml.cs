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
    public partial class ListaReclamacoes : ContentPage
    {
        public ListaReclamacoes()
        {
            BindingContext = new ListaReclamacoesViewModel();

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var vm = (ListaReclamacoesViewModel)BindingContext;

            vm.AtualizarLista.Execute(null);
        }
    }
}