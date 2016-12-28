using Xamarin.Forms;

namespace App3
{
    public class MainMenu : ContentPage
    {
        public MainMenu(string Name)
        {
            var nombre = new Label {
                Text= "Bienvenido "+ Name,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Content = new StackLayout {
                Padding = 60,
                Spacing = 10,
                Children = { nombre }
            };
        }
    }
}