using IBatisNet.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
	public class DaoTree
	{
		private static ILog logManager = LogManager.GetLogger(typeof(DaoManager));

		public IList<CTree> getTreeList( IDictionary<string, Object> dic )
		{
			return DaoManager.Instance.QueryForList<CTree>("TREE.select_tree_list", dic);
		}

		public IList<CTree> getTreeList(string tree_type, int tree_code, string emp_no, int tree_level)
		{

			IDictionary<string, object> dic = new Dictionary<string, object>();

			dic.Add("tree_type", tree_type);
			dic.Add("tree_code", tree_code);
			dic.Add("emp_no", emp_no);
			dic.Add("tree_level", tree_level);

			return getTreeList(dic);
		}

		public IList<String> getTreeTypeList()
		{
			return DaoManager.Instance.QueryForList<String>("TREE.select_tree_type_list", null);
		}

		public CTree getTreeOne(int tree_code)
		{
			return DaoManager.Instance.QueryForObject<CTree>("TREE.select_tree_one", tree_code);
		}

	}
}
