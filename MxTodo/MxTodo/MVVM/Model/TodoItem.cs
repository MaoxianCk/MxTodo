using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxTodo.MVVM.Model
{
    /// <summary>
    /// TODO 任务项
    /// </summary>
    public class TodoItem
    {
        private string content;
        private byte status;
        private DateTime createTime;
        private int sortIndex;

        public TodoItem(string content, byte status = 0, int sortIndex = int.MaxValue) :
            this(content, status, sortIndex, DateTime.Now)
        { }

        public TodoItem(string content, byte status, int sortIndex, DateTime createTime)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(content));
            Assert.IsNotNull(createTime);

            this.content = content;
            this.status = status;
            this.sortIndex = sortIndex;
            this.createTime = createTime;
        }

        /// <summary>
        /// todo内容
        /// </summary>
        public string Content { get => content; set => content = value; }

        /// <summary>
        /// 状态
        /// 0:未完成,1:完成,2:删除
        /// </summary>
        public byte Status { get => status; set => status = value; }

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
