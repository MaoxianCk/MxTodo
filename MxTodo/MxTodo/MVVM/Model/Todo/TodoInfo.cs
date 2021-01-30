using MxTodo.MVVM.Dao;
using System.Collections.Generic;

namespace MxTodo.MVVM.Model.Todo
{
    public class TodoInfo
    {
        /// <summary>
        /// 默认是未完成任务列表
        /// </summary>
        private TodoStatus nowStatus = TodoStatus.Unfinished;

        public TodoStatus NowStatus { get { return nowStatus; } }

        private static TodoInfo instance = new TodoInfo();

        public static TodoInfo getInstance()
        {
            return instance;
        }

        private TodoInfo()
        {
            UpdateList();
        }

        private List<TodoItem> displayList;

        /// <summary>
        /// 当前显示的列表
        /// </summary>
        public List<TodoItem> DisplayList
        {
            get
            {
                return displayList;
            }
        }

        /// <summary>
        /// 更新当前状态的列表
        /// </summary>
        public void UpdateList()
        {
            UpdateList(NowStatus);
        }

        /// <summary>
        /// 根据状态更新对应的列表
        /// </summary>
        /// <param name="status">需要更新displayList为什么状态</param>
        public void UpdateList(TodoStatus status)
        {
            displayList = TodoDao.selectByStatus(status);
        }
    }
}