#pragma checksum "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "263ef81225d7346450e83221e9c5cb19d40e7907"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Menu_Index), @"mvc.1.0.view", @"/Views/Menu/Index.cshtml")]
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
using Marizona.WebUI.Models.FormModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\_ViewImports.cshtml"
using Marizona.WebUI.Models.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"263ef81225d7346450e83221e9c5cb19d40e7907", @"/Views/Menu/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25ad4215b0e5ebe60475096fca662aeeea6b52dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Menu_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopFilterCategoriesViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("slogan__icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/uploads/icons/fast-delivery-orange.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/uploads/icons/clock.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/uploads/icons/pizza-slice.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""about-page"">
    <div>
        <h1>Menu</h1>
        <span class=""about-page__sub-text""><span>"" Marizona ""</span> is the perfect place for Fast food</span>
    </div>
</section>

<div class=""container"">
    <section class=""todays-menu"">
        <div class=""title-menu"">
            <h2>
                Menus Of The Day
            </h2>
            <ul class=""buttons"">
                <li data-filter=""all"" class=""button-select active"" href=""#"">ALL</li>



");
#nullable restore
#line 24 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                 foreach (var item in Model.Categories)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li data-filter=\"");
#nullable restore
#line 26 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                                Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"button-select\" href=\"#\">");
#nullable restore
#line 26 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                                                                           Write(item.Name.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 27 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
            WriteLiteral("            </ul>\r\n        </div>\r\n        <div class=\"menu-cards\">\r\n");
#nullable restore
#line 38 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
             foreach (var item in Model.Products)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"menu-card-wrap\" data-category=\"");
#nullable restore
#line 40 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                                                      Write(item.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                    <div class=\"menu-card\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "263ef81225d7346450e83221e9c5cb19d40e79078959", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1432, "~/uploads/images/", 1432, 17, true);
#nullable restore
#line 42 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
AddHtmlAttributeValue("", 1449, item.ImagePath, 1449, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("                        <div class=\"menu-card__body\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "263ef81225d7346450e83221e9c5cb19d40e790710695", async() => {
                WriteLiteral("\r\n                                <span>");
#nullable restore
#line 46 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                                 Write(item.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                                                                            WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            <ul class=""product-stars"">
                                <li class=""rate-star""><i class=""far fa-star""></i></li>
                                <li class=""rate-star""><i class=""far fa-star""></i></li>
                                <li class=""rate-star""><i class=""far fa-star""></i></li>
                                <li class=""rate-star""><i class=""far fa-star""></i></li>
                                <li class=""rate-star""><i class=""far fa-star""></i></li>
                            </ul>
                            <p class=""short-description"">");
#nullable restore
#line 55 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                                                    Write(item.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <div class=\"price-basket\">\r\n                                <div>\r\n                                    <span");
            BeginWriteAttribute("class", " class=\"", 2567, "\"", 2630, 2);
            WriteAttributeValue("", 2575, "main-price", 2575, 10, true);
#nullable restore
#line 58 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
WriteAttributeValue(" ", 2585, item.IsSalePrice != null ? "is-sale" : "", 2586, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        $");
#nullable restore
#line 59 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                                    Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </span>\r\n                                    <span");
            BeginWriteAttribute("class", " class=\"", 2774, "\"", 2837, 2);
            WriteAttributeValue("", 2782, "price", 2782, 5, true);
#nullable restore
#line 61 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
WriteAttributeValue(" ", 2787, item.IsSalePrice == null ? "is-sale-none" : "", 2788, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        $");
#nullable restore
#line 62 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                                    Write(item.IsSalePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </span>
                                </div>
                                <span class=""basket""><a href=""#""><i class=""fas fa-shopping-basket""></i></a></span>
                            </div>
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 70 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"        </div>
    </section>
</div>


<section class=""container-fluid"" style=""padding: 0px;"">
    <div class=""new-taste"">
        <div class=""new-taste__poster-order"">
            <div class=""poster-order-background-overlay"">
                <div>
                    <h2>Explore the new taste</h2>
                    <p>Enjoy our luscious dishes wherever you want</p>
                    <a href=""./contact.html""><button class=""btn-hard-md"">ORDER NOW</button></a>
                </div>
            </div>
        </div>
        <div class=""new-taste__menu"">
            <div class=""menu-background-overlay"">
");
#nullable restore
#line 226 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                 foreach (var item in Model.RecentProducts)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"product-item\">\r\n                        <div class=\"product\">\r\n                            <h2 class=\"product__name\">");
#nullable restore
#line 230 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                                                 Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                            <h2 class=\"product__price\">$");
#nullable restore
#line 231 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                                                   Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                        </div>\r\n                        <div class=\"divide-elements\"></div>\r\n                        <p class=\"content\">Shrimp, Squid, Pineapple</p>\r\n                    </div>\r\n");
#nullable restore
#line 236 "E:\P317\Final-Project\Marizona\marizona-project\Marizona-backend\Marizona Solution\Marizona.WebUI\Views\Menu\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n<div class=\"container slogan-wrap\">\r\n    <div class=\"slogans\">\r\n        <div class=\"slogan\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "263ef81225d7346450e83221e9c5cb19d40e790719487", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <div>\r\n                <h3 class=\"slogan__title\">Free shipping</h3>\r\n                <p class=\"slogan__description\">Sign up for updates and get free shipping</p>\r\n            </div>\r\n        </div>\r\n        <div class=\"slogan\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "263ef81225d7346450e83221e9c5cb19d40e790720956", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <div>
                <h3 class=""slogan__title"">30 Minutes Delivery</h3>
                <p class=""slogan__description"">Everything you order will be quickly delivered to your door.</p>
            </div>
        </div>
        <div class=""slogan"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "263ef81225d7346450e83221e9c5cb19d40e790722437", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <div>
                <h3 class=""slogan__title"">Best Quality Guarantee</h3>
                <p class=""slogan__description"">Poco is an international chain of family restaurants.</p>
            </div>
        </div>
    </div>
</div>


");
            DefineSection("addjs", async() => {
                WriteLiteral("\r\n    <script src=\"./assets/js/filter.js\"></script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
            DefineSection("addcss", async() => {
                WriteLiteral(@"
    <style>
        .main-price {
            display: block !important;
            margin-right: 20px !important;
        }

        .is-sale-none {
            display: none !important;
        }

        .price-basket > div {
            white-space: nowrap;
            width: 100%;
            display: flex;
        }
    </style>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopFilterCategoriesViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
