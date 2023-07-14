using api_companies_list.Domain.Companies;
using Microsoft.EntityFrameworkCore;

namespace api_companies_list.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Company>()
            .Property(c => c.CNPJ).IsRequired();
        builder.Entity
        <Company>()
            .Property(u => u.Email).IsRequired();
        builder.Entity<Company>()
            .Property(c => c.RazaoSocial).IsRequired();
        builder.Entity<Company>()
            .Property(c => c.InscricaoMunicipal).IsRequired();
        builder.Entity<Company>()
            .Property(c => c.StatusEmpresa).IsRequired();
        builder.Entity<Company>()
            .Property(c => c.ResponsavelLegal).IsRequired();
        builder.Entity<Company>()
            .Property(c => c.Email).IsRequired();
        builder.Entity<Company>()
            .Property(c => c.TelefoneContato).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }
}
