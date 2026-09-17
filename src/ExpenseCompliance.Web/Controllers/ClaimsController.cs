using ExpenseCompliance.Application.Claims;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseCompliance.Web.Controllers;

public sealed class ClaimsController(IClaimQueries queries) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var claims = await queries.ListAsync(cancellationToken);
        return View(claims);
    }

    public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
    {
        var claim = await queries.GetDetailsAsync(id, cancellationToken);
        return claim is null ? NotFound() : View(claim);
    }
}
