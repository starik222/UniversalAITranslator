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
            BindingImageTranslationData result = new BindingImageTranslationData(this, imageWidth, imageHeight);
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
            BindingImageTranslationData result = new BindingImageTranslationData(this, width, height);
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

        private int imgWidth;
        private int imgHeight;

        private ImageTranslationData originalData;

        public BindingImageTranslationData(ImageTranslationData origData, int imageWidth, int imageHeight)
        {
            originalData = origData;
            imgHeight = imageHeight;
            imgWidth = imageWidth;
        }

        public void UpdateOriginal()
        {
            originalData.OriginalText = OriginalText;
            originalData.TranslatedText = TranslatedText;
            originalData.Coordinates.X = (int)Math.Round(((X * 1000f) / imgWidth));
            originalData.Coordinates.Y = (int)Math.Round((Y * 1000f) / imgHeight);
            originalData.Coordinates.Width = (int)Math.Round((Width * 1000f) / imgWidth);
            originalData.Coordinates.Height = (int)Math.Round((Height * 1000f) / imgHeight);
        }
    }
}
