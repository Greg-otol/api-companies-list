using api_companies_list.Endpoints.Companies;
using api_companies_list.Infra.Data;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

string connectionString = DotNetEnv.Env.GetString("DATABASE_URL");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration.GetConnectionString("ConnectionDb"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseCors(c =>
// {
//     c.AllowAnyHeader();
//     c.AllowAnyMethod();
//     c.AllowAnyOrigin();
// });

app.MapMethods(CompanyPost.Template, CompanyPost.Methods, CompanyPost.Handle);
app.MapMethods(CompanyPut.Template, CompanyPut.Methods, CompanyPut.Handle);
app.MapMethods(CompanyGetOne.Template, CompanyGetOne.Methods, CompanyGetOne.Handle);
app.MapMethods(CompaniesGetAll.Template, CompaniesGetAll.Methods, CompaniesGetAll.Handle);
app.MapMethods(CompanyRemove.Template, CompanyRemove.Methods, CompanyRemove.Handle);

app.Run();
