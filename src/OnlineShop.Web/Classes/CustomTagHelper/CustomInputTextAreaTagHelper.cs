using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.IO;

namespace OnlineShop.Web.Classes.CustomTagHelper
{
    [HtmlTargetElement("CustomInputTextArea")]
    public class CustomInputTextAreaTagHelper:TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeName("asp-rows")]
        public int rows { get; set; }

        [HtmlAttributeName("asp-columns")]
        public int columns { get; set; }

        [HtmlAttributeName("asp-Class")]
        public string Class { get; set; }

        [HtmlAttributeName("asp-FormClass")]
        public string FormClass { get; set; }

        private readonly IHtmlGenerator _generator;

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public CustomInputTextAreaTagHelper(IHtmlGenerator generator)
        {
            _generator = generator;
        }

        public override void Process(TagHelperContext context,TagHelperOutput output)
        {
            using(var writer = new StringWriter())
            {
                writer.Write($"<div class= {FormClass} form-group>");

                var label = _generator.GenerateLabel(
                                ViewContext,
                                For.ModelExplorer,
                                For.Name,null,
                                new { @class = "control-label" });

                label.WriteTo(writer,NullHtmlEncoder.Default);

                var isOptinal = !For.ModelExplorer.Metadata.IsRequired ? " bg-light" : "";
                var textArea = _generator.GenerateTextArea(ViewContext,
                                    For.ModelExplorer,
                                    For.Name,
                                    rows,
                                    columns,
                                    new { @class = $"{Class}  form-control {isOptinal}",});

                textArea.WriteTo(writer,NullHtmlEncoder.Default);

                var validationMsg = _generator.GenerateValidationMessage(
                                        ViewContext,
                                        For.ModelExplorer,
                                        For.Name,
                                        null,
                                        ViewContext.ValidationMessageElement,
                                        new { @class = "text-danger" });

                validationMsg.WriteTo(writer,NullHtmlEncoder.Default);

                writer.Write(@"</div>");

                output.Content.SetHtmlContent(writer.ToString());
            }
        }
    }
}