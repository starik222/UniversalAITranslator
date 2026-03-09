using System;
using System.Collections.Generic;
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
            BindingImageTranslationData result = new BindingImageTranslationData();
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
        public Rectangle ToRectangle(int imageWidth, int imageHeight)
        {
            int x = (X * imageWidth) / 1000;
            int y = (Y * imageHeight) / 1000;
            int w = (Width * imageWidth) / 1000;
            int h = (Height * imageHeight) / 1000;

            return new Rectangle(x, y, w, h);
        }
    }

    public class BindingImageTranslationData()
    {
        public string OriginalText { get; set; }
        public string TranslatedText { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
