using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppReclama.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Feed : ContentPage
    {
        public Feed()
        {
            InitializeComponent();
            logo.Source = ImageSource.FromResource("AppReclama.Img.peixelogotipo.png");
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new Views.fzrreclama());

            }
            catch (Exception ex)
            {
                DisplayAlert("Deu erro", ex.Message, "ok");
            }
        }
    }
}