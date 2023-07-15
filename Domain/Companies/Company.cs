using api_companies_list.Infra.Data;

namespace api_companies_list.Domain.Companies;

public class Company : Entity
{
    public string Codigo { get; private set; }
    public string CNPJ { get; private set; }
    public string RazaoSocial { get; private set; }
    public string InscricaoMunicipal { get; private set; }
    public int StatusEmpresa { get; private set; }
    public string ResponsavelLegal { get; private set; }
    public string Email { get; private set; }
    public string TelefoneContato { get; private set; }

    private Company() { }

    public static Company CreateNew(ApplicationDbContext context, string cnpj, string razaoSocial, string inscricaoMunicipal, int statusEmpresa, string responsavelLegal, string email, string telefoneContato)
    {
        string lastCode = context.Companies
            .OrderByDescending(c => c.Codigo)
            .Select(c => c.Codigo)
            .FirstOrDefault() ?? string.Empty;

        string newCode = GenerateNextCode(lastCode);

        var company = new Company
        {
            Codigo = newCode,
            CNPJ = cnpj,
            RazaoSocial = razaoSocial,
            InscricaoMunicipal = inscricaoMunicipal,
            StatusEmpresa = statusEmpresa,
            ResponsavelLegal = responsavelLegal,
            Email = email,
            TelefoneContato = telefoneContato,
            DataInclusao = DateTime.Now
        };

        return company;
    }

    public void EditInfo(string cnpj, string razaoSocial, string inscricaoMunicipal, int statusEmpresa, string responsavelLegal, string email, string telefoneContato)
    {
        CNPJ = cnpj;
        RazaoSocial = razaoSocial;
        InscricaoMunicipal = inscricaoMunicipal;
        StatusEmpresa = statusEmpresa;
        ResponsavelLegal = responsavelLegal;
        Email = email;
        TelefoneContato = telefoneContato;
    }

    private static string GenerateNextCode(string lastCode)
    {
        if (string.IsNullOrEmpty(lastCode))
            return "0001";

        int lastNumber = int.Parse(lastCode);
        int nextNumber = lastNumber + 1;
        return nextNumber.ToString("D4");
    }
}
