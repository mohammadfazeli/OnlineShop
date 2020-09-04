using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.IO;

namespace OnlineShop.Web.Classes.CustomTagHelper
{
    [HtmlTargetElement("CustomCheckBox")]
    public class CustomCheckBoxTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeName("asp-IsChecked")]
        public bool? IsChecked { get; set; }

        [HtmlAttributeName("asp-Class")]
        public string Class { get; set; }

        [HtmlAttributeName("asp-FormClass")]
        public string FormClass { get; set; }

        private readonly IHtmlGenerator _generator;

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public CustomCheckBoxTagHelper(IHtmlGenerator generator)
        {
            _generator = generator;
            IsChecked = false;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            using (var writer = new StringWriter())
            {
                writer.Write($"<div class= {FormClass}  CheckBox form-group>");

                var label = _generator.GenerateLabel(
                                ViewContext,
                                For.ModelExplorer,
                                For.Name, null,
                                new { @class = " col-form-label control-label" });

                label.WriteTo(writer, NullHtmlEncoder.Default);

                var textArea = _generator.GenerateCheckBox(ViewContext,
                                    For.ModelExplorer,
                                    For.Name,
                                    IsChecked,
                                    new { @class = $"{Class}" });

                textArea.WriteTo(writer, NullHtmlEncoder.Default);

                var validationMsg = _generator.GenerateValidationMessage(
                                        ViewContext,
                                        For.ModelExplorer,
                                        For.Name,
                                        null,
                                        ViewContext.ValidationMessageElement,
                                        new { @class = "text-danger " });

                validationMsg.WriteTo(writer, NullHtmlEncoder.Default);

                writer.Write(@"</div>");

                output.Content.SetHtmlContent(writer.ToString());
            }
        }
    }
}