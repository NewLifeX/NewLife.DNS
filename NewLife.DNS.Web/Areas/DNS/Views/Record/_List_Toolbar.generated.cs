﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
    using NewLife;
    
    #line default
    #line hidden
    using NewLife.Cube;
    using NewLife.DNS;
    
    #line 4 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
    using NewLife.DNS.Entity;
    
    #line default
    #line hidden
    using NewLife.DNS.Web;
    using NewLife.Reflection;
    
    #line 2 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
    using NewLife.Web;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
    using XCode;
    
    #line default
    #line hidden
    using XCode.Membership;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/DNS/Views/Record/_List_Toolbar.cshtml")]
    public partial class _Areas_DNS_Views_Record__List_Toolbar_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_DNS_Views_Record__List_Toolbar_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 5 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
  
    var fact = ViewBag.Factory as IEntityOperate;
    var page = ViewBag.Page as Pager;

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"tableTools-container list-toolbar\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"form-inline clear-fix\"");

WriteLiteral(">\r\n        <form");

WriteAttribute("action", Tuple.Create(" action=\"", 281), Tuple.Create("\"", 361)
            
            #line 11 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
, Tuple.Create(Tuple.Create("", 290), Tuple.Create<System.Object, System.Int32>(Url.Action("index")
            
            #line default
            #line hidden
, 290), false)
            
            #line 11 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
, Tuple.Create(Tuple.Create("", 310), Tuple.Create<System.Object, System.Int32>(Html.Raw("?" + page.GetBaseUrl(false, true, true))
            
            #line default
            #line hidden
, 310), false)
);

WriteLiteral(" method=\"post\"");

WriteLiteral(" role=\"form\"");

WriteLiteral(">\r\n");

            
            #line 12 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
            
            
            #line default
            #line hidden
            
            #line 12 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
             if (ManageProvider.User.Has(PermissionFlags.Insert))
            {
                
            
            #line default
            #line hidden
            
            #line 14 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
           Write(Html.ActionLink("添加" + ViewContext.Controller.GetType().GetDisplayName(), "Add", null, new { @class = "btn btn-success btn-sm" }));

            
            #line default
            #line hidden
            
            #line 14 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
                                                                                                                                                  
            }

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"pull-right form-group\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"type\"");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">类型：</label>\r\n");

WriteLiteral("                    ");

            
            #line 19 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
               Write(Html.ForDropDownList("type", System.EnumHelper.GetDescriptions(typeof(QueryType)), Request["type"], "全部", true));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"dtStart\"");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">时间：</label>\r\n                    <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"input-group-addon\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-calendar\"");

WriteLiteral("></i></span>\r\n                        <input");

WriteLiteral(" name=\"dtStart\"");

WriteLiteral(" id=\"dtStart\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1276), Tuple.Create("\"", 1303)
            
            #line 25 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
, Tuple.Create(Tuple.Create("", 1284), Tuple.Create<System.Object, System.Int32>(Request["dtStart"]
            
            #line default
            #line hidden
, 1284), false)
);

WriteLiteral(" dateformat=\"yyyy-MM-dd\"");

WriteLiteral(" class=\"form-control form_datetime\"");

WriteLiteral(" />\r\n                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"dtEnd\"");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">至</label>\r\n                    <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"input-group-addon\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-calendar\"");

WriteLiteral("></i></span>\r\n                        <input");

WriteLiteral(" name=\"dtEnd\"");

WriteLiteral(" id=\"dtEnd\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1730), Tuple.Create("\"", 1755)
            
            #line 32 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
, Tuple.Create(Tuple.Create("", 1738), Tuple.Create<System.Object, System.Int32>(Request["dtEnd"]
            
            #line default
            #line hidden
, 1738), false)
);

WriteLiteral(" dateformat=\"yyyy-MM-dd\"");

WriteLiteral(" class=\"form-control form_datetime\"");

WriteLiteral(" />\r\n                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"input-group-addon\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"ace-icon fa fa-check\"");

WriteLiteral("></i>\r\n                    </span>\r\n                    <input");

WriteLiteral(" name=\"q\"");

WriteLiteral(" type=\"search\"");

WriteLiteral(" id=\"q\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2116), Tuple.Create("\"", 2137)
            
            #line 39 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
, Tuple.Create(Tuple.Create("", 2124), Tuple.Create<System.Object, System.Int32>(Request["q"]
            
            #line default
            #line hidden
, 2124), false)
);

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"搜索用户或者网关\"");

WriteLiteral(" />\r\n                    <span");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                        <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-purple btn-sm\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"ace-icon fa fa-search icon-on-right bigger-110\"");

WriteLiteral("></span>\r\n                            查询\r\n                        </button>\r\n    " +
"                </span>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-group btn-toolbar\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 48 "..\..\Areas\DNS\Views\Record\_List_Toolbar.cshtml"
               Write(Html.Partial("_List_Toolbar_Adv"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>" +
"\r\n");

        }
    }
}
#pragma warning restore 1591
