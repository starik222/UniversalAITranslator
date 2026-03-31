using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalAITranslator
{
    public class ImageTranslationData
    {
        public string OriginalText { get; set; }
        public string TranslatedText { get; set; }
        public BoxCoordinates Coordinates { get; set; }

        public BindingImageTranslationData CreateBinding(int imageWidth, int imageHeight)
        {
            var rect = Coordinates.ToRectangle(imageWidth, imageHeight);
            BindingImageTranslationData result = new BindingImageTranslationData(imageWidth, imageHeight);
            result.OriginalText = OriginalText;
            result.TranslatedText = TranslatedText;
            result.X = rect.X;
            result.Y = rect.Y;
            result.Width = rect.Width;
            result.Height = rect.Height;
            return result;
        }

        public BindingImageTranslationData CreateBinding(string imagePath)
        {
            int height = 0;
            int width = 0;
            using (var fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var image = Image.FromStream(fileStream, false, false))
                {
                    height = image.Height;
                    width = image.Width;
                }
            }
            var rect = Coordinates.ToRectangle(width, height);
            BindingImageTranslationData result = new BindingImageTranslationData(width, height);
            result.OriginalText = OriginalText;
            result.TranslatedText = TranslatedText;
            result.X = rect.X;
            result.Y = rect.Y;
            result.Width = rect.Width;
            result.Height = rect.Height;
            return result;
        }
    }
    public class BoxCoordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        // Метод-хелпер для конвертации в стандартный Rectangle с учетом размера картинки
        public RectangleF ToRectangle(int imageWidth, int imageHeight)
        {
            float x = (X * imageWidth) / 1000f;
            float y = (Y * imageHeight) / 1000f;
            float w = (Width * imageWidth) / 1000f;
            float h = (Height * imageHeight) / 1000f;

            return new RectangleF(x, y, w, h);
        }
    }

    public class BindingImageTranslationData
    {
        public string OriginalText { get; set; }
        public string TranslatedText { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        [Browsable(false)]
        public int ImageWidth { get; set; }
        [Browsable(false)]
        public int ImageHeight { get; set; }
        [Browsable(false)]
        public TextFontData FontSettings { get; set; }
        [Browsable(false)]
        public RectangleData RectangleSettings { get; set; }

        public BindingImageTranslationData(int imageWidth, int imageHeight)
        {
            ImageHeight = imageHeight;
            ImageWidth = imageWidth;
            FontSettings = new TextFontData();
            RectangleSettings = new RectangleData();
        }

        public Size GetImageSize()
        {
            return new Size(ImageWidth, ImageHeight);
        }
    }

    public class TextFontData
    {
        public string FontName { get; set; } = "Franklin Gothic Medium Cond";
        public int FontSize { get; set; } = 18;
        public Color Color { get; set; } = Color.White;
        public bool StrokeEnabled { get; set; } = false;
        public int StrokeSize { get; set; } = 2; // пиксели
        public Color StrokeColor { get; set; } = Color.Black; // HEX цвет обводки
        public int StrokeOpacity { get; set; } = 100; // Видимость
        public string StrokePosition { get; set; } = "outside"; // outside, inside, center
        // Выравнивание текста (left, center, right)
        public string Justification { get; set; } = "center";
        // Интерлиньяж (межстрочное расстояние). Если null — используется авто-интерлиньяж
        public double? Leading { get; set; } = 12;
        public bool CenterOnX { get; set; } = false;
        public bool CenterOnY { get; set; } = false;

        public void Update(TextFontData data)
        {
            FontName = data.FontName;
            FontSize = data.FontSize;
            Color = data.Color;
            StrokeEnabled = data.StrokeEnabled;
            StrokeColor = data.StrokeColor;
            StrokeOpacity = data.StrokeOpacity;
            StrokePosition = data.StrokePosition;
            Justification = data.Justification;
            Leading = data.Leading;
            CenterOnX = data.CenterOnX;
            CenterOnY = data.CenterOnY;
        }

        public TextFontData Clone()
        {
            TextFontData data = new TextFontData();
            data.FontName = FontName;
            data.FontSize = FontSize;
            data.Color = Color;
            data.StrokeEnabled = StrokeEnabled;
            data.StrokeColor = StrokeColor;
            data.StrokeOpacity = StrokeOpacity;
            data.StrokePosition = StrokePosition;
            data.Justification = Justification;
            data.Leading = Leading;
            data.CenterOnX = CenterOnX;
            data.CenterOnY = CenterOnY;
            return data;
        }
    }

    public class RectangleData
    {
        public bool Visible { get; set; } = false;
        public Color Color { get; set; } = Color.Black;

        public void Update(RectangleData data)
        {
            Visible = data.Visible;
            Color = data.Color;
        }

        public RectangleData Clone()
        {
            RectangleData data = new RectangleData();
            data.Visible = Visible;
            data.Color = Color;
            return data;
        }
    }
}
