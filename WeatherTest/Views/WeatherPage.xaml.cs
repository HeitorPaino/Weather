using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

using Xamarin.Forms;

namespace WeatherTest.Views
{
    public partial class WeatherPage : ContentPage
    {
		public class Person
		{
			String name { get; set; }
			String job { get; set; }
		}

        Object result;

        public WeatherPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private async void getJson(){
            HttpClient cliente = new HttpClient();

            var data = await cliente.GetStringAsync("http://openweathermap.org/data/2.5/weather?id=3448439&appid=b1b15e88fa797225412429c1c50c122a1");
            var json = JsonConvert.DeserializeObject(data);
            System.Diagnostics.Debug.WriteLine(json);
        }

        private async void sendJson(){
			HttpClient cliente = new HttpClient();

			var json = JsonConvert.SerializeObject(new
			{
				name = "Heitor",
				job = "Programador",

			});

			var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            var resposta = await cliente.PostAsync("https://reqres.in/api/users", conteudo);

            //System.Diagnostics.Debug.WriteLine(resposta);

            if(resposta.IsSuccessStatusCode){
                var content = await resposta.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(content);
                this.result = JsonConvert.DeserializeObject(content);
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //this.getJson();
            this.sendJson();
            Navigation.PushAsync(new WeatherDetail(result.ToString()));
        }
    }
}
