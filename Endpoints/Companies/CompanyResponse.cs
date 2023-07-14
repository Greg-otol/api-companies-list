namespace api_companies_list.Endpoints.Companies;

public record CompanyResponse
(
    Guid Id,
    string Codigo,
    string RazaoSocial,
    string CNPJ,
    string InscricaoMunicipal,
    string ResponsavelLegal,
    string Email,
    string TelefoneContato,
    int StatusEmpresa,
    DateTime DataInclusao
);
