namespace api_companies_list.Endpoints.Companies;

public record CompanyRequest
(
  string CNPJ,
  string RazaoSocial,
  string InscricaoMunicipal,
  int StatusEmpresa,
  string ResponsavelLegal,
  string Email,
  string TelefoneContato
);
