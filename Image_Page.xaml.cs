namespace MauiApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Image_Page : ContentPage
    {
        Grid gr4x1, gr3x3;
        Picker picker;
        Image img;
        Switch s_img, s_grid;
        Random rnd = new Random();
        public Image_Page(int k)
        {
            gr4x1 = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height=new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height=new GridLength(3, GridUnitType.Star) },
                    new RowDefinition { Height=new GridLength(3, GridUnitType.Star) },
                    new RowDefinition { Height=new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width=new GridLength (1, GridUnitType.Star) },
                    new ColumnDefinition {Width=new GridLength (1, GridUnitType.Star) },
                },
            };
            picker = new Picker
            {
                Title="Images",
                HorizontalOptions = LayoutOptions.Center,
            };

            picker.Items.Add("First image");
            picker.Items.Add("Second image");
            picker.Items.Add("Third image");
            picker.Items.Add("Select shosen image");
            picker.SelectedIndexChanged += ImageSelection;
            img = new Image
            {
                Source = "dornet_bot.png",
                HorizontalOptions = LayoutOptions.Center,
            };

            s_img = new Switch 
            { 
                IsToggled = true,
                IsEnabled = true,
                HorizontalOptions = LayoutOptions.Center,
            };
            s_img.Toggled += S_img_Toggled;

            s_grid = new Switch
            {
                IsToggled = false,
                IsEnabled = false,
                HorizontalOptions = LayoutOptions.Center,
            };
            s_grid.Toggled += S_grid_Toggled;

            gr4x1.Add(picker, 0, 0);
            gr4x1.Add(img, 0, 1);
            gr4x1.Add(s_img, 0, 3);
            gr4x1.Add(s_grid, 1, 3);

            Content = gr4x1;
        }

        private void S_grid_Toggled(object? sender, ToggledEventArgs e)
        {
            gr3x3 = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                },
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Frame frame = new Frame
                    {
                        BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255))
                    };
                    gr3x3.Add(frame, i, j);
                }
            }
            if (e.Value)
            {
                gr4x1.Add(gr3x3, 0, 2);
                gr4x1.SetColumnSpan(gr3x3, 2);
            }
            else
            {
                gr4x1.RemoveAt(4);
            }
        }
        private void S_img_Toggled(object? sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                img.IsVisible = true;
            }
            else
            {
                img.IsVisible = false;
            }
        }

        private async void ImageSelection(object? sender, EventArgs e) 
        {
            if (picker.SelectedIndex == 3)
            {
                var images = await FilePicker.Default.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                });
                var imgSource = images.FullPath.ToString();
                img.Source = imgSource;
            }
            else if (picker.SelectedIndex == 2)
            {
                img.Source = "images.jpg";
            }
            else if (picker.SelectedIndex == 1)
            {
                img.Source = "untitled.jpg";
            }
            else if (picker.SelectedIndex == 0)
            {
                img.Source = "dotnet_bot.png";
            }
        }
    }
}