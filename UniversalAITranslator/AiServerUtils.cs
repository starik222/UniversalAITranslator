using OpenAI;
using OpenAI.Models;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalAITranslator
{
    public static class AiServerUtils
    {
        public static async Task<List<string>> GetModelList(string endpoint = "http://localhost:1234/v1", string apiKey = "lm-studio")
        {
            try
            {
                ApiKeyCredential credential = new ApiKeyCredential(apiKey);
                OpenAIClientOptions options = new OpenAIClientOptions();
                options.Endpoint = new Uri(endpoint);
                OpenAIModelClient client = new OpenAIModelClient(credential, options);
                var models = await client.GetModelsAsync();
                return models.Value.Select(a => a.Id).Order().ToList();
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }
    }
}
