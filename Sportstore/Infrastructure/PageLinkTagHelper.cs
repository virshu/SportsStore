using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Sportstore.ViewModels;

namespace Sportstore.Infrastructure;

[HtmlTargetElement("div", Attributes = "page-model")]
public class PageLinkTagHelper(IUrlHelperFactory helperFactory) : TagHelper
{
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext? ViewContext { get; set; }
                
    public PagingInfo? PageModel { get; set; }
                
    public string? PageAction { get; set; }

    public bool PageClassesEnabled { get; set; } = false;
    public string PageClass { get; set; } = string.Empty;
    public string PageClassNormal { get; set; } = string.Empty;
    public string PageClassSelected { get; set; } = string.Empty;
                
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (ViewContext == null || PageModel == null) return;
        IUrlHelper urlHelper = helperFactory.GetUrlHelper(ViewContext);
        TagBuilder result = new("div");
        for (int i = 1; i <= PageModel.TotalPages; i++) {
            TagBuilder tag = new("a")
            {
                Attributes =
                {
                    ["href"] = urlHelper.Action(PageAction, new { productPage = i })
                }
            };
            if (PageClassesEnabled) {
                tag.AddCssClass(PageClass);
                tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
            }
            tag.InnerHtml.Append(i.ToString());
            result.InnerHtml.AppendHtml(tag);
        }
        output.Content.AppendHtml(result.InnerHtml);
    }
}