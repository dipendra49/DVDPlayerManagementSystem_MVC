#pragma checksum "C:\Users\Dipendra\source\repos\DVD\DVD.Web\DVD.Web\Views\Producer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "28b67174a02fadd4e6c4f03c028f197c3b1ff573"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Producer_Index), @"mvc.1.0.view", @"/Views/Producer/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Dipendra\source\repos\DVD\DVD.Web\DVD.Web\Views\_ViewImports.cshtml"
using DVD.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dipendra\source\repos\DVD\DVD.Web\DVD.Web\Views\_ViewImports.cshtml"
using DVD.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28b67174a02fadd4e6c4f03c028f197c3b1ff573", @"/Views/Producer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0e954805b3db15db006b489c68cb6d491627549", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Producer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DVD.Web.Models.ProducerModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddProducer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Dipendra\source\repos\DVD\DVD.Web\DVD.Web\Views\Producer\Index.cshtml"
  
    ViewData["Title"] = "Index";
    int i = 1;
    if (ViewData["Error"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n                alert(\"");
#nullable restore
#line 9 "C:\Users\Dipendra\source\repos\DVD\DVD.Web\DVD.Web\Views\Producer\Index.cshtml"
                  Write(ViewData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n        </script>\r\n");
#nullable restore
#line 11 "C:\Users\Dipendra\source\repos\DVD\DVD.Web\DVD.Web\Views\Producer\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "28b67174a02fadd4e6c4f03c028f197c3b1ff5734638", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>
<table class=""table table-striped"">
    <thead>
        <tr>
            <th>
                S.N
            </th>
            <th>
                Producer Name
            </th>
            <th>
                Action
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 34 "C:\Users\Dipendra\source\repos\DVD\DVD.Web\DVD.Web\Views\Producer\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 38 "C:\Users\Dipendra\source\repos\DVD\DVD.Web\DVD.Web\Views\Producer\Index.cshtml"
               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "C:\Users\Dipendra\source\repos\DVD\DVD.Web\DVD.Web\Views\Producer\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ProducerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 934, "\"", 989, 2);
            WriteAttributeValue("", 941, "/Producer/UpdateProducer?id=", 941, 28, true);
#nullable restore
#line 44 "C:\Users\Dipendra\source\repos\DVD\DVD.Web\DVD.Web\Views\Producer\Index.cshtml"
WriteAttributeValue("", 969, item.ProducerNumber, 969, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1025, "\"", 1080, 2);
            WriteAttributeValue("", 1032, "/Producer/DeleteProducer?id=", 1032, 28, true);
#nullable restore
#line 45 "C:\Users\Dipendra\source\repos\DVD\DVD.Web\DVD.Web\Views\Producer\Index.cshtml"
WriteAttributeValue("", 1060, item.ProducerNumber, 1060, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 48 "C:\Users\Dipendra\source\repos\DVD\DVD.Web\DVD.Web\Views\Producer\Index.cshtml"
            i++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DVD.Web.Models.ProducerModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
