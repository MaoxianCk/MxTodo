using MxTodo.MVVM.Model.Todo;
using MxTodo.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxTodo.MVVM.Dao
{
    public class TodoDao
    {
        public static List<TodoItem> selectByStatus(TodoStatus status)
        {
            return DbHelper.Select<TodoItem>("select * from TodoItem where Status = ?", status);
        }
    }
}
