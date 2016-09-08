using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;
using System.Net;
using System.Text;

namespace TNTXamarin
{
    class MainPage : ContentPage
    {
        private Button btn;
        private Label label;
        private Entry entry;

        private ListView listview;
        ObservableCollection<Element> elementList;

        public MainPage()
        {
            btn = new Button { Text = "Add" };

            label = new Label { Text = "Add element:" };
            entry = new Entry { Placeholder = "[name]", Keyboard = Keyboard.Default };

            listview = new ListView { Header = "My elements:" };

            elementList = new ObservableCollection<Element>();
            var template = new DataTemplate(typeof(TextCell));
            template.SetBinding(TextCell.TextProperty, "Name");
            listview.ItemTemplate = template;
            listview.ItemsSource = elementList;

            // The root page of your application
            StackLayout layout = new StackLayout { VerticalOptions = LayoutOptions.Center };
            //layout.Children.Add(new Label { HorizontalTextAlignment = TextAlignment.Center, Text = "Welcome to Xamarin Forms!" });
            layout.Children.Add(label);
            layout.Children.Add(entry);
            layout.Children.Add(btn);
            layout.Children.Add(listview);

            Padding = new Thickness(20, Device.OnPlatform(40,20,20),20,20);
            Content = layout;


            //Listeners
            btn.Clicked += async (sender, args) =>
            {
                string urlAddress = "http://google.com";

                string data = "";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                using (HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync()))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream receiveStream = response.GetResponseStream();
                        using (StreamReader readStream = new StreamReader(receiveStream))
                        {
                            data = readStream.ReadToEnd();
                        }

                    }
                }

                elementList.Add( new Element { Name=entry.Text, Data = data , Url = urlAddress} );
                //this.DisplayAlert("Added", "Element has been add","OK");
    
            };

            listview.ItemSelected += async (sender, args) =>
            {
                var secondPage =  new ElementPage( args.SelectedItem as Element);
                await Navigation.PushAsync(secondPage);
            };
        }
    }
}
