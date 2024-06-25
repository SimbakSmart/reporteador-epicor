using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Runtime.Caching;
using System.Windows;
using System.Windows.Media;


namespace Presentation.Views
{
    /// <summary>
    /// Reporte para ver las supportcall que esta en queues
    /// </summary>
    public partial class StartView : Window
    {
        ObjectCache cache = MemoryCache.Default;

        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        public StartView()
        {
            InitializeComponent();
          
        }

        //private void ToggleTheme_Click(object sender, RoutedEventArgs e)
        //{
        //    var theme = paletteHelper.GetTheme();

        //    if (theme.GetBaseTheme() == BaseTheme.Light)
        //    {
        //        SetTheme(BaseTheme.Dark);
        //    }
        //    else
        //    {
        //        SetTheme(BaseTheme.Light);
        //    }
        //}

        //private void SetTheme(BaseTheme baseTheme)
        //{
        //    var theme = paletteHelper.GetTheme();

        //    if (baseTheme == BaseTheme.Light)
        //    {
        //        theme.SetBaseTheme(Theme.Light);
        //    }
        //    else
        //    {
        //        theme.SetBaseTheme(Theme.Dark);
        //    }

        //    // Cambiar los colores primarios y de acento
        //    theme.SetPrimaryColor(Colors.Teal);
        //    theme.SetSecondaryColor(Colors.Orange);

        //    paletteHelper.SetTheme(theme);
        //}


        //private void ToggleTheme_Click(object sender, RoutedEventArgs e)
        //{
        //    //  var theme = paletteHelper.GetTheme();
        //    //var baseTheme = theme.GetBaseTheme() == BaseTheme.Dark ? BaseTheme.Light : BaseTheme.Dark;
        //    //theme.SetBaseTheme(baseTheme);
        //    //paletteHelper.SetTheme(theme);

        //    // SetLightTheme();
          

        //   //var theme = paletteHelper.GetTheme();
        //   // var baseTheme = theme.GetBaseTheme() == BaseTheme.Dark ? BaseTheme.Light : BaseTheme.Dark;
        //   // if (DarkModeToggle.IsChecked.Value)
        //   // {
        //   //     theme.SetBaseTheme(baseTheme);
        //   // }
        //   // else
        //   // {
        //   //     theme.SetBaseTheme(baseTheme);
        //   // }
        //   // paletteHelper.SetTheme(theme);

        //}

    //    private void SetLightTheme()
    //    {
    //        //var theme = paletteHelper.GetTheme();
    //        //theme.SetBaseTheme(BaseTheme.Light);
    //        //theme.PrimaryMid = new ColorPair(Colors.Teal, Colors.White);
    //        //theme.SecondaryMid = new ColorPair(Colors.Orange, Colors.White);
    //        //paletteHelper.SetTheme(theme);
    //    }

    //    private void DarkModeToggle_Checked(object sender, RoutedEventArgs e)
    //    {
    //        var theme = paletteHelper.GetTheme();
    //        var baseTheme = theme.GetBaseTheme() == BaseTheme.Dark ? BaseTheme.Light : BaseTheme.Dark;

    //        //if (baseTheme == BaseTheme.Light)
    //        //{

    //        //    theme.SetBaseTheme(BaseTheme.Dark);
    //        //}
    //        //else
    //        //{
    //        //    theme.SetBaseTheme(BaseTheme.Light);
    //        //}
    //        //paletteHelper.SetTheme(theme);





    //        if (DarkModeToggle.IsChecked.Value == true)
    //        {
    //            theme.SetBaseTheme(BaseTheme.Dark);
    //        }
    //        else if (!DarkModeToggle.IsChecked.Value == false)
    //        {
    //            theme.SetBaseTheme(BaseTheme.Light);
    //        }
    //        paletteHelper.SetTheme(theme);
    //    }
    }

   
}
