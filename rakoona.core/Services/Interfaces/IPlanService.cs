using rakoona.dtos.Response;

namespace rakoona.core.Services.Interfaces
{
    public interface IPlanService
    {
        Task<PlanResponse> GetFreePlan();
    }
}
