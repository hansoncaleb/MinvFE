using DL.DTO;
using DL.Interfaces;
using FastEndpoints;

namespace FEAPI.Endpoints;

public class AllCustomers : EndpointWithoutRequest<IEnumerable<CustomerDTO>?>
{
    readonly IMainService _mainService;

    public AllCustomers(IMainService mainService)
    {
        _mainService = mainService;
    }
    public override void Configure()
    {
        Get("/customers/all");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(await _mainService.GetCustomersAsync());
    }
}