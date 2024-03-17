using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement(Attributes = "secure-roles")]
public class SecureRoleTagHelper : TagHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public SecureRoleTagHelper(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
    {
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
    }

    public string SecureRoles { get; set; }
    public bool IsEditable { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var role = _configuration.GetValue<string>("SecureRoles");
        if (role != SecureRoles)
        {
            output.SuppressOutput();
        }
        else
        {
            // Detect the type of the HTML element
            if (context.TagName == "input" ||
                context.TagName == "textarea" ||
                context.TagName == "button" ||
                context.TagName == "div" ||
                context.TagName == "section" ||
                context.TagName == "style" ||
                context.TagName == "script") {
                if (!IsEditable)
                {
                    output.SuppressOutput();
                }
            }
        }
    }
}