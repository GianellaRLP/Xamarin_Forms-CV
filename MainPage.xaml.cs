using System;
using System.Globalization;
using Xamarin.Forms;

namespace App_DBP2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();

            // Añadir el conversor a los recursos de la página
            //Resources.Add("RadioButtonCheckedConverter", new RadioButtonCheckedConverter());
        }
    }

    // Clase del conversor definida dentro de MainPage.xaml.cs
    public class RadioButtonCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString() == parameter?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? parameter : null;
        }
    }
}

