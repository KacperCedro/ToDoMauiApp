using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoDatabaseLibrary.Models;
using ToDoDatabaseLibrary;
using System.Windows.Input;

namespace ToDoMauiApp
{
    class ToDoViewModel:BindableObject
    {
        public DbRepository Repository { get; set; }

        public List<ToDoModel> toDoList;
        public List<ToDoModel> ToDoList
        {
            get { return toDoList; }
            set { toDoList = value; OnPropertyChanged(); }
        }
        public List<ToDoModel> deletedList;
        public List<ToDoModel> DeletedList
        {
            get { return deletedList; }
            set { deletedList = value; OnPropertyChanged(); }
        }

        private ToDoModel currentTask;

        public ToDoModel CurrentTask
        {
            get { return currentTask; }
            set { currentTask = value; OnPropertyChanged(); }
        }

        private string newContent;

        public string NewContent
        {
            get { return newContent; }
            set { newContent = value; }
        }

        public Command AddButton { get; set; }
        public Command DeleteButton { get; set; }
        public Command ChangeIcon { get; set; }

        public ToDoViewModel()
        {
            Repository = new DbRepository();
            ToDoList = Repository.GetToDo();
            DeletedList = Repository.GetDeletedToDo();
            AddButton = new Command(AddNewTask);
            DeleteButton = new Command(AddToDeletedTasks);
            ChangeIcon = new Command<ToDoModel>(ChangeTaskIcon);
        }

        public void AddNewTask()
        {
            if (NewContent != null)
            {
                Repository.AddNewToDo(NewContent);
            }
            ToDoList = Repository.GetToDo();

        }
        public void AddToDeletedTasks()
        {
            if (currentTask != null)
            {
                Repository.SetDeletedTrue(CurrentTask.Id);
            }
            ToDoList = Repository.GetToDo();
            DeletedList = Repository.GetDeletedToDo();
        }
        public void ChangeTaskIcon(ToDoModel model)
        {
            if (model != null)
            {
                Repository.SetDone(model.Id, !model.IsDone);
            }
            ToDoList = Repository.GetToDo();
        }
    }
}
