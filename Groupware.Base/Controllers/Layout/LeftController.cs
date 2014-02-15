using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groupware.Base.Controllers.Layout
{
    public class LeftController : Controller
    {
        //
        // GET: /Left/

        public ActionResult Index()
        {
			IList<CTree> listTree = new List<CTree>();
			try
			{
				DaoTree daoTree = new DaoTree();
				listTree = daoTree.getTreeList("leftmenu", 0, null, 0);
				ViewBag.listTree = listTree;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			return PartialView("~/views/layout/LeftMenu.cshtml", listTree);
        }

    }
}
