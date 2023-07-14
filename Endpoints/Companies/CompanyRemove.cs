using api_companies_list.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace api_companies_list.Endpoints.Companies;

public class CompanyRemove
{
    public static string Template => "/companies/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid id, ApplicationDbContext context)
    {
        var company = context.Companies.Where(c => c.Id == id).FirstOrDefault();

        if (company == null)
            return Results.NotFound();

        context.Remove(company);
        await context.SaveChangesAsync();

        return Results.Ok("Empresa removida com sucesso!");
    }
}
