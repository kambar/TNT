using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace TNTXamarin
{
    class ElementPage : ContentPage
    {
        private Label label;
        private Label label2;

        public ElementPage(Element iElement)
        {
            label = new Label {Text = iElement.Name};
            label2 = new Label { Text = iElement.Data };
            StackLayout layout = new StackLayout { VerticalOptions = LayoutOptions.Center };
            layout.Children.Add(label);
            //layout.Children.Add(label2);

            List<string>  imageList = iElement.processForImages();
            foreach (var img in imageList)
            {
                Image image = new Image { Source = iElement.Url + "/"+ img };
                layout.Children.Add(image);
            }
            

            Content = layout;
        }
    }
}
