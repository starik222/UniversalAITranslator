using Newtonsoft.Json;
using OpenAI;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace UniversalAITranslator
{
    public class AiTranslator
    {
        public ModelConfiguration Configuration { get; set; }
        public SystemChatMessage? SystemPrompt { get; set; } = null;
        public ChatCompletionOptions ChatOptions { get; set; }
        public bool UseChatOptions { get; set; } = false;
        private AiChatManager chatManager;

        public AiChatManager ChatManager => chatManager;

        private ChatClient chat;
        public AiTranslator() { }
        public AiTranslator(ModelConfiguration config)
        {
            Configuration = config;
            chatManager = new AiChatManager();
            ApiKeyCredential credential = new ApiKeyCredential(config.ApiKey);
            OpenAIClientOptions options = new OpenAIClientOptions();
            options.Endpoint = new Uri(config.Endpoint);
            ChatOptions = new ChatCompletionOptions();
            if (config.Temperature != 0)
            {
                ChatOptions.Temperature = config.Temperature;
                UseChatOptions = true;
            }
            if (config.MaxTokens != -1)
            {
                ChatOptions.MaxOutputTokenCount = config.MaxTokens;
                UseChatOptions = true;
            }
            if (config.Seed != -1)
            {
#pragma warning disable OPENAI001 // Тип предназначен только для оценки и может быть изменен или удален в будущих обновлениях. Чтобы продолжить, скройте эту диагностику.
                ChatOptions.Seed = config.Seed;
#pragma warning restore OPENAI001 // Тип предназначен только для оценки и может быть изменен или удален в будущих обновлениях. Чтобы продолжить, скройте эту диагностику.
                UseChatOptions = true;
            }
            options.NetworkTimeout = TimeSpan.FromMinutes(300);
            chat = new ChatClient(config.ModelName, credential, options);
        }

        /// <summary>
        /// Установка системного промпта
        /// </summary>
        /// <param name="prompt">Текст промпта</param>
        public void SetSystemPrompt(string prompt)
        {
            if (prompt == null)
                SystemPrompt = null;
            else
            {
                SystemPrompt = new SystemChatMessage(prompt);
            }
        }

        private List<ChatMessage> GetRequest(bool withContext)
        {
            if (withContext)
            {
                if (Configuration.ShrinkContext)
                    return chatManager.GetRequest(Configuration.KeepLastNRequestInContext);
                else
                    return chatManager.GetRequest(true);
            }
            else
                return chatManager.GetRequest(false);
        }


        private string LoadSystemPromptFile(string fileName)
        {
            return File.ReadAllText("./Prompts/" + fileName, Encoding.UTF8);
        }

        private string LoadDefinedPromptFile(SystemPromptFile promptFile)
        {
            return LoadSystemPromptFile(promptFile.ToString() + ".txt");
        }
        /// <summary>
        ///[НЕ РЕКОМЕНДУЕТСЯ]  Установка системного промпта для перевода текста с одного языка на другой.
        /// </summary>
        /// <param name="fromLang"></param>
        /// <param name="toLang"></param>
        public void SetDefaultSystemPrompt(string fromLang = "Japanese", string toLang = "Russian")
        {
            SystemPrompt = new SystemChatMessage($"You are a professional translator from {fromLang} to {toLang}. Don't include any explanations; you should only output the translation. Try to maintain a consistent translation style between queries. When translating, use an informal style. Maintain context between sentences within a single query.");
        }

        private void SetTaggedSystemPrompt(List<StructuredTranslationData.NamesItem> translation, SystemPromptFile fileWithNames)
        {
            string s = "";
            string promptData = LoadDefinedPromptFile(fileWithNames);
            string[] lines = promptData.Split('\n');
            int textIndex = 10;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("{0}"))
                {
                    try
                    {
                        textIndex = Convert.ToInt32(lines[i - 1][0].ToString());
                        break;
                    }
                    catch
                    {
                        //Попытка обработки второй строки
                    }
                    try
                    {
                        textIndex = Convert.ToInt32(lines[i - 2][0].ToString());
                        break;
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            if (translation.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{(textIndex+1)}. Используй следующий перевод этих имен и названий:");
                foreach (var item in translation)
                {
                    sb.AppendLine($"* {item.Original} –> {item.Translate}");
                }

                //s = string.Format("Ты – специализированный помощник по переводу визуальных новелл с японского на русский язык.\r\nТвоя задача — переводить предоставленные фрагменты текста, сохранять литературный стиль,\r\nконтекст между предложениями и учитывать дополнительные метки теги, которые\r\nуказывают тип строки.\r\n\r\n**Формат входных данных**\r\n\r\nКаждая строка начинается с тега в квадратных скобках, после чего следует оригинальный\r\nяпонский текст. Возможные теги:\r\n\r\n* **[Имя, пол]** – реплика персонажа.\r\n  *Имя* – произвольное имя (может содержать пробелы).  \r\n  *пол* – «мужской» или «женский».  \r\n\r\n* **[Описание]** – описание действий/сцены, не является прямой речью.\r\n\r\n* **[Выбор]** – вариант выбора игрока. Переводится независимо от контекста\r\n(не учитывается предшествующий и последующий текст).\r\n\r\nТег **никогда** не выводится в результате — он нужен только для твоего понимания.\r\n\r\n**Требования к выводу**\r\n\r\n1. Выводи **только перевод на русский язык**, без каких-либо пояснений,\r\n   комментариев, метаданных или тегов.\r\n2. **Обязательно сохраняй порядок строк**, как они поданы во входных данных. **Не объединяй строки в переводе** и не делай дополнительных переносов.\r\n3. Для реплик ([Имя, пол]) переводишь только содержание реплики,\r\n   не включая имя, пол и скобки.\r\n4. Для описаний ([Описание]) переводишь весь текст как повествование.\r\n5. Для вариантов выбора ([Выбор]) переводишь независимо от контекста;\r\n   можно игнорировать связь с предыдущими/следующими строками.\r\n6. При последовательных репликах и описаниях учитывай уже переведённый\r\n   материал, чтобы сохранять сюжетную целостность и характер персонажей.\r\n7. Сохраняй литературный стиль, эмоциональные оттенки и особенности диалогов.\r\n   Если в оригинале реплика начинается с «「」», в русском переводе её обычно оформляют как «— …».\r\n8. Используй следующий перевод этих имен и названий:\r\n{0}\r\n\r\n**Пример**\r\n\r\nВход:\r\n```\r\n[Иван, мужской] 「うん、でも明日は晴れるらしいよ。」\r\n[Описание] 雨が降っている窓の外で、彼は考え事をしていた。\r\n[Выбор] 外に出て\r\n[Выбор] 外に出ないで\r\n```\r\n\r\nОжидаемый вывод:\r\n```\r\n— Да, но, кажется, завтра будет солнце.\r\nЗа окном шел дождь, и он задумался.\r\nВыйти на улицу\r\nНе выходить на улицу\r\n```\r\n\r\nСледуй этим инструкциям для каждого полученного от пользователя фрагмента текста.", sb.ToString());
                s = promptData.Replace("{0}", sb.ToString());
            }
            else
            {
                s = promptData.Replace("{0}", "");
            }

            SystemPrompt = new SystemChatMessage(s);
        }
        /// <summary>
        /// Выполнение запроса с текущим системным промптом. Предпологается, что в системном промпте установлен промпт для перевода текста.
        /// </summary>
        /// <param name="text">Текст запроса</param>
        /// <returns></returns>
        public async Task<string> TranslateText(string text, bool withContext)
        {
            if (SystemPrompt != null)
                chatManager.SetSystemPrompt(SystemPrompt);
            else
                chatManager.ResetSystemPrompt();
            chatManager.SetUserPrompt(text);
            ChatCompletion result;
            if (UseChatOptions)
                result = await chat.CompleteChatAsync(chatManager.GetRequest(withContext), ChatOptions);
            else
                result = await chat.CompleteChatAsync(chatManager.GetRequest(withContext));
            if (result.FinishReason != ChatFinishReason.Stop)
            {
                return "Server return: " + result.FinishReason.ToString();
            }
            string responseWithoutThinking = RemoveThinking(result.Content[0].Text);
            if (withContext)
                chatManager.AddAssistantResponse(responseWithoutThinking);
            return responseWithoutThinking;
        }
        /// <summary>
        /// Перевод диалогового текста на основе предустановленного системного промпта. 
        /// </summary>
        /// <param name="textData">Массив данных для перевода, содержащий как текст, так и имена персонажей, их пол.
        /// Также возможно указать, как переводить указанные слова.</param>
        /// <param name="withIndexes">Использовать ли дополнительную индексацию строк. Уменьшает шанс того, что ИИ вернет неверное количество строк,
        /// но увеличивает количество потребляемых токенов.</param>
        /// <param name="eroMode">Использовать ли системный промпт, направленный на перевод эротического контанта.</param>
        /// <returns></returns>
        public async Task<string[]> TranslateStructuredText(StructuredTranslationData textData, bool withIndexes, bool eroMode, bool withContext)
        {
            //UseChatOptions = true;
            //List<ChatMessage> messages = new List<ChatMessage>();
            if (eroMode)
            {
                if (withIndexes)
                    SetTaggedSystemPrompt(textData.Names, SystemPromptFile.EroStructuredTaggedIndexedWithNames);
                else
                    SetTaggedSystemPrompt(textData.Names, SystemPromptFile.EroStructuredTaggedNonIndexedWithNames);
            }
            else
            {
                if (withIndexes)
                    SetTaggedSystemPrompt(textData.Names, SystemPromptFile.StructuredTaggedIndexedWithNames);
                else
                    SetTaggedSystemPrompt(textData.Names, SystemPromptFile.StructuredTaggedNonIndexedWithNames);
            }
            if (SystemPrompt != null)
                chatManager.SetSystemPrompt(SystemPrompt);
            else
                chatManager.ResetSystemPrompt();
            StringBuilder sb = new StringBuilder();
            if (withIndexes)
            {
                int index = 1;
                foreach (var item in textData.TextData)
                {
                    if (item.Type == StructuredTranslationData.TextType.FirstPerson)
                    {
                        sb.AppendLine($"[{index}, {item.Name}, {item.Gender}] {item.Text}");
                    }
                    else if (item.Type == StructuredTranslationData.TextType.Description)
                    {
                        sb.AppendLine($"[{index}, Описание] {item.Text}");
                    }
                    else if (item.Type == StructuredTranslationData.TextType.Selection)
                    {
                        sb.AppendLine($"[{index}, Выбор] {item.Text}");
                    }
                    index++;
                }
            }
            else
            {
                foreach (var item in textData.TextData)
                {
                    if (item.Type == StructuredTranslationData.TextType.FirstPerson)
                    {
                        sb.AppendLine($"[{item.Name}, {item.Gender}] {item.Text}");
                    }
                    else if (item.Type == StructuredTranslationData.TextType.Description)
                    {
                        sb.AppendLine($"[Описание] {item.Text}");
                    }
                    else if (item.Type == StructuredTranslationData.TextType.Selection)
                    {
                        sb.AppendLine($"[Выбор] {item.Text}");
                    }
                }
            }
            chatManager.SetUserPrompt(sb.ToString());
            ChatCompletion result;
            if (eroMode)
            {
#pragma warning disable SCME0001 // Тип предназначен только для оценки и может быть изменен или удален в будущих обновлениях. Чтобы продолжить, скройте эту диагностику.
                ChatOptions.Patch.Set("$.safetySettings"u8, "[\r\n            {\r\n                \"category\": \"HARM_CATEGORY_SEXUALLY_EXPLICIT\",\r\n                \"threshold\": \"BLOCK_NONE\"\r\n            },\r\n            {\r\n                \"category\": \"HARM_CATEGORY_HATE_SPEECH\",\r\n                \"threshold\": \"BLOCK_NONE\"\r\n            },\r\n            {\r\n                \"category\": \"HARM_CATEGORY_HARASSMENT\",\r\n                \"threshold\": \"BLOCK_NONE\"\r\n            },\r\n            {\r\n                \"category\": \"HARM_CATEGORY_DANGEROUS_CONTENT\",\r\n                \"threshold\": \"BLOCK_NONE\"\r\n            }\r\n        ]");
#pragma warning restore SCME0001 // Тип предназначен только для оценки и может быть изменен или удален в будущих обновлениях. Чтобы продолжить, скройте эту диагностику.
                UseChatOptions = true;
            }
            try
            {
                if (UseChatOptions)
                {
                    result = await chat.CompleteChatAsync(GetRequest(withContext), ChatOptions);
                }
                else
                    result = await chat.CompleteChatAsync(GetRequest(withContext));
                //if (UseChatOptions)
                //{
                //    //Newtonsoft.Json.Schema.JsonSchemaGenerator a = new JsonSchemaGenerator();
                //    //var s = a.Generate(typeof(StructuredTranslationResponse));
                //    string desc = "translated_items содержит массив переведенных строк. Каждая переведенная строка является элементом массива.";
                //    ChatOptions.ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat("translation_result", GetStructuredFormat(), null, true);
                //    result = await chat.CompleteChatAsync(messages, ChatOptions);
                //}
                //else
                //    result = await chat.CompleteChatAsync(messages);
            }
            catch (Exception ex)
            {
                return null;
            }
            if (result.FinishReason != ChatFinishReason.Stop)
            {
                return null;
            }
            try
            {
                if (string.IsNullOrEmpty(result.Content[0].Text))
                    return null;
                string responseWithoutThinking = RemoveThinking(result.Content[0].Text);
                //if (withContext)
                //    chatManager.AddAssistantResponse(responseWithoutThinking);
                var lines = responseWithoutThinking.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (textData.TextData.Count != lines.Length)
                {
                    var textWithTags = lines.Select(a => SplitOnTagsAndText(a)).ToArray();
                    int maxLines = Math.Max(textData.TextData.Count, lines.Length);
                    Form_FixTranslation fixTranslation = new Form_FixTranslation();
                    fixTranslation.OriginalCount = textData.TextData.Count;
                    fixTranslation.TranslatedCount = lines.Length;
                    fixTranslation.dataGridViewData.Rows.Add(maxLines);
                    for (int i = 0; i < textData.TextData.Count; i++)
                    {
                        fixTranslation.dataGridViewData["OrigName", i].Value = textData.TextData[i].Name;
                        fixTranslation.dataGridViewData["OrigText", i].Value = textData.TextData[i].Text;
                    }
                    for (int i = 0; i < textWithTags.Length; i++)
                    {
                        fixTranslation.dataGridViewData["TransName", i].Value = textWithTags[i].tag;
                        fixTranslation.dataGridViewData["TransText", i].Value = textWithTags[i].text;
                    }
                    if (fixTranslation.ShowDialog() != DialogResult.OK)
                    {
                        if (fixTranslation != null && !fixTranslation.IsDisposed)
                            fixTranslation.Close();
                        return lines.Select(a => RemoveTags(a)).ToArray();
                    }
                    else
                    {
                        var res = fixTranslation.GetTranslation();
                        if (withContext)
                            chatManager.AddAssistantResponse(string.Join("\r\n", res));
                        fixTranslation.Close();
                        return res;
                    }
                }
                else
                {
                    if (withContext)
                        chatManager.AddAssistantResponse(responseWithoutThinking);
                    return lines.Select(a => RemoveTags(a)).ToArray();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Перевод диалогового текста без учета имен имен и пола.
        /// </summary>
        /// <param name="textData">Массив данных для перевода, указанные имена и пол игнорируются, так как используется только текст.
        /// Также возможно указать, как переводить указанные слова.</param>
        /// <returns></returns>
        public async Task<string[]> TranslateNonStructuredText(StructuredTranslationData textData, bool withContext)
        {
            //UseChatOptions = true;
            //List<ChatMessage> messages = new List<ChatMessage>();
            SetTaggedSystemPrompt(textData.Names, SystemPromptFile.StructuredNonTaggedWithNames);
            if (SystemPrompt != null)
                chatManager.SetSystemPrompt(SystemPrompt);
            else
                chatManager.ResetSystemPrompt();
            StringBuilder sb = new StringBuilder();
            foreach (var item in textData.TextData.Select(a => a.Text))
            {
                sb.AppendLine(item);
            }
            chatManager.SetUserPrompt(sb.ToString());
            ChatCompletion result;
            try
            {
                if (UseChatOptions)
                {
                    result = await chat.CompleteChatAsync(GetRequest(withContext), ChatOptions);
                }
                else
                    result = await chat.CompleteChatAsync(GetRequest(withContext));
                //if (UseChatOptions)
                //{
                //    //Newtonsoft.Json.Schema.JsonSchemaGenerator a = new JsonSchemaGenerator();
                //    //var s = a.Generate(typeof(StructuredTranslationResponse));
                //    string desc = "translated_items содержит массив переведенных строк. Каждая переведенная строка является элементом массива.";
                //    ChatOptions.ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat("translation_result", GetStructuredFormat(), null, true);
                //    result = await chat.CompleteChatAsync(messages, ChatOptions);
                //}
                //else
                //    result = await chat.CompleteChatAsync(messages);
            }
            catch (Exception ex)
            {
                return null;
            }
            if (result.FinishReason != ChatFinishReason.Stop)
            {
                return null;
            }
            try
            {
                //return JsonConvert.DeserializeObject<StructuredTranslationResponse>(result.Content[0].Text);
                string responseWithoutThinking = RemoveThinking(result.Content[0].Text);
                if (withContext)
                    chatManager.AddAssistantResponse(responseWithoutThinking);
                return responseWithoutThinking.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(string errText, List<TypedTranslationData>? data)> TranslateTypedText(List<TypedTranslationData> data, bool withContext)
        {
            //List<ChatMessage> messages = new List<ChatMessage>();
            if (SystemPrompt != null)
                chatManager.SetSystemPrompt(SystemPrompt);
            else
                chatManager.ResetSystemPrompt();
            ChatOptions.ResponseFormat = ChatResponseFormat.CreateJsonObjectFormat();
            string userMessage = JsonConvert.SerializeObject(data.Where(a => a.Enabled).Select(a => a.CreateTypedRequestItem()).ToArray());
            chatManager.SetUserPrompt(userMessage);
            ChatCompletion result;
            try
            {
                result = await chat.CompleteChatAsync(GetRequest(withContext), ChatOptions);
                if (result.FinishReason != ChatFinishReason.Stop)
                {
                    return ("Сервер вернул причину ошибки перевода: " + result.FinishReason.ToString(), null);
                }
                string rawText = RemoveThinking(result.Content[0].Text);
                if (withContext)
                    chatManager.AddAssistantResponse(rawText);
                var typedResult = JsonConvert.DeserializeObject<List<TypedTranslationRequestItem>>(rawText);
                if (typedResult == null)
                    return ("Возникла ошибка при десериализации полученного перевода", null);
                return ("", typedResult.Select(a => a.CreateTypedItem()).ToList());
            }
            catch (Exception ex)
            {
                return (ex.Message, null);
            }
        }


        public async Task<(string errText, List<ImageTranslationData>? data)> TranslateImage(string imagePath)
        {
            //Нет смысла использовать историю запросов...
            List<ChatMessage> messages = new List<ChatMessage>();
            if (SystemPrompt != null)
                messages.Add(SystemPrompt);

            BinaryData bd = new BinaryData(await File.ReadAllBytesAsync(imagePath));
            string contentType = GetContentTypeFromExtention(Path.GetExtension(imagePath));
            ChatMessageContentPart partImage = ChatMessageContentPart.CreateImagePart(bd, contentType);

            ChatOptions.ResponseFormat = ChatResponseFormat.CreateJsonObjectFormat();
            messages.Add(ChatMessage.CreateUserMessage(partImage));
            ChatCompletion result;
            try
            {
                result = await chat.CompleteChatAsync(messages, ChatOptions);
                if (result.FinishReason != ChatFinishReason.Stop)
                {
                    return ("Сервер вернул причину ошибки перевода: " + result.FinishReason.ToString(), null);
                }
                string rawText = RemoveThinking(result.Content[0].Text).Replace("```", "");
                var typedResult = JsonConvert.DeserializeObject<List<ImageTranslationData>>(rawText);
                if (typedResult == null)
                    return ("Возникла ошибка при десериализации полученного перевода", null);
                return ("", typedResult);
            }
            catch (Exception ex)
            {
                return (ex.Message, null);
            }
        }

        private string RemoveThinking(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;
            string pattern = @"<think>.*?(?:</think>|$)";
            string result = Regex.Replace(text, pattern, string.Empty, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return FixPotentialBadChars(result.Trim(['\n', '\r']).Trim());

            //if (text.Trim().StartsWith("<think>"))
            //{
            //    int indexEndThink = text.IndexOf("</think>");
            //    if (indexEndThink < 0)
            //        return FixPotentialBadChars(text);
            //    return FixPotentialBadChars(text.Substring(indexEndThink + 8));
            //}
            //return FixPotentialBadChars(text);
        }

        private string FixPotentialBadChars(string text)
        {
            text = text.Replace('–', '-');
            text = text.Replace('—', '-');
            text = text.Replace('—', '-');
            return text;
        }

        private string RemoveTags(string text)
        {
            if (text.Trim().StartsWith("["))
            {
                int indexEndThink = text.IndexOf("]");
                if (indexEndThink < 0)
                    return text;
                return text.Substring(indexEndThink + 1);
            }
            return text;
        }

        private (string tag, string text) SplitOnTagsAndText(string text)
        {
            if (text.Trim().StartsWith("["))
            {
                int indexEndThink = text.IndexOf("]");
                if (indexEndThink < 0)
                    return ("", text);
                return (text.Substring(0, indexEndThink + 1), text.Substring(indexEndThink + 1));
            }
            return ("", text);
        }

        private string GetContentTypeFromExtention(string ext)
        {
            switch (ext.ToLower())
            {
                case ".jpg":
                    {
                        return "image/jpeg";
                    }
                case ".bmp":
                    {
                        return "image/bmp";
                    }
                case ".png":
                    {
                        return "image/png";
                    }
                case ".gif":
                    {
                        return "image/gif";
                    }
                case ".webp":
                    {
                        return "image/webp";
                    }
                default:
                    {
                        return "application/octet-stream";
                    }
            }
        }


        public enum SystemPromptFile
        {
            StructuredNonTaggedWithNames,
            StructuredNonTaggedWithoutNames,
            StructuredTaggedIndexedWithNames,
            StructuredTaggedNonIndexedWithNames,
            EroStructuredTaggedIndexedWithNames,
            EroStructuredTaggedNonIndexedWithNames,
        }
    }
}
