using Server.Application.Identity.Roles;
using Server.Application.Identity.Users;

namespace Server.Application.Dashboard;

public class GetStatsRequest : IRequest<StatsDto>
{
    public string? Id { get; set; }

    public GetStatsRequest(string id) => Id = id;
}

public class GetStatsRequestHandler : IRequestHandler<GetStatsRequest, StatsDto>
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public GetStatsRequestHandler(IUserService userService, IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;
    }

    public async Task<StatsDto> Handle(GetStatsRequest request, CancellationToken cancellationToken)
    {
        var stats = new StatsDto
        {
            // TODO: Add LBYS entity counts after entity creation
            HastaCount = 0,
            BasvuruCount = 0,
            PersonelCount = 0,
            UserCount = await _userService.GetCountAsync(request.Id, cancellationToken),
            RoleCount = await _roleService.GetCountAsync(cancellationToken)
        };

        return stats;
    }
}
