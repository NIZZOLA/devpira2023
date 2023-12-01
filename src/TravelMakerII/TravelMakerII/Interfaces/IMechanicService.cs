using TravelMakerII.Models;

namespace TravelMakerII.Interfaces;
public interface IMechanicService
{
    List<MechanicSolutionModel> GetMechanic(ProblemsRequestModel request);
}