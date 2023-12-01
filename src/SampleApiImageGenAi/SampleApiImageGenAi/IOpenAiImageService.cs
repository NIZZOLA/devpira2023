
namespace SampleApiImageGenAi;

public interface IOpenAiImageService
{
    Task<string> GenerateImageFromAi(string description);
}