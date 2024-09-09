using Microsoft.Maui.Layouts;

namespace MauiApp1
{
    public class DateTimePage : ContentPage
    {
        Label lbl;
        DatePicker dp;
        TimePicker tp;
        AbsoluteLayout abs;
        public DateTimePage(int k)
        {
            lbl = new Label
            {
                BackgroundColor = Color.FromRgb(120, 44, 133),
                Text = "Select date or time"
            };

            dp = new DatePicker
            {
                MinimumDate = DateTime.Now.AddDays(-10),
                MaximumDate = DateTime.Now.AddDays(10),
                Format = "D"
            };
            dp.DateSelected += Select_date;

            tp = new TimePicker
            {
                Time = new TimeSpan(12, 0, 0)
            };
            tp.PropertyChanged += Select_time;

            abs = new AbsoluteLayout
            {
                Children = { lbl, dp, tp}
            };
            AbsoluteLayout.SetLayoutBounds(lbl, new Rect(10, 10, 200, 50));
            AbsoluteLayout.SetLayoutBounds(dp, new Rect(0.2, 0.2, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(dp, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(tp, new Rect(0.2, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(tp, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;
        }
        private void Select_time(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            lbl.Text ="Selected time: " + tp.Time.ToString();
        }
        private void Select_date(object? sender, DateChangedEventArgs e)
        {
            lbl.Text= "Selected date: " + e.NewDate.ToString("F");
        }
    }
}