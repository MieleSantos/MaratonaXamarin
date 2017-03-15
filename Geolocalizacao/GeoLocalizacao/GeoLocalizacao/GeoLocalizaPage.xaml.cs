using Plugin.ExternalMaps;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GeoLocalizacao
{
    public partial class GeoLocalizaPage : ContentPage
    {
        public GeoLocalizaPage()
        {
            InitializeComponent();
        }

        double latitude = 0;
        double longitude = 0;
        private async void btnGeolocalizacao_Clicked(object sender, EventArgs e)
        {
            lblGeoLocatizacao.Text = "obtendo geoLocalizacao....\n";
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                lblGeoLocatizacao.Text += "Status: " + position.Timestamp + "\n";
                lblGeoLocatizacao.Text += "Latidude: " + position.Latitude + "\n";
                lblGeoLocatizacao.Text += "Longitudde: " + position.Longitude ;

                latitude = position.Latitude;
                longitude = position.Longitude;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro:", ex.Message, "Ok");
            }
        }

        private void btnMostraPosicao_Clicked(object sender, EventArgs e)
        {
            try
            {
                CrossExternalMaps.Current.NavigateTo("Miele", latitude, longitude);

            }
            catch (Exception ex)
            {
                DisplayAlert("Erro: ", ex.Message, "Ok");
            }
        }
    }
}
