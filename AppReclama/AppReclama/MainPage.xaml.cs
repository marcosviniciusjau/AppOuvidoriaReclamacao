using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppReclama
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            logotipo.Source = ImageSource.FromResource("AppReclama.Img.logotipo.png");
        }
    }
}
