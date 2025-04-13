using mike_notepads_app.Comom.Models.Common;
using mike_notepads_app.Comom.Models.HomeView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mike_notepads_app.ViewModels
{
	public class HomeViewModel : BindableBase
	{
		public HomeViewModel()
		{
			TaskBar = new ObservableCollection<TaskBar>();
			ToDoList = new ObservableCollection<ToDoItemDto>();

			CreateTaskBar();
			CreateTodoList();
		}

		private ObservableCollection<TaskBar> taskBar;
		private ObservableCollection<ToDoItemDto> toDoList;

		public ObservableCollection<TaskBar> TaskBar
		{
			get { return taskBar; }
			set { taskBar = value; }
		}
		public ObservableCollection<ToDoItemDto> ToDoList
		{
			get { return toDoList; }
			set { toDoList = value; }
		}


		void CreateTaskBar()
		{
            TaskBar.Add(new TaskBar() { Title = "汇总", Content = "10", Icon = "about", Color = "#FF0CA0FF", Target = "" });
            TaskBar.Add(new TaskBar() { Title = "已完成", Content = "20", Icon = "about", Color = "#FF1ECA3A", Target = "" });
            TaskBar.Add(new TaskBar() { Title = "完成率", Content = "30%", Icon = "about", Color = "#FF02C6DC", Target = "" });
            TaskBar.Add(new TaskBar() { Title = "备忘录", Content = "50", Icon = "about", Color = "#FFFFA000", Target = "" });
		}

		void CreateTodoList()
		{
            ToDoList.Add(new ToDoItemDto() { Title = "学习WPF视频", Content = "前往B站学校WPF学习视频、前往B站学校WPF学习视频", CreateTime = DateTime.Now, State = "正常" });
            ToDoList.Add(new ToDoItemDto() { Title = "学习WPF视频", Content = "前往B站学校WPF学习视频、前往B站学校WPF学习视频", CreateTime = DateTime.Now, State = "正常" });
            ToDoList.Add(new ToDoItemDto() { Title = "学习WPF视频", Content = "前往B站学校WPF学习视频、前往B站学校WPF学习视频", CreateTime = DateTime.Now, State = "正常" });
            ToDoList.Add(new ToDoItemDto() { Title = "学习WPF视频", Content = "前往B站学校WPF学习视频、前往B站学校WPF学习视频", CreateTime = DateTime.Now, State = "正常" });
            ToDoList.Add(new ToDoItemDto() { Title = "学习WPF视频", Content = "前往B站学校WPF学习视频、前往B站学校WPF学习视频", CreateTime = DateTime.Now, State = "正常" });
            ToDoList.Add(new ToDoItemDto() { Title = "学习WPF视频", Content = "前往B站学校WPF学习视频、前往B站学校WPF学习视频", CreateTime = DateTime.Now, State = "正常" });
            ToDoList.Add(new ToDoItemDto() { Title = "学习WPF视频", Content = "前往B站学校WPF学习视频、前往B站学校WPF学习视频", CreateTime = DateTime.Now, State = "正常" });
		}
	}
}