using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Options;
using System.Text.Json;
using TravelMakerII.Contracts;
using TravelMakerII.Interfaces;
using TravelMakerII.Models;

namespace TravelMakerII.Services;

public class TravelService : ITravelService
{
    private readonly AzureAICredentials _config;
    public TravelService(IOptions<AzureAICredentials> options)
    {
        _config = options.Value;
    }
    public List<DestinationModel> GetItinerary(ItineraryRequestModel request)
    {
        OpenAIClient client = new(new Uri(_config.Endpoint), new AzureKeyCredential(_config.Key));

        IList<ChatMessage> messages = new List<ChatMessage>();

        messages.Add(new ChatMessage(ChatRole.System, PromptConstants.ItineraryQuestion));
        string question = $"Destino {request.Name} {request.days} dias";

        messages.Add(new ChatMessage(ChatRole.User, question));

        var chatCompletionsOptions = new ChatCompletionsOptions(_config.DeploymentModel , messages);

        Response<ChatCompletions> response = client.GetChatCompletions(chatCompletionsOptions);

        Console.WriteLine(response.Value.Choices[0].Message.Content);
        var jsonResponse = JsonSerializer.Deserialize<List<DestinationModel>>(response.Value.Choices[0].Message.Content);
        return jsonResponse;
    }

    public PlaceInfomation GetPlaceInformation(PlaceInformationRequestModel request)
    {
        OpenAIClient client = new(new Uri(_config.Endpoint), new AzureKeyCredential(_config.Key));

        IList<ChatMessage> messages = new List<ChatMessage>();
        
        messages.Add(new ChatMessage(ChatRole.System, PromptConstants.PlacePrepareQuestion + PromptConstants.PlaceSampleResponse));
        string question = string.Format(PromptConstants.PlaceQuestion, request.PlaceName, request.GeoReference);

        messages.Add(new ChatMessage(ChatRole.User, question));

        var chatCompletionsOptions = new ChatCompletionsOptions(_config.DeploymentModel, messages);

        Response<ChatCompletions> response = client.GetChatCompletions(chatCompletionsOptions);

        Console.WriteLine(response.Value.Choices[0].Message.Content);
        var jsonResponse = JsonSerializer.Deserialize<PlaceInfomation>(response.Value.Choices[0].Message.Content);
        return jsonResponse;
    }
}
