using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;


namespace ColorMaker;

public partial class MainPage : ContentPage
{
    bool isRandom;
    string hexValue;
	public MainPage()
	{
		InitializeComponent();
	}

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
       if (!isRandom)
        {
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;
            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }
       
    }

    private void SetColor(Color color)
    {
        Debug.WriteLine(color.ToString());
        btnRandom.BackgroundColor = color;
        Container.BackgroundColor = color;
        hexValue = lblHex.Text = color.ToHex();
    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
        isRandom = true;
        Random randomColor = new Random();        

        Color color = Color.FromRgb(randomColor.Next(0,256), randomColor.Next(0, 256), randomColor.Next(0, 256));
        sldRed.Value = color.Red;
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;
        SetColor(color);
        isRandom = false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(hexValue);
        var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Long, 12);
        await toast.Show();
    }
}

