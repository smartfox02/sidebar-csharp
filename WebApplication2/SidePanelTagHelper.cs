using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.IO;

public class SidePanelTagHelper : TagHelper
{

    public string Title { get; set; }
    public override async void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "side-panel";
        output.Attributes.SetAttribute("title", Title);

        var childContent = await output.GetChildContentAsync();
        var innerContent = childContent.GetContent();

        output.Content.SetHtmlContent($@"
            <div id='inner-sidebar' class='flex h-full flex-col overflow-y-scroll bg-white py-6 shadow-xl'>
                <div class='px-4 sm:px-6'>
                    <h2 class='text-base font-semibold leading-6 text-gray-900' id='slide-over-title'>{Title}</h2>
                </div>
                <div class='relative mt-6 flex-1 px-4 sm:px-6'>
                    {innerContent}
                </div>
            </div>
        ");
        base.Process(context, output);
    }
}