#pragma checksum "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\FAQs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bef478f2927a8dcf950bd358b9be082f98d451f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FAQs_Index), @"mvc.1.0.view", @"/Views/FAQs/Index.cshtml")]
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
#line 2 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\_ViewImports.cshtml"
using Marizona.WebUI.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\_ViewImports.cshtml"
using Marizona.WebUI.Models.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bef478f2927a8dcf950bd358b9be082f98d451f2", @"/Views/FAQs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd6787b4bab687f1ca070ffa19177394626b28f9", @"/Views/_ViewImports.cshtml")]
    public class Views_FAQs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FAQ>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\FAQs\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<section class=\"about-page\">\r\n    <div>\r\n        <h1>FAQ</h1>\r\n        <span class=\"about-page__sub-text\"><span>\" Marizona \"</span> is the perfect place for Fast food</span>\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n<section class=\"faqs\">\r\n\r\n");
#nullable restore
#line 18 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\FAQs\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"faq\">\r\n            <div class=\"question\">\r\n                <h3>");
#nullable restore
#line 22 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\FAQs\Index.cshtml"
               Write(item.Question);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <i class=\"fas fa-chevron-down click-rotate\"></i>\r\n            </div>\r\n            <div class=\"answer\">\r\n                <p>");
#nullable restore
#line 26 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\FAQs\Index.cshtml"
              Write(item.Answer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 29 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\FAQs\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</section>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FAQ>> Html { get; private set; }
    }
}
#pragma warning restore 1591
