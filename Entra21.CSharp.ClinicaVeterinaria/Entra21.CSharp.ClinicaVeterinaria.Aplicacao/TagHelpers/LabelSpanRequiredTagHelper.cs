using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.TagHelpers;

[HtmlTargetElement("label", Attributes = "span-required")]
public class LabelSpanRequiredTagHelper : TagHelper
{
    [HtmlAttributeName("span-required")]
    public string Required { get; set; }
    
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);
        output.PostContent.SetHtmlContent(" <span class=\"text-danger fw-bold\">*</span>");
    }
}