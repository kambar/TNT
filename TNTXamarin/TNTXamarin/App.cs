using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TNTXamarin
{
    public class App : Application
    {
        public App()
        {
            int counter = 0;
            Button btn = new Button();
            btn.Text = "START #:" + counter.ToString();
            btn.Clicked += (sender, args) =>
            {
                counter++;
                btn.Text = "START #:" + counter;
            };

            ListView listview = new ListView();
            listview.Header = "LISTE";
            listview.Footer = "FOOTER";

            ObservableCollection<string> employeeList = new ObservableCollection<string>();
            listview.ItemsSource = employeeList;

            //Mr. Mono will be added to the ListView because it uses an ObservableCollection
            employeeList.Add("element1");
            employeeList.Add("element2");
            employeeList.Add("element3");
            employeeList.Add("element4");
            employeeList.Add("element5");




            // The root page of your application
            StackLayout layout = new StackLayout { VerticalOptions = LayoutOptions.Center };
            layout.Children.Add(new Label { HorizontalTextAlignment = TextAlignment.Center, Text = "Welcome to Xamarin Forms!" });
            layout.Children.Add(btn);
            layout.Children.Add(listview);
            ContentPage myContentPage = new ContentPage { Content = layout };

            MainPage = myContentPage;
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
