using api_companies_list.Domain.Companies;
using api_companies_list.Infra.Data;

namespace api_companies_list.Endpoints.Companies;

public class CompanyPost
{
    public static string Template => "/companies";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(CompanyRequest companyRequest, ApplicationDbContext context)
    {
        var company = Company.CreateNew
        (
            context,
            companyRequest.CNPJ,
            companyRequest.RazaoSocial,
            companyRequest.InscricaoMunicipal,
            companyRequest.StatusEmpresa,
            companyRequest.ResponsavelLegal,
            companyRequest.Email,
            companyRequest.TelefoneContato
        );

        await context.Companies.AddAsync(company);
        await context.SaveChangesAsync();

        return Results.Created($"/companies/{company.Id}", company.Id);
    }
}
