using Cats.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Cats
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Conteudo carregado pela pagina
            var pageContent = new CatsPage();
            //carregamento da pagina com o conteudo
            MainPage = new NavigationPage(pageContent);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
