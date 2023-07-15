using api_companies_list.Endpoints.Companies;
using api_companies_list.Infra.Data;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

string connectionString = DotNetEnv.Env.GetString("DATABASE_URL");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.MapMethods(CompanyPost.Template, CompanyPost.Methods, CompanyPost.Handle);
app.MapMethods(CompanyPut.Template, CompanyPut.Methods, CompanyPut.Handle);
app.MapMethods(CompanyGetOne.Template, CompanyGetOne.Methods, CompanyGetOne.Handle);
app.MapMethods(CompaniesGetAll.Template, CompaniesGetAll.Methods, CompaniesGetAll.Handle);
app.MapMethods(CompanyRemove.Template, CompanyRemove.Methods, CompanyRemove.Handle);

app.Run();
