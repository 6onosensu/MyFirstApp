using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    internal class Common : ContentPage
    {

        HorizontalStackLayout hsl;
        VerticalStackLayout vst;
        List<string> btns = new List<string> { "BACK", "HOME", "NEXT" };
        public Common(HorizontalStackLayout hsl, VerticalStackLayout vst, List<string> btns)
        {
            this.hsl = hsl;
            this.vst = vst;
            this.btns = btns;

            hsl = new HorizontalStackLayout { };
            for (int i = 0; i < 3; i++)
            {
                Button b = new Button
                {
                    Text = btns[i],
                    ZIndex = i,
                    WidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width / 8.3,
                };
                hsl.Add(b);
                b.Clicked += Btn_Clicked;
            }
        }

        private async void Btn_Clicked(object? sender, EventArgs e)
        {
            Button clicked_btn = (Button)sender;
            if (clicked_btn.ZIndex == 0)
            {
                await Navigation.PushAsync(new TextPage(clicked_btn.ZIndex));
            }
            else if (clicked_btn.ZIndex == 1)
            {
                await Navigation.PushAsync(new StartPage());
            }
            else
            {
                await Navigation.PushAsync(new FigurePage(clicked_btn.ZIndex));
            }
        }
    }
}
