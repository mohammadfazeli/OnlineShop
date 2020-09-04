using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.IO;

namespace OnlineShop.Web.Classes.CustomTagHelper
{
    [HtmlTargetElement("CustomInput")]
    public class CustomInputTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeName("asp-Class")]
        public string Class { get; set; }

        [HtmlAttributeName("asp-FormClass")]
        public string FormClass { get; set; }

        [HtmlAttributeName("asp-value")]
        public object value { get; set; }

        [HtmlAttributeName("asp-Format")]
        public string Format { get; set; }

        private readonly IHtmlGenerator _generator;

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public CustomInputTagHelper(IHtmlGenerator generator)
        {
            _generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            using (var writer = new StringWriter())
            {
                writer.Write($"<div class= {FormClass} form-group>");

                var label = _generator.GenerateLabel(
                                ViewContext,
                                For.ModelExplorer,
                                For.Name, null,
                                new { @class = "control-label" });

                label.WriteTo(writer, NullHtmlEncoder.Default);
                var isOptinal = !For.ModelExplorer.Metadata.IsRequired ? " bg-light" : "";

                var textArea = _generator.GenerateTextBox(
                                    ViewContext,
                                    For.ModelExplorer,
                                    For.Name,
                                    For.Model,//For.Model,
                                    Format,
                                    new { @class = $"{Class} form-control {isOptinal} " });

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