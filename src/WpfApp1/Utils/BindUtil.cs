using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WpfApp1.Utils
{
    internal class BindUtil
    {
        public static void SetBinding(Run control, string key)
        {
            object tempObj = Application.Current.TryFindResource(key);
            if (tempObj != null)
            {
                Application.Current.Dispatcher.BeginInvoke(() =>
                {
                    //建立control的text属性与动态资源key的绑定，后续修改动态资源值后text会自动修改
                    control.SetResourceReference(Run.TextProperty, key);
                });

            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(() =>
                {
                    control.Text = key;
                });

            }
        }

        public static void SetBinding(TextBlock control, string key)
        {
            object tempObj = Application.Current.TryFindResource(key);
            if (tempObj != null)
            {
                Application.Current.Dispatcher.BeginInvoke(() =>
                {
                    control.SetResourceReference(TextBlock.TextProperty, key);
                });
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(() =>
                {
                    control.Text = key;
                });
            }
        }
    }
}
