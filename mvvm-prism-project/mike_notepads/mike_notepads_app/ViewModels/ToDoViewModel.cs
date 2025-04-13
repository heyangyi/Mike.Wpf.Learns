using mike_notepads_app.Comom.Models.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mike_notepads_app.ViewModels
{
	public class ToDoViewModel : BindableBase
	{
		private ObservableCollection<ToDoItemDto> toDoList;
		private bool showEditDrawer;

		public bool ShowEditDrawer
		{
			get { return showEditDrawer; }
			set { showEditDrawer = value; RaisePropertyChanged(); }
		}

		public ObservableCollection<ToDoItemDto> ToDoList
		{
			get { return toDoList; }
			set { toDoList = value; }
		}

		public DelegateCommand OpenTodoEditDrawerCommand { get; set; }
		public DelegateCommand CloseTodoEditDrawerCommand { get; set; }


        public ToDoViewModel()
		{
			OpenTodoEditDrawerCommand = new DelegateCommand(OpenTodoEditDrawer);
			CloseTodoEditDrawerCommand = new DelegateCommand(CloseTodoEditDrawer);

            ToDoList = new ObservableCollection<ToDoItemDto>();
		
			CreateToDoList();
		}

		void CreateToDoList()
		{
			for (int i = 0; i < 30; i++)
			{
				ToDoList.Add(new ToDoItemDto() { Title = $"学习WPF视频{i}", Content = "前往B站学校WPF学习视频、前往B站学校WPF学习视频", CreateTime = DateTime.Now, State = "正常" });
			}
		}
		void OpenTodoEditDrawer()
		{
			ShowEditDrawer = true;
        }
		void CloseTodoEditDrawer()
		{
			ShowEditDrawer = false;
		}
    }
}
