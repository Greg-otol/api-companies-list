using api_companies_list.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace api_companies_list.Endpoints.Companies;

public class CompanyPut
{
    public static string Template => "/companies/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid id, CompanyRequest companyRequest, ApplicationDbContext context)
    {
        var company = context.Companies.Where(c => c.Id == id).FirstOrDefault();

        if (company == null)
            return Results.NotFound();

        company.EditInfo
        (
          companyRequest.CNPJ,
          companyRequest.RazaoSocial,
          companyRequest.InscricaoMunicipal,
          companyRequest.StatusEmpresa,
          companyRequest.ResponsavelLegal,
          companyRequest.Email,
          companyRequest.TelefoneContato
        );

        await context.SaveChangesAsync();

        return Results.Ok(company.Id);
    }
}
