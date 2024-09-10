namespace MauiApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Frame_Page : ContentPage
    {
        Frame fr;
        Label lbl;
        public Frame_Page(int k)
        {
            lbl = new Label
            {
                Text = "Frame design",
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label))
            };

            fr = new Frame 
            { 
            
            };
        }
    }
}