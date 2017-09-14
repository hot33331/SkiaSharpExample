using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Xamarin.Forms;

namespace SkiaSharpExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            skiaImage.Source = CreateImageSource("123");
        }

        private static ImageSource CreateImageSource(string text)
        {
            int numberSize = 20;
            int margin = 5;
            SKBitmap bitmap = new SKBitmap(30, numberSize + margin * 2);
            SKCanvas canvas = new SKCanvas(bitmap);

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.StrokeAndFill,
                TextSize = numberSize,
                Color = SKColors.Red,
                StrokeWidth = 1,
            };

            canvas.DrawText(text, 0, numberSize, paint);
            SKImage skImage = SKImage.FromBitmap(bitmap);
            SKData data = skImage.Encode(SKEncodedImageFormat.Png, 100);
            return ImageSource.FromStream(data.AsStream);
        }
    }
}
