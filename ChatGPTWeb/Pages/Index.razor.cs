using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System.Reflection;
using System.Text.RegularExpressions;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;

namespace ChatGPTWeb.Pages
{
    public partial class Index
    {
        [Inject]
        public IConfiguration _configuration { get; set; }
        private int maxAllowedFiles = int.MaxValue;
        private long maxFileSize = long.MaxValue;
        string Organization = "";
        string ApiKey = "";
        string promptHeader = "Please summarize key points as as Minutes of Meeting as bullets with title as 'Minutes of meeting' and Actions items seperately after Minutes of Meetings in a tabular format in HTML and titles in heading tag (h2). :\n";
        string response = "";

        public string? PlainText { get; set; }

        protected override void OnInitialized()
        {
            Organization = _configuration["OpenAIServiceOptions:Organization"] ?? "";
            ApiKey = _configuration["OpenAIServiceOptions:ApiKey"] ?? "";
        }

        private async Task OnInputFile(InputFileChangeEventArgs e)
        {
            using var content = new MultipartFormDataContent();
            foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
            {
                var fileContent = new StreamContent(file.OpenReadStream(maxFileSize));
                string vttContent = await fileContent.ReadAsStringAsync();

                string plainText = Regex.Replace(vttContent, @"<[^>]+>", "");
                plainText = Regex.Replace(plainText, @"\s+", " ").Trim();
                string pattern = "(WEBVTT [0-9:]{3,4}| [0-9:]{3,4})[ ->]{3,}";
                string replacement = string.Empty;

                Regex rgx = new Regex(pattern);
                PlainText = rgx.Replace(plainText, replacement);
                // PlainText = await File.ReadAllTextAsync(plainText);

                // await JSRuntime.InvokeAsync<object>("saveFile", "index.txt", PlainText);
                // await CallService();
            }
        }

        public async Task CallService()
        {
            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = ApiKey,
                Organization = Organization
            });
            var completionResult =
            await openAiService.Completions
            .CreateCompletion(new CompletionCreateRequest()
            {
                //Prompt = "Please summarize key points as as Minutes of Meeting as bullets with title as 'Minutes of meeting' and Actions items seperately after Minutes of Meetings in a tabular format in HTML and titles in heading tag (h2). :\n" + @Regex.Replace(prompt, "<.*?>", String.Empty),
                Prompt = promptHeader + @Regex.Replace(PlainText, "<.*?>", String.Empty),
                MaxTokens = 4000
            }, Models.TextDavinciV3);
            if (completionResult.Successful)
            {
                response = completionResult.Choices.FirstOrDefault()?.Text ?? "";
            }
            else
            {
                if (completionResult.Error == null)
                {
                    response = "Unknown Error";
                }
                response =
                $"{completionResult.Error?.Code}: {completionResult.Error?.Message}";
            }
        }
    }
}
