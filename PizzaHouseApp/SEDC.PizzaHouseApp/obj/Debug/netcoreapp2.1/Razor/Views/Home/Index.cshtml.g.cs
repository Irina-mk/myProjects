#pragma checksum "C:\Users\irina\source\repos\SEDC.PizzaHouseApp\SEDC.PizzaHouseApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9fe102298d66c149ca8c619a502012db043cb422"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\irina\source\repos\SEDC.PizzaHouseApp\SEDC.PizzaHouseApp\Views\_ViewImports.cshtml"
using SEDC.PizzaHouseApp;

#line default
#line hidden
#line 2 "C:\Users\irina\source\repos\SEDC.PizzaHouseApp\SEDC.PizzaHouseApp\Views\_ViewImports.cshtml"
using SEDC.PizzaHouseApp.Models;

#line default
#line hidden
#line 3 "C:\Users\irina\source\repos\SEDC.PizzaHouseApp\SEDC.PizzaHouseApp\Views\_ViewImports.cshtml"
using SEDC.PizzaHouseApp.Models.Domain;

#line default
#line hidden
#line 4 "C:\Users\irina\source\repos\SEDC.PizzaHouseApp\SEDC.PizzaHouseApp\Views\_ViewImports.cshtml"
using SEDC.PizzaHouseApp.Models.ViewModels;

#line default
#line hidden
#line 5 "C:\Users\irina\source\repos\SEDC.PizzaHouseApp\SEDC.PizzaHouseApp\Views\_ViewImports.cshtml"
using SEDC.PizzaHouseApp.Models.Enums;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fe102298d66c149ca8c619a502012db043cb422", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87cb23c245ccdd161472c199643eeab6b432b730", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 71, true);
            WriteLiteral("<h1>PizzaApp</h1>\r\n<h3>The best application for ordering pizza</h3>\r\n\r\n");
            EndContext();
            BeginContext(72, 109, false);
#line 4 "C:\Users\irina\source\repos\SEDC.PizzaHouseApp\SEDC.PizzaHouseApp\Views\Home\Index.cshtml"
Write(Html.ActionLink("New order", "Create", "Order", null,  new { @class  = "btn btn-success", @id = "new-order"}));

#line default
#line hidden
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
