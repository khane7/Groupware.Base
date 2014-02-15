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
			IList<CCode> listTree = new List<CCode>();
			try
			{
				DaoCode daoTree = new DaoCode();
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
			IList<CCode> listTree = new List<CCode>();
			try
			{
				if (tree_type == null || tree_type == "")
				{
					tree_type = "leftmenu";
				}

				DaoCode daoTree = new DaoCode();
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
			CCode tree = new CCode();
			JsonResult json = new JsonResult();
			try
			{
				DaoCode daoTree = new DaoCode();
				
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
				CCode tree = new CCode();


				DaoCode daoTree = new DaoCode();

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
