using Microsoft.VisualStudio.TestTools.UnitTesting;
using MxTodo.Common;
using MxTodo.MVVM.Model.Todo;
using System;
using System.Windows.Threading;

namespace MxTodo
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            InitNowTimeTimer();
        }

        #region NowTime 当前时间

        private DispatcherTimer nowTimeTimer;

        private void InitNowTimeTimer()
        {
            // Init方法只能执行一次
            Assert.IsNull(nowTimeTimer);
            nowTimeTimer = new DispatcherTimer();
            nowTimeTimer.Tick += UpdateTime;
            nowTimeTimer.Interval = new TimeSpan(300);
            nowTimeTimer.Start();
        }

        /// <summary>
        /// 返回当前时间
        /// </summary>
        public DateTime NowTime
        {
            get
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        private void UpdateTime(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(NowTime));
        }

        #endregion NowTime 当前时间

        #region 当前时间字体大小

        private int timeFontSize;

        public int TimeFontSize
        {
            get
            {
                return timeFontSize;
            }
            set
            {
                timeFontSize = value;
                OnPropertyChanged(nameof(TimeFontSize));
            }
        }

        #endregion 当前时间字体大小

        #region TodoList
        public TodoInfo todoInfo = TodoInfo.GetInstance();
        #endregion
    }
}