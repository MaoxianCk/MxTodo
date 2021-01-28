using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxTodo.Config
{
    /// <summary>
    /// 系统属性，应提供默认参数，运行后从用户文档中尝试获取自定义配置
    /// </summary>
    public static class MxProperty
    {
        public static PropertyDetail<bool> ShowClock { get; }

        public static PropertyDetail<string> ClockFormat { get; }


        static MxProperty()
        {
            ShowClock = new PropertyDetail<bool>(nameof(ShowClock), true, "显示时间", false, true);
            ClockFormat = new PropertyDetail<string>(nameof(ClockFormat), "hh:mm:ss", "时间格式", false, false);
        }
    }

    /// <summary>
    /// 属性项
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PropertyDetail<T>
    {
        /// <summary>
        /// 是否可显示
        /// </summary>
        public bool Display { get; }

        /// <summary>
        /// 该属性是否只读
        /// </summary>
        public bool ReadOnly { get; }

        /// <summary>
        /// 显示的名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 该属性的key，应该为对应的变量名
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// 默认值
        /// </summary>
        public T DefaultValue { get; }

        /// <summary>
        /// 实际值
        /// </summary>
        private T value;

        /// <summary>
        /// 实际值
        /// </summary>
        public T Value
        {
            get => value ?? DefaultValue;
            set
            {
                this.value = value;
            }
        }

        public PropertyDetail(string key, T defaultValue, string name, bool readOnly, bool display)
        {
            Assert.IsFalse(string.IsNullOrEmpty(key));
            Assert.IsFalse(string.IsNullOrEmpty(name));
            Key = key;
            DefaultValue = defaultValue;
            ReadOnly = readOnly;
            Display = display;
        }
    }
}
