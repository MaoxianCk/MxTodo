namespace MxTodo.MVVM.Model.Todo
{
    /// <summary>
    /// todo项的状态
    /// </summary>
    public enum TodoStatus
    {
        /// <summary>
        /// 未完成
        /// </summary>
        Unfinished = 0,

        /// <summary>
        /// 完成
        /// </summary>
        Finished = 1,

        /// <summary>
        /// 已删除
        /// </summary>
        Deleted = 2
    }
}