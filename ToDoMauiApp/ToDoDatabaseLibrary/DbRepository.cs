using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoDatabaseLibrary.Migrations;
using ToDoDatabaseLibrary.Models;

namespace ToDoDatabaseLibrary
{
    public class DbRepository
    {
        public ToDoListDBContext DbContext { get; set; }
        public DbRepository()
        {
            DbContext = new ToDoListDBContext();
        }

        public List<ToDoModel> GetToDo()
        {
            return DbContext.ToDoLists.AsNoTracking().Where(t => t.IsDeleted == false).ToList();
        }
        public List<ToDoModel> GetDeletedToDo()
        {
            return DbContext.ToDoLists.AsNoTracking().Where(t => t.IsDeleted == true).ToList();
        }
        public void UpdateContent(int id, string content)
        {
            ToDoModel? toDo = DbContext.ToDoLists.FirstOrDefault(t => t.Id == id);
            if (toDo != null)
            {
                toDo.Content = content;
                DbContext.SaveChanges();
            }
        }
        public void UpdateToDo(int id, string content, bool isDone, bool isDeleted)
        {
            ToDoModel? toDo = DbContext.ToDoLists.FirstOrDefault(t => t.Id == id);
            if (toDo != null)
            {
                toDo.Content = content;
                toDo.IsDone = isDone;
                toDo.IsDeleted = isDeleted;
                DbContext.SaveChanges();
            }
        }
        public void SetDeletedTrue(int id)
        {
            ToDoModel? toDo = DbContext.ToDoLists.FirstOrDefault(t => t.Id == id);
            if (toDo != null)
            {
                toDo.IsDeleted = true;
                DbContext.SaveChanges();
            }
        }
        public void SetDone(int id, bool isDone)
        {
            ToDoModel? toDo = DbContext.ToDoLists.FirstOrDefault(t => t.Id == id);
            if (toDo != null)
            {
                toDo.IsDone = isDone;
                DbContext.SaveChanges();
            }
        }
        public void AddNewToDo(string content)
        {
            DbContext.ToDoLists.Add(new ToDoModel() {Content = content, IsDeleted = false, IsDone = false });
            DbContext.SaveChanges();
        }
        public void DeleteToDo(int id)
        {
            ToDoModel? toDo = DbContext.ToDoLists.FirstOrDefault(t => t.Id == id);
            if (toDo != null)
            {
                DbContext.ToDoLists.Remove(toDo);
                DbContext.SaveChanges();
            }
        }

    }
}
