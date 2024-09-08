using DL.DTO;
using DL.Interfaces;
using FastEndpoints;
using FEAPI.Requests;

namespace FEAPI.Endpoints;

public class Customer : Endpoint<IdRequest, CustomerDTO?>
{
    readonly IMainService _mainService;

    public Customer(IMainService mainService)
    {
        _mainService = mainService;
    }
    public override void Configure()
    {
        Get("/customers/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(IdRequest request, CancellationToken ct)
    {
        await SendAsync(await _mainService.GetCustomerAsync(request.Id));
    }
}
