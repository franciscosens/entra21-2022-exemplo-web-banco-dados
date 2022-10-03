using Entra21.CSharp.ClinicaVeterinaria.Aplicacao.InjecoesDependencia;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.InjecoesDependencia;
using Entra21.CSharp.ClinicaVeterinaria.Servico.InjecoesDependencia;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Registrar todas as injeções de dependencia
builder.Services
    .AdicionarServicos()
    .AdicionarRepositorios()
    .AdicionarMapeamentoEntidades()
    .AdicionarMapeamentoViewModels()
    .AdicionarEntityFramework(builder.Configuration)
    .AdicionarNewtonsoftJson();

var app = builder.Build();

var supportedCultures = new[] { new CultureInfo("pt-BR") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

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
