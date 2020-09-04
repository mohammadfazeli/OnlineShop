using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.IO;

namespace OnlineShop.Web.Classes.CustomTagHelper
{
    [HtmlTargetElement("CustomSelect")]
    public class CustomSelectTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeName("asp-Class")]
        public string Class { get; set; }

        [HtmlAttributeName("asp-FormClass")]
        public string FormClass { get; set; }

        [HtmlAttributeName("asp-optionLabel")]
        public string optionLabel { get; set; }

        [HtmlAttributeName("asp-expression")]
        public string expression { get; set; }

        [HtmlAttributeName("asp-selectList")]
        public IEnumerable<SelectListItem> selectList { get; set; }

        [HtmlAttributeName("asp-currentValues")]
        public ICollection<string> currentValues { get; set; }

        [HtmlAttributeName("asp-allowMultiple")]
        public bool allowMultiple { get; set; }

        [HtmlAttributeName("asp-htmlAttributes")]
        public object htmlAttributes { get; set; }

        private readonly IHtmlGenerator _generator;

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public CustomSelectTagHelper(IHtmlGenerator generator)
        {
            _generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            using (var writer = new StringWriter())
            {
                writer.Write($"<div class={FormClass} form-group>");

                var label = _generator.GenerateLabel(
                                ViewContext,
                                For.ModelExplorer,
                                For.Name, null,
                                new { @class = "control-label" });

                label.WriteTo(writer, NullHtmlEncoder.Default);

                var isOptinal = !For.ModelExplorer.Metadata.IsRequired ? " bg-light" : "";

                var textArea = _generator.GenerateSelect(ViewContext,
                                    For.ModelExplorer,
                                    optionLabel,
                                    expression,
                                    selectList,
                                    currentValues,
                                    allowMultiple,
                                    new { @class = $"{Class} form-control {isOptinal}" });

                textArea.WriteTo(writer, NullHtmlEncoder.Default);

                var validationMsg = _generator.GenerateValidationMessage(
                                        ViewContext,
                                        For.ModelExplorer,
                                        For.Name,
                                        null,
                                        ViewContext.ValidationMessageElement,
                                        new { @class = "text-danger" });

                validationMsg.WriteTo(writer, NullHtmlEncoder.Default);

                writer.Write(@"</div>");

                output.Content.SetHtmlContent(writer.ToString());
            }
        }
    }
}