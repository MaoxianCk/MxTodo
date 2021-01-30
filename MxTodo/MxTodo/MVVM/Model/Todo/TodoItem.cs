using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLite;
using System;

namespace MxTodo.MVVM.Model.Todo
{
    /// <summary>
    /// TODO 任务项, 同时也是数据库表结构
    /// </summary>
    public class TodoItem
    {
        private int id;
        private string content;
        private TodoStatus status;
        private DateTime createTime;
        private int sortIndex;

        public TodoItem()
        {
        }

        public TodoItem(string content, TodoStatus status = 0, int sortIndex = int.MaxValue) :
            this(content, status, sortIndex, DateTime.Now)
        { }

        public TodoItem(string content, TodoStatus status, int sortIndex, DateTime createTime)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(content));
            Assert.IsNotNull(createTime);

            this.content = content;
            this.status = status;
            this.sortIndex = sortIndex;
            this.createTime = createTime;
        }

        /// <summary>
        /// id
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// todo内容
        /// </summary>
        public string Content { get => content; set => content = value; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get => (int)status; set => status = (TodoStatus)value; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get => createTime; set => createTime = value; }

        /// <summary>
        /// 排序索引
        /// </summary>
        public int SortIndex { get => sortIndex; set => sortIndex = value; }
    }
}