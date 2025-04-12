using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mike_notepads_app.Comom.Models.HomeView
{
	public class ToDoItemDto : BindableBase
	{
		private int id;
		private string title;
		private string content;
		private string state;
		private DateTime createTime;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		public string Content
		{
			get { return content; }
			set { content = value; }
		}

		public string State
		{
			get { return state; }
			set { state = value; }
		}

		public DateTime CreateTime
		{
			get { return createTime; }
			set { createTime = value; }
		}
	}
}
