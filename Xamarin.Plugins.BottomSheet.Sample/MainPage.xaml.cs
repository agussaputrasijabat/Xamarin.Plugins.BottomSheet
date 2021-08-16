using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Xamarin.Forms;

namespace Xamarin.Plugins.BottomSheet.Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void CollectionPush_Clicked(System.Object sender, System.EventArgs e)
        {
            var rnd = new Random();
            var faker = new Faker("en");
            var vehicles = new List<PickerItem>();
            for(int i = 1;i< 1000; i++)
            {
                vehicles.Add(new PickerItem(faker.Vehicle.Model())
                {
                    TextColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))
                });
            }

            var pickerItem = await BottomPicker.DisplayPicker(new PickerConfig
            {
                Title = "Select Vehicle",
                ItemsSource = vehicles,
                HeightRequest = 400,
                BackgroundColor = Color.White
            });

            Console.WriteLine(pickerItem);
        }
    }
}
