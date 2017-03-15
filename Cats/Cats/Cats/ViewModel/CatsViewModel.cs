using Cats.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cats.ViewModel
{
        public class CatsViewModel : INotifyPropertyChanged
        {
            //Coleção de gatos requisitados
            public ObservableCollection<Cat> Cats { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
                else { return; }
            }

            //bool que retorna se esta ocupado
            private bool Busy;
            public bool IsBusy
            {
                get
                {
                    return Busy;
                }
                set
                {
                    Busy = value;
                    //atualiza o valor da propiedade na view xaml
                    OnPropertyChanged();
                    //muda estado do command se o busy for alterado
                    GetCatsCommand.ChangeCanExecute();
                }
            }
            //Comando que será chamado pela binding criada no View xaml 
            public Command GetCatsCommand { get; set; }



            // Construtor
            public CatsViewModel()
            {
                //Cats recebe uma nova instancia de 'ObservableCollection<Cat>();'
                Cats = new ObservableCollection<Cat>();
                //ação executada pelo command quando chamado pela view xaml
                GetCatsCommand = new Command(async () => await GetCats(), () => !IsBusy);
            }


            //Atualiza os dados locais do Gato de maneira assincrona
            async Task GetCats()
            {
                if (!IsBusy)
                {
                    Exception Error = null;
                    try
                    {
                        IsBusy = true;
                        // cria instancia do repositório e inicia a tarefa assincrona
                        var Repository = new Repository();
                        var Items = await Repository.GetCats();

                        //Limpa lista de e adiciona valores atualizados
                        Cats.Clear();
                        foreach (var Cat in Items)
                        {
                            Cats.Add(Cat);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error = ex;
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                    // se ocorreu um erro mostre para o usuário
                    if (Error != null)
                    {
                        await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                        "Error!", Error.Message, "OK");
                    }
                }
                return;
            }


        }
    }

