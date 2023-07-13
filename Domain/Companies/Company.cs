namespace api_companies_list.Domain.Companies;

public class Company : Entity
{
    private static int codigoCounter = 1;
    public int Codigo { get; private set; }
    public string CNPJ { get; private set; }
    public string RazaoSocial { get; private set; }
    public string InscricaoMunicipal { get; private set; }
    public int StatusEmpresa { get; private set; }
    public string ResponsavelLegal { get; private set; }
    public string Email { get; private set; }
    public string TelefoneContato { get; private set; }

    private Company() { }

    public Company(string cnpj, string razaoSocial, string inscricaoMunicipal, int statusEmpresa, string responsavelLegal, string email, string telefoneContato)
    {
        Codigo = ++codigoCounter;
        CNPJ = cnpj;
        RazaoSocial = razaoSocial;
        InscricaoMunicipal = inscricaoMunicipal;
        StatusEmpresa = statusEmpresa;
        ResponsavelLegal = responsavelLegal;
        Email = email;
        TelefoneContato = telefoneContato;
        DataInclusao = DateTime.Now;
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
}
