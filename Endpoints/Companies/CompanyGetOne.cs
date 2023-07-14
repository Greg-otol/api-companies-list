using api_companies_list.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace api_companies_list.Endpoints.Companies;

public class CompanyGetOne
{
    public static string Template => "/companies/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
    {
        var company = context.Companies.Where(c => c.Id == id).FirstOrDefault();

        if (company == null)
            return Results.NotFound();

        return Results.Ok(company);
    }
}
