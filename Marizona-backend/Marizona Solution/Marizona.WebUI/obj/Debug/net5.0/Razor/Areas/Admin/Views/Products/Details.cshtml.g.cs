#pragma checksum "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\Products\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a77fd8fc6c8243477594d582e10093ed7270e0ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Products_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/Products/Details.cshtml")]
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
#line 2 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Marizona.WebUI.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Marizona.WebUI.Models.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a77fd8fc6c8243477594d582e10093ed7270e0ee", @"/Areas/Admin/Views/Products/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd6787b4bab687f1ca070ffa19177394626b28f9", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Products_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-inverse"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\Products\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""page-header"">
    <div class=""row align-items-end"">
        <div class=""col-lg-8"">
            <div class=""page-header-title"">
                <div class=""d-inline"">
                    <h4>Details</h4>
                </div>
            </div>
        </div>
        <div class=""col-lg-4"">
            <div class=""page-header-breadcrumb"">
                <ul class=""breadcrumb-title"">
                    <li class=""breadcrumb-item"" style=""float: left;"">
                        <a href=""#""> <i class=""feather icon-home""></i> </a>
                    </li>
                    <li class=""breadcrumb-item"" style=""float: left;"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a77fd8fc6c8243477594d582e10093ed7270e0ee5669", async() => {
                WriteLiteral("Məhsullar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </li>
                    <li class=""breadcrumb-item"" style=""float: left;"">
                        <a href=""#!"">Details</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>

<div class=""page-body"">
    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""card"">
                <div class=""card-header"">

                    <div class=""card-header-right"">
                        <i class=""icofont icofont-spinner-alt-5""></i>
                    </div>

                </div>
                <div class=""card-block"">
                    <h4 class=""sub-title"">Məhsulların detalları</h4>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">
                            Title
                        </label>
                        <div class=""col-sm-10"">
                            <p class=""form-control"">
                               ");
            WriteLiteral(" ");
#nullable restore
#line 55 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\Products\Details.cshtml"
                           Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">
                            Short Description
                        </label>
                        <div class=""col-sm-10"">
                            <p class=""form-control"">
                                ");
#nullable restore
#line 65 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\Products\Details.cshtml"
                           Write(Model.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">
                            Description
                        </label>
                        <div class=""col-sm-10"">
                            <p class=""form-control"">
                                ");
#nullable restore
#line 75 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\Products\Details.cshtml"
                           Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">
                            Price
                        </label>
                        <div class=""col-sm-10"">
                            <p class=""form-control"">
                                ");
#nullable restore
#line 85 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\Products\Details.cshtml"
                           Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">
                            Is Sale Price
                        </label>
                        <div class=""col-sm-10"">
                            <p class=""form-control"">
                                ");
#nullable restore
#line 95 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\Products\Details.cshtml"
                           Write(Model.IsSalePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">
                            Barcode
                        </label>
                        <div class=""col-sm-10"">
                            <p class=""form-control"">
                                ");
#nullable restore
#line 105 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\Products\Details.cshtml"
                           Write(Model.BarCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">
                            Image Path
                        </label>
                        <div class=""col-sm-10"">
                            <p class=""form-control"">
                                ");
#nullable restore
#line 115 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\Products\Details.cshtml"
                           Write(Model.ImagePath);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">
                            Category Id
                        </label>
                        <div class=""col-sm-10"">
                            <p class=""form-control"">
                                ");
#nullable restore
#line 125 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\Products\Details.cshtml"
                           Write(Model.CategoryId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">
                            Size Id
                        </label>
                        <div class=""col-sm-10"">
                            <p class=""form-control"">
                                ");
#nullable restore
#line 135 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\Products\Details.cshtml"
                           Write(Model.SizeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"form-group row\">\r\n                        <div class=\"col-12\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a77fd8fc6c8243477594d582e10093ed7270e0ee14320", async() => {
                WriteLiteral("Go to edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 141 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Areas\Admin\Views\Products\Details.cshtml"
                                                   WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a77fd8fc6c8243477594d582e10093ed7270e0ee16659", async() => {
                WriteLiteral("Back to list");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
