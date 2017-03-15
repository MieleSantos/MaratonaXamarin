using AppDemonAzure.ViewModel;
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

namespace AppDemonAzure.View
{

    public partial class AppDemonAzurePage : ContentPage
    {
        public AppDemonAzurePage()
        {
            InitializeComponent();
            BindingContext = new ContactsVM();
        }

    }

}
