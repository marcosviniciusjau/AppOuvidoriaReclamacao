using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using AppReclama.Models;
using Xamarin.Forms;

namespace AppReclama.ViewModels
{
    class ListaReclamacoesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /**
         * Pegando o que foi digitado pelo usuário.
         */
        public string ParametroBusca { get; set; }

        /**
         * Gerencia se mostra ao usuário o RefreshView
         */
        bool estaAtualizando = false;
        public bool EstaAtualizando
        {
            get => estaAtualizando;
            set
            {
                estaAtualizando = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EstaAtualizando"));
            }
        }

        /**
         * Coleção que armazena as atividades do usuário.
         */
        ObservableCollection<Reclamacao> listaReclamacoes = new ObservableCollection<Reclamacao>();
        public ObservableCollection<Reclamacao> ListaReclamacoes
        {
            get => listaReclamacoes;
            set => listaReclamacoes = value;
        }

        public ICommand AtualizarLista
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (EstaAtualizando)
                            return;

                        EstaAtualizando = true;

                        List<Reclamacao> tmp = await App.Database.GetAllRows();

                        ListaReclamacoes.Clear();

                        tmp.ForEach(i => ListaReclamacoes.Add(i));

                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");

                    }
                    finally
                    {
                        EstaAtualizando = false;
                    }
                });
            }
        }

        public ICommand Buscar
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (EstaAtualizando)
                            return;

                        EstaAtualizando = true;

                        List<Reclamacao> tmp = await App.Database.Search(ParametroBusca);

                        ListaReclamacoes.Clear();

                        tmp.ForEach(i => ListaReclamacoes.Add(i));

                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                    }
                    finally
                    {
                        EstaAtualizando = false;
                    }
                });
            }
        }

        public ICommand AbrirDetalhesReclamacoes
        {
            get
            {
                return new Command<int>(async (int id) =>
                {
                    await Shell.Current.GoToAsync($"//CadastroReclamacao?parametro_id={id}");
                });
            }
        }


        public ICommand Remover
        {
            get
            {
                return new Command<int>(async (int id) =>
                {
                    try
                    {
                        bool conf = await Application.Current.MainPage.DisplayAlert("Tem Certeza?", "Excluir", "Sim", "Não");

                        if (conf)
                        {
                            await App.Database.Delete(id);
                            AtualizarLista.Execute(null);
                        }
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                    }
                    finally
                    {
                        EstaAtualizando = false;
                    }
                });
            }
        }
    }
}