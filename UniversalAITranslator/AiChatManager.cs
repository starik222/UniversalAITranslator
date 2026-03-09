using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalAITranslator
{
    public class AiChatManager
    {
        public SystemChatMessage? SystemPrompt;
        public List<TypedChatMessage> History;
        public UserChatMessage? LastUserPrompt;
        public AiChatManager()
        {
            History = new List<TypedChatMessage>();
        }


        public void SetSystemPrompt(string prompt)
        {
            SystemPrompt = ChatMessage.CreateSystemMessage(prompt);
        }
        public void ResetSystemPrompt()
        {
            SystemPrompt = null;
        }
        public void SetSystemPrompt(SystemChatMessage prompt)
        {
            SystemPrompt = prompt;
        }

        public void SetUserPrompt(string prompt)
        {
            LastUserPrompt = ChatMessage.CreateUserMessage(prompt);
        }
        public void SetUserPrompt(UserChatMessage prompt)
        {
            LastUserPrompt = prompt;
        }

        public void AddAssistantResponse(string text)
        {
            if (LastUserPrompt == null)
                throw new Exception("Пользовательский промпт не может равняться NULL");
            if (string.IsNullOrEmpty(text))
                return;
            History.Add(new TypedChatMessage(LastUserPrompt, ChatMessageType.User));
            LastUserPrompt = null;
            History.Add(new TypedChatMessage(ChatMessage.CreateAssistantMessage(text), ChatMessageType.Assistant));
        }

        public void ClearHistory()
        {
            History.Clear();
        }

        public void ShrinkHistory(int keepLastPair)
        {
            if (History.Count <= keepLastPair * 2)
                return;
            History = History.Skip(History.Count - keepLastPair * 2).ToList();
        }

        public List<ChatMessage> GetRequest(bool withContext)
        {
            if (LastUserPrompt == null)
                throw new Exception("Пользовательский промпт не может равняться NULL");
            List<ChatMessage> result = new List<ChatMessage>();
            if (SystemPrompt != null)
                result.Add(SystemPrompt);
            if (withContext)
                result.AddRange(History.Select(x => x.Message));
            result.Add(LastUserPrompt);
            return result;
        }

        public List<ChatMessage> GetRequest(int includeLastNContextPair)
        {
            if (LastUserPrompt == null)
                throw new Exception("Пользовательский промпт не может равняться NULL");
            List<ChatMessage> result = new List<ChatMessage>();
            if (SystemPrompt != null)
                result.Add(SystemPrompt);
            if (History.Count <= includeLastNContextPair * 2)
                result.AddRange(History.Select(x => x.Message));
            else
            {
                result.AddRange(History.Skip(History.Count - includeLastNContextPair * 2).Select(x => x.Message));
            }
            result.Add(LastUserPrompt);
            return result;
        }


        public class TypedChatMessage
        {
            public ChatMessage Message { get; set; }
            public ChatMessageType MessageType { get; set; }

            public TypedChatMessage(ChatMessage message, ChatMessageType type)
            {
                Message = message;
                MessageType = type;
            }
        }

        public enum ChatMessageType
        {
            System,
            User,
            Assistant
        }
    }
}
