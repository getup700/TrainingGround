using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    class ComboBoxViewModel : ObservableProperty
    {
        public ObservableCollection<string> Items { get; set; }
        public string SelectedItem { get; set; }

        public ICommand SelectionChangedCommand { get; set; }

        public ComboBoxViewModel()
        {
            // 初始化集合和命令
            Items = new ObservableCollection<string> { "Item1", "Item2", "Item3" };

            SelectionChangedCommand = new RelayCommand<bool>(isUserInitiated =>
            {
                if (isUserInitiated)
                {
                    // 处理用户操作
                    Debug.WriteLine("用户选择了: " + SelectedItem);
                }
                else
                {
                    // 处理数据源变化
                    Debug.WriteLine("数据源更新为: " + SelectedItem);
                }
            });

            var list = new List<Student>() {
                new Student() { Name = "Omar",Age = 12, Hobby="play games"},
                new Student() { Name = "Dan",Age = 13, Hobby="play games"},
                new Student() { Name = "Lily",Age = 14, Hobby="play games"},
            };

            var result = list.Where(x => x.Age > 10);

        }

    }
}
