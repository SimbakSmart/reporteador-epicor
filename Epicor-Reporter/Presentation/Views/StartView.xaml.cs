using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentation.Views
{
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : Window
    {
        ObjectCache cache = MemoryCache.Default;
        public StartView()
        {
            InitializeComponent();
            // Crear datos de ejemplo (dummy data)
            //List<Person> people = new List<Person>
            //{
            //    new Person { Name = "John Doe", Age = 30, Email = "john.doe@example.com" },
            //    new Person { Name = "Jane Smith", Age = 25, Email = "jane.smith@example.com" },
            //    new Person { Name = "Michael Johnson", Age = 40, Email = "michael.johnson@example.com" }
            //    // Puedes agregar más personas según sea necesario


            //};

            //// Asignar la lista al DataGrid
            //dataGrid.ItemsSource = people;

            //cache["youName"] = "JohnDoe";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = (string)cache["youName"];

            MessageBox.Show(username);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string newName = string.Empty;

            //  cache.Remove("youName");
            newName = TxtName.Text;
            cache["youName"] =newName;

           // string username = (string)cache["youName"];

            MessageBox.Show("New Name");
        }

        //private void DarkModeToggle_Checked(object sender, RoutedEventArgs e)
        //{
        //    //ObjectCache cache = MemoryCache.Default;
        //    //PaletteHelper palette = new PaletteHelper();

        //    //ITheme theme = palette.GetTheme();

        //    //if (DarkModeToggle.IsChecked.Value)
        //    //{
        //    //    theme.SetBaseTheme(Theme.Dark);
        //    //}
        //    //else
        //    //{
        //    //    theme.SetBaseTheme(Theme.Light);
        //    //}
        //    //palette.SetTheme(theme);
        //    // Preferences
        //}
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
