using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BookStoreApplication.Helper
{
    public class CustomEmailTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
        }
    }
}
