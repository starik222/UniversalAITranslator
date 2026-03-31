using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace UniversalAITranslator
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class BackgroundColorDetector
    {
        /// <summary>
        /// Определяет общий цвет фона внутри указанных координат путем анализа всего периметра.
        /// </summary>
        public static Color GetBackgroundColor(Bitmap image, Rectangle bounds, int padding = 1, int colorTolerance = 20)
        {
            int left = Math.Max(0, bounds.Left - padding);
            int top = Math.Max(0, bounds.Top - padding);
            int right = Math.Min(image.Width - 1, bounds.Right + padding);
            int bottom = Math.Min(image.Height - 1, bounds.Bottom + padding);

            List<Color> perimeterPixels = new List<Color>();

            // Собираем пиксели по всему периметру
            for (int x = left; x <= right; x++)
            {
                perimeterPixels.Add(image.GetPixel(x, top));
                if (top != bottom) perimeterPixels.Add(image.GetPixel(x, bottom));
            }
            for (int y = top + 1; y < bottom; y++)
            {
                perimeterPixels.Add(image.GetPixel(left, y));
                if (left != right) perimeterPixels.Add(image.GetPixel(right, y));
            }

            return GetDominantColor(perimeterPixels, colorTolerance);
        }

        /// <summary>
        /// Возвращает цвета фона раздельно для верхней и нижней границы текста.
        /// </summary>
        public static (Color TopColor, Color BottomColor) GetTopAndBottomColors(Bitmap image, Rectangle bounds, int padding = 1, int colorTolerance = 20)
        {
            int left = Math.Max(0, bounds.Left - padding);
            int top = Math.Max(0, bounds.Top - padding);
            int right = Math.Min(image.Width - 1, bounds.Right + padding);
            int bottom = Math.Min(image.Height - 1, bounds.Bottom + padding);

            List<Color> topPixels = new List<Color>();
            List<Color> bottomPixels = new List<Color>();

            // Собираем пиксели только с верхней и нижней линии
            for (int x = left; x <= right; x++)
            {
                topPixels.Add(image.GetPixel(x, top));
                if (top != bottom)
                    bottomPixels.Add(image.GetPixel(x, bottom));
            }

            Color topColor = GetDominantColor(topPixels, colorTolerance);
            Color bottomColor = GetDominantColor(bottomPixels, colorTolerance); // Если высота 1px, вернет белый, но это краевой случай

            // Если высота рамки 1 пиксель, нижний цвет приравниваем к верхнему
            if (top == bottom) bottomColor = topColor;

            return (topColor, bottomColor);
        }

        /// <summary>
        /// Определяет, является ли фон вертикальным градиентом, сравнивая верхний и нижний цвета.
        /// </summary>
        /// <param name="gradientThreshold">Порог разницы цветов (обычно 30-50). Чем больше, тем сильнее должны отличаться цвета.</param>
        public static bool IsVerticalGradient(Color topColor, Color bottomColor, int gradientThreshold = 30)
        {
            // Вычисляем евклидово расстояние между двумя цветами
            int rDiff = topColor.R - bottomColor.R;
            int gDiff = topColor.G - bottomColor.G;
            int bDiff = topColor.B - bottomColor.B;

            double distance = Math.Sqrt((rDiff * rDiff) + (gDiff * gDiff) + (bDiff * bDiff));

            // Если расстояние больше порога - это градиент
            return distance > gradientThreshold;
        }

        /// <summary>
        /// Комплексный метод: получает цвета верха/низа и сразу определяет, градиент ли это.
        /// </summary>
        public static bool CheckIfGradientAndGetColors(Bitmap image, Rectangle bounds, out Color topColor, out Color bottomColor, int padding = 1, int colorTolerance = 20, int gradientThreshold = 30)
        {
            var colors = GetTopAndBottomColors(image, bounds, padding, colorTolerance);
            topColor = colors.TopColor;
            bottomColor = colors.BottomColor;

            return IsVerticalGradient(topColor, bottomColor, gradientThreshold);
        }

        // --- Приватный вспомогательный функционал ---

        /// <summary>
        /// Кластеризует пиксели и находит усредненный цвет самой большой группы
        /// </summary>
        private static Color GetDominantColor(IEnumerable<Color> pixels, int colorTolerance)
        {
            if (!pixels.Any()) return Color.White;

            List<ColorGroup> groups = new List<ColorGroup>();
            int toleranceSquared = colorTolerance * colorTolerance * 3;

            foreach (Color color in pixels)
            {
                bool addedToGroup = false;
                foreach (var group in groups)
                {
                    Color avgColor = group.GetAverageColor();

                    int rDiff = color.R - avgColor.R;
                    int gDiff = color.G - avgColor.G;
                    int bDiff = color.B - avgColor.B;
                    int distanceSquared = (rDiff * rDiff) + (gDiff * gDiff) + (bDiff * bDiff);

                    if (distanceSquared <= toleranceSquared)
                    {
                        group.AddColor(color);
                        addedToGroup = true;
                        break;
                    }
                }

                if (!addedToGroup)
                {
                    groups.Add(new ColorGroup(color));
                }
            }

            var dominantGroup = groups.OrderByDescending(g => g.Count).First();
            return dominantGroup.GetAverageColor();
        }

        private class ColorGroup
        {
            public int Count { get; private set; }
            private long sumR, sumG, sumB;

            public ColorGroup(Color initialColor)
            {
                AddColor(initialColor);
            }

            public void AddColor(Color color)
            {
                Count++;
                sumR += color.R;
                sumG += color.G;
                sumB += color.B;
            }

            public Color GetAverageColor()
            {
                return Color.FromArgb((int)(sumR / Count), (int)(sumG / Count), (int)(sumB / Count));
            }
        }
    }
}
