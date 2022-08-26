using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;

public enum UnidadeFederativa
{
    [Display(Name = "Acre")] Acre,
    [Display(Name = "Alagoas")] Alagoas,
    [Display(Name = "Amapá")] Amapá,
    [Display(Name = "Amazonas")] Amazonas,
    [Display(Name = "Bahia")] Bahia,
    [Display(Name = "Ceara")] Ceara,
    [Display(Name = "Distrito Federal")] DistritoFederal,
    [Display(Name = "Espírito Santo")] EspiritoSanto,
    [Display(Name = "Goiás")] Goias,
    [Display(Name = "Maranhão")] Maranhao,
    [Display(Name = "Mato Grosso")] MatoGrosso,
    [Display(Name = "Mato Grosso do Sul")] MatoGrossoDoSul,
    [Display(Name = "Minas Gerais")] MinasGerais,
    [Display(Name = "Pará")] Para,
    [Display(Name = "Paraíba")] Paraiba,
    [Display(Name = "Paraná")] Parana,
    [Display(Name = "Pernambuco")] Pernambuco,
    [Display(Name = "Piauí")] Piaui,
    [Display(Name = "Rio de Janeiro")] RioDeJaneiro,
    [Display(Name = "Rio Grande do Norte")] RioGrandeDoNorte,
    [Display(Name = "Rio Grande do Sul")] RioGrandeDoSul,
    [Display(Name = "Rondônia")] Rondonia
}