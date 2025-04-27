using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApplication7.Helper
{
    public class CustomEmailTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
        }
    }
}
