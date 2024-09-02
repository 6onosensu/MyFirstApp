namespace MauiApp1;

public partial class FigurePage : ContentPage
{
	BoxView bw;
	Random rnd = new Random();
	public FigurePage(int k)
	{
		int red = rnd.Next(0, 255);
		int blue = rnd.Next(0, 255);
		int green = rnd.Next(0, 255);
		bw = new BoxView
		{
			Color = Color.FromRgb(red, green, blue),
			CornerRadius = 10,
			WidthRequest = 200,
			HeightRequest = 200,
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center, 
		};
		TapGestureRecognizer tapGR = new TapGestureRecognizer();
        tapGR.Tapped += click_on_box;
		bw.GestureRecognizers.Add(tapGR);
		VerticalStackLayout vsl = new VerticalStackLayout { Children = { bw }};
		Content = vsl;
	}

    private void click_on_box(object? sender, TappedEventArgs e)
    {
        bw.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

    }
}