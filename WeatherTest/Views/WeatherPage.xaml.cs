using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace WeatherTest.Views
{
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
        }

        private async void getJson(){
            HttpClient cliente = new HttpClient();

            var data = await cliente.GetStringAsync("http://openweathermap.org/data/2.5/weather?id=3448439&appid=b1b15e88fa797225412429c1c50c122a1");
            var json = JsonConvert.DeserializeObject(data);
            System.Diagnostics.Debug.WriteLine(json);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            this.getJson();
        }
    }
}
