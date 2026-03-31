using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace UniversalAITranslator
{
    public class BackgroundColorDetector
    {
        /// <summary>
        /// Определяет цвет фона внутри указанных координат путем анализа периметра.
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="bounds">Координаты текста</param>
        /// <param name="padding">Отступ наружу от границ текста (рекомендуется 1-2, если текст касается краев)</param>
        /// <param name="colorTolerance">Допуск схожести цветов (0-255). Обычно 15-30 достаточно для JPEG.</param>
        /// <returns>Преобладающий цвет фона</returns>
        public static Color GetBackgroundColor(Bitmap image, Rectangle bounds, int padding = 1, int colorTolerance = 20)
        {
            // 1. Расширяем рамку на величину padding и проверяем, чтобы не выйти за края картинки
            int left = Math.Max(0, bounds.Left - padding);
            int top = Math.Max(0, bounds.Top - padding);
            int right = Math.Min(image.Width - 1, bounds.Right + padding);
            int bottom = Math.Min(image.Height - 1, bounds.Bottom + padding);

            List<Color> perimeterColors = new List<Color>();

            // 2. Собираем пиксели по верхней и нижней границе
            for (int x = left; x <= right; x++)
            {
                perimeterColors.Add(image.GetPixel(x, top));
                if (top != bottom)
                    perimeterColors.Add(image.GetPixel(x, bottom));
            }

            // 3. Собираем пиксели по левой и правой границе (исключая углы, которые уже взяли)
            for (int y = top + 1; y < bottom; y++)
            {
                perimeterColors.Add(image.GetPixel(left, y));
                if (left != right)
                    perimeterColors.Add(image.GetPixel(right, y));
            }

            if (perimeterColors.Count == 0) return Color.White; // Фолбэк

            // 4. Группируем похожие цвета (Кластеризация)
            List<ColorGroup> groups = new List<ColorGroup>();
            int toleranceSquared = colorTolerance * colorTolerance * 3; // Ускоренное вычисление дистанции

            foreach (Color color in perimeterColors)
            {
                bool addedToGroup = false;
                foreach (var group in groups)
                {
                    Color avgColor = group.GetAverageColor();

                    // Вычисляем квадрат евклидова расстояния между цветами
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

            // 5. Находим группу с наибольшим количеством пикселей (самый частый цвет)
            var dominantGroup = groups.OrderByDescending(g => g.Count).First();

            return dominantGroup.GetAverageColor();
        }

        // Вспомогательный класс для накопления и усреднения похожих цветов
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
