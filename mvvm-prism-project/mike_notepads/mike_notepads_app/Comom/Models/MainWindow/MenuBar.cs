using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mike_notepads_app.Comom.Models.MainWindow
{
	/// <summary>
	/// 系统导航菜单实体类
	/// </summary>
	public class MenuBar : BindableBase
	{
		private string name;
		/// <summary>
		/// 菜单名称
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string icon;
		/// <summary>
		/// 图标
		/// </summary>
		public string Icon
		{
			get { return icon; }
			set { icon = value; }
		}

		private string nameSpace;
		/// <summary>
		/// 菜单命名空间
		/// </summary>
		public string NameSpace
		{
			get { return nameSpace; }
			set { nameSpace = value; }
		}
	}
}
