
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Input;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace Presentation
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            //this.WindowState = WindowState.Maximized;
            // Ajustar el tamaño máximo de la ventana para que no oculte la barra de Windows
            this.WindowState = WindowState.Normal;
            this.WindowState = WindowState.Maximized;
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.Top = SystemParameters.WorkArea.Top;
            this.Left = SystemParameters.WorkArea.Left;
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void DarkModeToggle_Checked(object sender, RoutedEventArgs e)
        {
            //PaletteHelper palette = new PaletteHelper();

            //ITheme theme = palette.GetTheme();

            //if (DarkModeToggle.IsChecked.Value)
            //{
            //    theme.SetBaseTheme(Theme.);
            //}
            //else
            //{
            //    theme.SetBaseTheme(Theme.Light);
            //}
            //palette.SetTheme(theme);

        }
    }
}
