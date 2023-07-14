using api_companies_list.Infra.Data;

namespace api_companies_list.Endpoints.Companies;

public class CompaniesGetAll
{
    public static string Template => "/companies";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var companies = context.Companies.OrderBy(c => c.RazaoSocial).ToList();

        var results = companies.Select(c => new CompanyResponse
        (
            c.Id, c.Codigo,
            c.RazaoSocial,
            c.CNPJ,
            c.InscricaoMunicipal,
            c.ResponsavelLegal,
            c.Email,
            c.TelefoneContato,
            c.StatusEmpresa,
            c.DataInclusao
        ));

        return Results.Ok(results);
    }
}
