#pragma checksum "C:\Users\timaa\OneDrive - Leicester College\Beanbrew\Beanbrew\Views\Information\About.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6c92593440d7ebc6e421a331059cf8e5da58766850bf56823e2aa8138b08a739"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Information_About), @"mvc.1.0.view", @"/Views/Information/About.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\timaa\OneDrive - Leicester College\Beanbrew\Beanbrew\Views\_ViewImports.cshtml"
using Beanbrew;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\timaa\OneDrive - Leicester College\Beanbrew\Beanbrew\Views\_ViewImports.cshtml"
using Beanbrew.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"6c92593440d7ebc6e421a331059cf8e5da58766850bf56823e2aa8138b08a739", @"/Views/Information/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"2da0581536add147b63da4b8900f860328a435ed5d44689400be7d20b0348e3a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Information_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/facebook.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/twitter.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/utube.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!--set the title to About-->\r\n");
#nullable restore
#line 2 "C:\Users\timaa\OneDrive - Leicester College\Beanbrew\Beanbrew\Views\Information\About.cshtml"
  
    ViewData["Title"] = "About";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!--all the information displayed in About is in body tag for bg colour-->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6c92593440d7ebc6e421a331059cf8e5da58766850bf56823e2aa8138b08a7395220", async() => {
                WriteLiteral(@"
    <!--put the welcome message in a heading to make the text big-->
    <h1>
        Welcome to Bean and Brew About!
    </h1>
    <!--the social media links take the user to my social media pages-->
    <table>
        <tr>
            <td>
                <a href=""https://www.facebook.com/tima.amelins.1"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6c92593440d7ebc6e421a331059cf8e5da58766850bf56823e2aa8138b08a7395842", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </a>\r\n            </td>\r\n            <td>\r\n                <a href=\"https://twitter.com/A95573Amelins\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6c92593440d7ebc6e421a331059cf8e5da58766850bf56823e2aa8138b08a7397190", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </a>\r\n            </td>\r\n            <td>\r\n                <a href=\"https://www.youtube.com/channel/UCxRate9u6-rxbZfAxZ4ZjtA\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6c92593440d7ebc6e421a331059cf8e5da58766850bf56823e2aa8138b08a7398561", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </a>
            </td>
        </tr>
    </table>
 
<!--put the headers, maps and paragraphs about the locations in a table-->
<table>
    <!--the headers provide a logical indication of each column-->
    <tr>
        <th>
            Harrogate
        </th>
        <th>
            Knaresborough
        </th>
        <th>
            Leeds
        </th>
    </tr>
    <!--the Google maps for the 3 branches are embedded as iframes-->
        <tr>
            <td>
                <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d150111.25737165663!2d-1.6933753241900111!3d53.9941060921552!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x48794e237175bd01%3A0x3c084fbaadea4ff!2sHarrogate!5e0!3m2!1sen!2suk!4v1709395343362!5m2!1sen!2suk"" width=""100%"" height=""450"" style=""border:0;""");
                BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 1772, "\"", 1790, 0);
                EndWriteAttribute();
                WriteLiteral(@" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade"">
                </iframe>
            </td>
            <td>
                <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d75031.7560605257!2d-1.5513323697487487!3d54.007348228870605!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x48794c0904d12069%3A0x38a9bbcb87ed3689!2sKnaresborough!5e0!3m2!1sen!2suk!4v1709395389809!5m2!1sen!2suk"" width=""100%"" height=""450"" style=""border:0;""");
                BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 2258, "\"", 2276, 0);
                EndWriteAttribute();
                WriteLiteral(@" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade"">
                </iframe>
            </td>
            <td>
                <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d301577.5359655567!2d-1.8646706927806642!3d53.80595803667269!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x48793e4ada64bd99%3A0x51adbafd0213dca9!2sLeeds!5e0!3m2!1sen!2suk!4v1709395420397!5m2!1sen!2suk"" width=""100%"" height=""450"" style=""border:0;""");
                BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 2736, "\"", 2754, 0);
                EndWriteAttribute();
                WriteLiteral(@" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade"">
                </iframe>
            </td>
        </tr>
        <!--the paragraphs are in another row to provide organised layout-->
        <tr>
            <td>
                Bean and Brew Harrogate is the cafe situated in Harrogate, a nice town in North Yorkshire that is remarkably close to the promising Yorkshire Dales National Park. Harrogate has a history of having a fashionable spa resort and that heritage stays in the Montpellier Quarter with the Royal Pump Room Museum. Harrogate is near to Leeds, so while building your itinerary of things to do in Yorkshire do not forget to include this nice town in your list.
            </td>
            <td>
                Bean and Brew Knaresborough is a cafe situated in the picturesque market, spa town and civil parish on the river Nidd that is Knaresborough. A fun fact about Knaresborough is that up until August 2023, Knaresborough was in the Harrogate borough, probably because Knaresbo");
                WriteLiteral(@"rough is only 3 miles east of Harrogate - so if you ever visit Harrogate why not take the short drive, or walk to Knaresborough to take a break and enjoy the surrounding countryside and quietness of this town?
            </td>
            <td>
                Bean and Brew Leeds is a cafe in the bustling city of Leeds that is big but has so many things to see and do. Bean and Brew Leeds is also where we base our booking lessons so if you ever book a baking lesson with us you will end up with a city with so many things to see and do. Leeds is in the south bank of the river Aire. Leeds houses the national collection of military equipment. Leeds' Call Lane has bars and live music venues under rail arches, and finally Leeds Kirkgate Market features so many indoor and outdoor stalls, wo why not head over to Leeds, take a break in our humble cafe before indulging in everything Leeds has to offer?
            </td>
        </tr>
    </table>
    
    <!--finally there is the information about Bean and Brew ");
                WriteLiteral(@"for all cafes-->
    Bean and Brew is a small local chain of cafes
    and coffee shops based around Harrogate
    and Leeds. They currently have the following
    venues and services:
    <ol>
        <li>Coffee shops</li>
        <li>Small local cuisine restaurants</li>
        <li>Baking lessons</li>
        <li>Bakery takeaway</li>
    </ol>
    Bean and Brew were one of the first
    companies in the UK to use fair-trade coffee
    and all organic milk for their products. Each
    drink is made exactly to your specifications,
    for a personal service. They also offer their
    trademarked flavoured coffees, breakfast
    items such as porridge, small sweet treats,
    and pressed sandwiches. Recently they’ve also
    added frappes and fruit smoothies in addition
    to seasonal treats such as the pumpkin spiced
    latte (for Halloween) and various assorted
    baked goods.
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591