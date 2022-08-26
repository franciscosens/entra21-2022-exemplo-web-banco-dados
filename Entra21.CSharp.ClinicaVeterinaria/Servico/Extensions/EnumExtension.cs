using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.Extensions;

public static class EnumExtension
{
    /// <summary>
    ///     A generic extension method that aids in reflecting 
    ///     and retrieving any attribute that is applied to an `Enum`.
    /// </summary>
    public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
        where TAttribute : Attribute
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<TAttribute>();
    }
    
    public static string GetDisplayAttribute(this Enum enumValue) => 
        GetAttribute<DisplayAttribute>(enumValue).Name ?? nameof(enumValue);
    
    public static int GetValue(this Enum enumValue) => 
        (int)(object)(enumValue);
}