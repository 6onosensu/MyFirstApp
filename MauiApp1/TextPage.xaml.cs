namespace MauiApp1;

public partial class TextPage: ContentPage
{
	Label lbl;
	Editor editor;
	Button btn_back;
	public TextPage()
	{
		lbl = new Label
		{
			Text = "Pealkiri",
			TextColor = Color.FromRgb(200, 0, 0),
			FontFamily = "Hey Comic"
		};
		editor = new Editor
		{
			Placeholder = "Vihje: Sisesta siia tekst",
			PlaceholderColor = Color.FromRgb(50, 100, 100),
			TextColor = Color.FromRgb(10, 50, 200),
		};
		VerticalStackLayout vst = new VerticalStackLayout
		{
			Children =
		};

        List<string> btns = new List<string> { "", "" };
        for (int i = 0; i < btns.Count; i++)
        {
            Button btn = new Button
            {
                Text = btns[i],
                BackgroundColor = Color.FromRgb(20, 100, 200),
                TextColor = Color.FromRgb(10, 20, 15),
                FontFamily = "Hey Comic",
                BorderWidth = 10,
                ZIndex = i
            };
        }
    }
}