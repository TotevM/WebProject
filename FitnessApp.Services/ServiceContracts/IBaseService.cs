namespace FitnessApp.Services.ServiceContracts
{
    public interface IBaseService
    {
        bool IsGuidValid(string? id, ref Guid parsedGuid);
    }
}
