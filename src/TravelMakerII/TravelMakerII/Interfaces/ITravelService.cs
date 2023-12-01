using TravelMakerII.Contracts;
using TravelMakerII.Models;

namespace TravelMakerII.Interfaces
{
    public interface ITravelService
    {
        List<DestinationModel> GetItinerary(ItineraryRequestModel request);
        PlaceInfomation GetPlaceInformation(PlaceInformationRequestModel request);
    }
}