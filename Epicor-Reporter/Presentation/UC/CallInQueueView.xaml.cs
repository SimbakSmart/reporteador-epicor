using System;
using System.Windows.Controls;

namespace Presentation.UC
{
    
    public partial class CallInQueueView : UserControl
    {
        public CallInQueueView()
        {
            InitializeComponent();
            DatePickerOpenDate.BlackoutDates.Add(new CalendarDateRange(DateTime.Today.AddDays(1), DateTime.MaxValue));
        }

    }
}
