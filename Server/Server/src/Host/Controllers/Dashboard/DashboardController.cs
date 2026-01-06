using Server.Application.Dashboard;

namespace Server.Host.Controllers.Dashboard;
public class DashboardController : VersionedApiController
{
    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Dashboard)]
    [OpenApiOperation("Get statistics for the dashboard.", "")]
    public Task<StatsDto> GetAsync(string? id)
    {
        return Mediator.Send(new GetStatsRequest(id));
    }
}