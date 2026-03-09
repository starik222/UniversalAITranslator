using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalAITranslator
{
    public static class TextSplitter
    {
        /// <summary>
        /// Разбивает текст на указанное количество строк с оптимальным выравниванием по длине.
        /// Не разрывает слова и не отделяет знаки препинания от слов.
        /// </summary>
        /// <param name="text">Исходный текст</param>
        /// <param name="lineCount">Желаемое количество строк</param>
        /// <returns>Массив строк</returns>
        public static string[] SplitTextIntoLines(string text, int lineCount)
        {
            if (string.IsNullOrWhiteSpace(text) || lineCount <= 0)
                return Array.Empty<string>();

            // Нормализуем пробелы
            text = string.Join(" ", text.Split(default(char[]), StringSplitOptions.RemoveEmptyEntries));

            if (lineCount == 1)
                return new[] { text };

            // Разбиваем на слова (слово + прилегающая пунктуация остаются вместе)
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
                return Array.Empty<string>();

            // Если слов меньше или равно количеству строк
            if (words.Length <= lineCount)
                return words;

            int n = words.Length;

            // Предвычисляем префиксные суммы длин слов
            var prefixSum = new int[n + 1];
            for (int i = 0; i < n; i++)
                prefixSum[i + 1] = prefixSum[i] + words[i].Length;

            // Длина строки из слов [start..end]: сумма длин + пробелы между словами
            int GetLineLength(int start, int end) =>
                prefixSum[end + 1] - prefixSum[start] + (end - start);

            int totalLength = GetLineLength(0, n - 1);
            double idealLength = (double)totalLength / lineCount;

            // DP: dp[i, j] = минимальная "стоимость" разбиения первых i слов на j строк
            // Стоимость = сумма квадратов отклонений от идеальной длины
            var dp = new double[n + 1, lineCount + 1];
            var splitPoint = new int[n + 1, lineCount + 1];

            // Инициализация
            for (int i = 0; i <= n; i++)
                for (int j = 0; j <= lineCount; j++)
                    dp[i, j] = double.MaxValue;

            dp[0, 0] = 0;

            // Заполняем таблицу DP
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= Math.Min(i, lineCount); j++)
                {
                    // k - начало текущей строки (индекс первого слова)
                    for (int k = j - 1; k < i; k++)
                    {
                        if (dp[k, j - 1] >= double.MaxValue)
                            continue;

                        // Текущая строка содержит слова [k, i-1]
                        int lineLength = GetLineLength(k, i - 1);
                        double deviation = lineLength - idealLength;
                        double cost = dp[k, j - 1] + deviation * deviation;

                        if (cost < dp[i, j])
                        {
                            dp[i, j] = cost;
                            splitPoint[i, j] = k;
                        }
                    }
                }
            }

            // Восстанавливаем оптимальное разбиение
            var result = new string[lineCount];
            int current = n;

            for (int line = lineCount; line > 0; line--)
            {
                int start = splitPoint[current, line];
                result[line - 1] = string.Join(" ", words, start, current - start);
                current = start;
            }

            return result;
        }
    }
}
