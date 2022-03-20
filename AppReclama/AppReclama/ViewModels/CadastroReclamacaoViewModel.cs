using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using AppReclama.Models;


namespace AppReclama.ViewModels
{
    [QueryProperty("PegarIdDaNavegacao", "parametro_id")]
    public class CadastroReclamacaoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string descricao, endereco, imagem;
        int id;
     
        public string PegarIdDaNavegacao
        {
            set
            {
                int id_parametro = Convert.ToInt32(Uri.UnescapeDataString(value));

                VerReclamacao.Execute(id_parametro);
            }
        }

        public string Descricao
        {
            get => descricao;
            set
            {
                descricao = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Descricao"));
            }
        }

        public string Endereco
        {
            get => endereco;
            set
            {
                endereco = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Endereco"));
            }
        }
        public string Imagem
        {
            get => imagem;
            set
            {
                imagem = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Imagem"));
            }
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Id"));
            }
        }


        public ICommand NovaReclamacao
        {
            get => new Command(() =>
            {
                Id = 0;
                Descricao = String.Empty;
                Endereco = String.Empty;
                Imagem = String.Empty;
            });
        }

        public ICommand SalvarReclamacao
        {
            get => new Command(async () =>
            {
                try
                {
                    Reclamacao model = new Reclamacao()
                    {
                        Descricao = this.Descricao,
                        Endereco = this.Endereco,
                        Imagem = this.Imagem
                    };

                    if (this.Id == 0)
                    {
                        await App.Database.Insert(model);

                    }
                    else
                    {
                        model.Id = this.Id;

                        await App.Database.Update(model);
                    }

                    await Application.Current.MainPage.DisplayAlert("Beleza!", "Reclamacao Salva!", "OK");

                    await Shell.Current.GoToAsync("//MeuPerfil");

                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                }
            });
        }


        public ICommand VerReclamacao
        {
            get => new Command<int>(async (int id) =>
            {
                try
                {
                    Reclamacao model = await App.Database.GetById(id);

                    this.Id = model.Id;
                    this.Descricao = model.Descricao;
                    this.Endereco = model.Endereco;
                    this.Imagem = model.Imagem;
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                }
            });
        }



    }
}
