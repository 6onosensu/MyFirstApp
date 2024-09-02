namespace MauiApp1;


public partial class TextPage : ContentPage
{

	Editor editor;
    Label lbl;
    //Button btn_back, btn_next, btn_home;
	VerticalStackLayout vst;
    HorizontalStackLayout hsl;
    List<string> btns = new List<string> { "BACK", "HOME", "NEXT" };

    public TextPage(int k)
	{
        
		lbl = new Label
		{
			Text = "Pealkiri",
			TextColor = Color.FromRgb(200, 0, 0),
			FontFamily = "Hey Comic",
            FontAttributes = FontAttributes.Bold,
            TextDecorations = TextDecorations.Underline,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center,
            FontSize = 28,
		};
		editor = new Editor
		{
			Placeholder = "Vihje: Sisesta siia tekst",
			PlaceholderColor = Color.FromRgb(50, 100, 100),
			TextColor = Color.FromRgb(10, 50, 200),
            BackgroundColor = Color.FromRgb(100, 50, 200),
            FontSize = 28,
            FontAttributes = FontAttributes.Italic,
		};
        editor.TextChanged += Editor_TextChanged;

		hsl = new HorizontalStackLayout { };
        for (int i = 0; i < 3; i++)
        {
            Button b = new Button
            {
                Text = btns[i],
                ZIndex = i,
                WidthRequest=DeviceDisplay.Current.MainDisplayInfo.Width/8.3,
            };
			hsl.Add(b);
            b.Clicked += Btn_Clicked;
        }

        vst = new VerticalStackLayout
        {
            Children = { lbl, editor, hsl }
        };
		Content = vst;

    }

    private void Editor_TextChanged(object? sender, TextChangedEventArgs e)
    {
        lbl.Text=editor.Text;
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