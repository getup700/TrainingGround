using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2.CustomControls
{
    public class ReportTimeEventArgs : RoutedEventArgs
    {
        public DateTime ClickTime { get; set; }
        public ReportTimeEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
            
        }

    }

    public class TimeButton : Button
    {
        // 声明和注册路由事件
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent(
            "ReportTime",
            RoutingStrategy.Bubble,
            typeof(EventHandler<ReportTimeEventArgs>),
            typeof(TimeButton));

        //CLR event wrapper
        public event EventHandler<ReportTimeEventArgs> ReportTime
        {
            add { AddHandler(ReportTimeEvent, value); }
            remove { RemoveHandler(ReportTimeEvent, value); }
        }

        // 重写OnClick方法以触发自定义事件
        protected override void OnClick()
        {
            base.OnClick();
            // 创建事件参数并设置点击时间
            var args = new ReportTimeEventArgs(ReportTimeEvent, this)
            {
                ClickTime = DateTime.Now
            };
            // 触发自定义事件
            RaiseEvent(args);
        }





    }
}
