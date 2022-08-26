using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoEntidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.MapeamentoViewModels;
using Entra21.CSharp.ClinicaVeterinaria.Servico.Servicos;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Registrar todas as injeções de dependencia
builder.Services.AddScoped<IRacaRepositorio, RacaRepositorio>();
builder.Services.AddScoped<IRacaServico, RacaServico>();
builder.Services.AddScoped<IVeterinarioServico, VeterinarioServico>();
builder.Services.AddScoped<IVeterinarioRepositorio, VeterinarioRepositorio>();
builder.Services.AddScoped<IResponsavelServico, ResponsavelServico>();
builder.Services.AddScoped<IResponsavelRepositorio, ResponsavelRepositorio>();
builder.Services.AddScoped<IResponsavelMapeamentoEntidade, ResponsavelMapeamentoEntidade>();
builder.Services.AddScoped<IVeterinarioMapeamentoEntidade, VeterinarioMapeamentoEntidade>();
builder.Services.AddScoped<IPetMapeamentoEntidade, PetMapeamentoEntidade>();
builder.Services.AddScoped<IPetRespositorio, PetRepositorio>();
builder.Services.AddScoped<IPetServico, PetServico>();
builder.Services.AddScoped<IResponsavelViewModelMapeamentoViewModels, ResponsavelViewModelMapeamentoViewModels>();

builder.Services.AddScoped<IResponsavelContatoService, ResponsavelContatoService>();
builder.Services.AddScoped<IResponsavelContatoMapeamentoEntidade, ResponsavelContatoMapeamentoEntidade>();
builder.Services.AddScoped<IResponsavelContatoMapeamentoViewModel, ResponsavelContatoMapeamentoViewModel>();
builder.Services.AddScoped<IResponsavelContatoRepository, ResponsavelContatoRepository>();

builder.Services.AddDbContext<ClinicaVeterinariaContexto>(options =>
    options.UseSqlServer(
            builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddControllers().AddNewtonsoftJson(
    x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

var app = builder.Build();

using (var scopo = app.Services.CreateScope())
{
    var contexto = scopo.ServiceProvider
        .GetService<ClinicaVeterinariaContexto>();
    contexto.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.UseEndpoints(endpoint =>
{
    
    endpoint.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
