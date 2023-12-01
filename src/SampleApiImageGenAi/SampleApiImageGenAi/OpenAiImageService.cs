using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Options;
using SampleApiImageGenAi.Models;

namespace SampleApiImageGenAi
{
    public class OpenAiImageService : IOpenAiImageService
    {
        private readonly AzureAICredentials _config;
        public OpenAiImageService(IOptions<AzureAICredentials> options)
        {
            _config = options.Value;
        }
        public async Task<string> GenerateImageFromAi(string description)
        {
            string endpoint = _config.Endpoint;
            string key = _config.Key;

            try
            {
                OpenAIClient client = new(new Uri(endpoint), new AzureKeyCredential(key));

                Response<ImageGenerations> imageGenerations = await client.GetImageGenerationsAsync(
                    new ImageGenerationOptions()
                    {
                        Prompt = description,
                        Size = ImageSize.Size1024x1024,
                    });

                // Image Generations responses provide URLs you can use to retrieve requested images
                Uri imageUri = imageGenerations.Value.Data[0].Url;

                // Print the image URI to console:
                return imageUri.AbsoluteUri.ToString();

            }
            catch (Exception error)
            {

                throw;
            }
        }
    }
}
