using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WeatherTest.Views
{
    public partial class WeatherDetail : ContentPage
    {
        Person pessoa { get; set; }

        public WeatherDetail(String person)
        {
            this.pessoa = person.name;
            InitializeComponent();

        }
    }

    public class Person
    {
        String name { get; set; }
        String job { get; set; }
    }
}
