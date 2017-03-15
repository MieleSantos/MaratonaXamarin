using Cats.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cats.View
{
    public partial class CatsPage : ContentPage
    {
        public CatsPage()
        {
            InitializeComponent();
            ListViewCats.ItemSelected += ListViewCats_ItemSelectedAsync;
        }

        private async void ListViewCats_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            //armazena gato selecionado
            Cat selectedCat = e.SelectedItem as Cat;

            //checa se o gato esta vazio
            if (selectedCat != null)
            {
                //Cria nova janela na navigation passando o selectedCat de referencia
                await Navigation.PushAsync(new DetailsPage(selectedCat));
            }
        }
    }
}
