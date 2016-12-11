using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewLife.Cube;
using NewLife.DNS.Entity;
using NewLife.Web;

namespace NewLife.DNS.Web.Controllers
{
    public class HistoryController : EntityController<History>
    {
        static HistoryController()
        {
            var list = ListFields;
            list.RemoveField("CreateUserID");
        }

        /// <summary>列表页视图。子控制器可重载，以传递更多信息给视图，比如修改要显示的列</summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected override ActionResult IndexView(Pager p)
        {
            var list = History.Search(p["type"].ToInt(), p["name"], p["address"], p["dtStart"].ToDateTime(), p["dtEnd"].ToDateTime(), p["Q"], p);

            return View("List", list);
        }
    }
}