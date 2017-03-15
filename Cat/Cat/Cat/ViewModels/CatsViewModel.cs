using Cat.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cat.ViewModels
{
    public class CatsViewModel : INotifyPropertyChanged
    {
        //Coleção de gatos requisitados
        public ObservableCollection<Cats> Cat { get; set; }
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
            Cat = new ObservableCollection<Cats>();
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
                    var Repository = new Repositorio();
                    var Items = await Repository.GetCats();
                    //Limpa lista de e adiciona valores atualizados
                    Cat.Clear();
                    foreach (var Cat in Items)
                    {
                        Cat.Add(Cat);
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

