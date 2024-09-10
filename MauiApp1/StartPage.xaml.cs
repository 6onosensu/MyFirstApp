namespace MauiApp1;

public partial class StartPage : ContentPage
{
    List<ContentPage> pages = new List<ContentPage>() 
    { 
        new TextPage(0),
        new FigurePage(1),
        new DateTimePage(2),
        new StepperSliderPage(3),
        new Frame_Page(4),
        new Image_Page(5),
    };
    List<string> txt = new List<string> 
    { 
        "Text Page", 
        "Figure Page", 
        "Date and Time", 
        "Stepper and Slider",
        "Frame Page",
        "Image Page",
    };
    ScrollView sv;
    VerticalStackLayout vst;
    public StartPage()
    {
        Title = "Home";
        vst = new VerticalStackLayout { BackgroundColor = Color.FromRgb(180, 100, 20) };
        for (int i = 0; i < pages.Count; i++)
        {
            Button btn = new Button
            {
                Text = txt[i],
                BackgroundColor = Color.FromRgb(20, 100, 200),
                TextColor = Color.FromRgb(10, 20, 15),
                FontFamily = "Hey Comic",
                BorderWidth = 10,
                ZIndex = i
            };
            vst.Add(btn);
            btn.Clicked += Btn_Clicked;
        }
        sv = new ScrollView { Content = vst };
        Content = sv;
    }

    private async void Btn_Clicked(object? sender, EventArgs e)
    {
        Button button = (Button)sender; //sender as Button;
        await Navigation.PushAsync(pages[button.ZIndex]);
    }
}