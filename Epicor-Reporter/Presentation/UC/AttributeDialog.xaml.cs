
using Core.Models;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
namespace Presentation.UC
{
   
    public partial class AttributeDialog : UserControl
    {
        public AttributeDialog(List<AttributeInQueue> attibute)
        {
            InitializeComponent();

            ListDetails.ItemsSource = attibute;

            if (attibute.Count > 0) {
                TBMessage.Visibility = Visibility.Hidden;
            }
            else
            {
                ListDetails.Visibility = Visibility.Hidden;
            }
        }
    }
}
