using DAO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groupware.Base.Controllers.Utility
{
    public class TreeController : Controller
    {
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult StatusList(string tree_type, int tree_level)
		{
			IList<CTree> listTree = new List<CTree>();
			try
			{
				DaoTree daoTree = new DaoTree();
				listTree = daoTree.getTreeList(tree_type, 0, null, tree_level);
				ViewBag.listTree = listTree;
			}
			catch (Exception e)
			{
				UtilityController.WriteLog(e.Message);
				throw new Exception(e.Message);
			}

			return PartialView("~/Views/PartialView/StatusView.cshtml", listTree);
		}

		public ActionResult TreePreview(string tree_type)
		{
			IList<CTree> listTree = new List<CTree>();
			try
			{
				if (tree_type == null || tree_type == "")
				{
					tree_type = "leftmenu";
				}

				DaoTree daoTree = new DaoTree();
				listTree = daoTree.getTreeList(tree_type, 0, null, 0);
				ViewBag.listTree = listTree;
				ViewBag.listTreeType = daoTree.getTreeTypeList();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			return PartialView("~/Views/Tree/TreePreview.cshtml", listTree);
		}

		public JsonResult getTreeOne(int tree_code)
		{
			CTree tree = new CTree();
			JsonResult json = new JsonResult();
			try
			{
				DaoTree daoTree = new DaoTree();
				
				tree = daoTree.getTreeOne(tree_code);
				json.Data = tree;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			return json;
		}

		[HttpPost]
		public JsonResult setTreeOne()
		{
			//Request.Form["frm"][];
			JsonResult json = new JsonResult();
			try
			{
				CTree tree = new CTree();


				DaoTree daoTree = new DaoTree();

				//tree = daoTree.getTreeOne(tree_code);
				json.Data = tree;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			return json;
		}

    }
}
