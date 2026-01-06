using Server.Application.Catalog.Customers;

namespace Server.Host.Controllers.Catalog;
public class CustomersController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Customers)]
    [OpenApiOperation("Search Customers using available filters.", "")]
    public Task<PaginationResponse<CustomerDto>> SearchAsync(SearchCustomersRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Customers)]
    [OpenApiOperation("Get Customer details.", "")]
    public Task<CustomerDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetCustomerRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Customers)]
    [OpenApiOperation("Get Customer details via dapper.", "")]
    public Task<CustomerDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetCustomerViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Customers)]
    [OpenApiOperation("Create a new Customer.", "")]
    public Task<Guid> CreateAsync(CreateCustomerRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPost("CreateCustomerUser")]
    [AllowAnonymous]
    [OpenApiOperation("Create a new Customer With User.", "")]
    [ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Create))]
    public Task<bool> CreateUserAsync(CreateCustomerWithUserRequest request)
    {
        request.Origin = GetOriginFromRequest();
        return Mediator.Send(request);
    }

    [HttpPost("CreateUserSmsAsync")]
    [AllowAnonymous]
    [OpenApiOperation("Create a new Customer Sms.", "")]
    [ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Create))]
    public Task<bool> CreateUserSmsAsync(CustomerSmsRequest request)
    {
        request.Origin = GetOriginFromRequest();
        return Mediator.Send(request);
    }

    [HttpPost("CheckUserSmsAsync")]
    [AllowAnonymous]
    [OpenApiOperation("Create a new Customer Sms.", "")]
    [ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Create))]
    public Task<bool> CheckUserSmsAsync(CheckSmsRequest request)
    {
        request.Origin = GetOriginFromRequest();
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Customers)]
    [OpenApiOperation("Update a Customer.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateCustomerRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpPut("status/{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Customers)]
    [OpenApiOperation("Update a Customer.", "")]
    public async Task<ActionResult<Guid>> UpdateStatusAsync(UpdateCustomerStatusRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }


    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Customers)]
    [OpenApiOperation("Delete a Customer.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteCustomerRequest(id));
    }

    private string GetOriginFromRequest() => $"{Request.Scheme}://{Request.Host.Value}{Request.PathBase.Value}";
}