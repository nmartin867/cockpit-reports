using ServerReports.Core.Interfaces.IServices;

namespace ServerReports.Api.Routes;

public static class Exports
{
    public static IEndpointRouteBuilder MapExportsApi(this IEndpointRouteBuilder routes)
    {
        var exports = routes.MapGroup("/api/exports").DisableAntiforgery();
       
       exports.MapGet("/", GetExports);
       exports.MapPost("/", HandleUpload);
       
       return routes;
    }

    private static async Task<IResult> GetExports(IExportService exportService)
    {
        return Results.Ok();
    }
    
    private static async Task<IResult> HandleUpload(IExportService exportService, IFormFile csvFile)
    {
        return Results.Ok();
    }
}