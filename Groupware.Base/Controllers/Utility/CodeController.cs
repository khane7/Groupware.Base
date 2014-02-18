using DAO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groupware.Base.Controllers.Utility
{
    public class CodeController : Controller
    {
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult StatusList(string tree_type, int tree_level)
		{
			IList<CCode> listCode = new List<CCode>();
			try
			{
				DaoCode daoTree = new DaoCode();
				listCode = daoTree.getCodeList(tree_type, 0, null, tree_level);
				ViewBag.listCode = listCode;
			}
			catch (Exception e)
			{
				UtilityController.WriteLog(e.Message);
				throw new Exception(e.Message);
			}

			return PartialView("~/Views/PartialView/StatusView.cshtml", listCode);
		}

		public ActionResult CodePreview(string tree_type)
		{
			IList<CCode> listCode = new List<CCode>();
			try
			{
				if (tree_type == null || tree_type == "")
				{
					tree_type = "leftmenu";
				}

				DaoCode daoCode = new DaoCode();
				listCode = daoCode.getCodeList(tree_type, 0, null, 0);
				ViewBag.listCode = listCode;
				ViewBag.listCodeType = daoCode.getCodeTypeList();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			return PartialView("~/Views/Code/CodePreview.cshtml", listCode);
		}

		public JsonResult getCodeOne(int tree_code)
		{
			CCode code = new CCode();
			JsonResult json = new JsonResult();
			try
			{
				DaoCode daoTree = new DaoCode();

				code = daoTree.getCodeOne(tree_code);
				json.Data = code;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			return json;
		}

		[HttpPost]
		public JsonResult setCodeOne()
		{
			//Request.Form["frm"][];
			JsonResult json = new JsonResult();
			try
			{
				CCode code = new CCode();


				DaoCode daoCode = new DaoCode();

				//tree = daoTree.getTreeOne(tree_code);
				json.Data = code;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			return json;
		}

    }
}
