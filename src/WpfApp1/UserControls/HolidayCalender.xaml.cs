using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.UserControls
{
    /// <summary>
    /// HolidayCalender.xaml 的交互逻辑
    /// </summary>
    public partial class HolidayCalender : UserControl
    {
        // 节假日列表
        private List<Holiday> _holidays = new List<Holiday>();

        public HolidayCalender()
        {
            InitializeComponent();
        }

        private void InitializeHolidays()
        {
            // 添加示例节假日数据
            _holidays.Add(new Holiday { Date = new DateTime(DateTime.Now.Year, 1, 1), Name = "元旦", IsOfficial = true });
            _holidays.Add(new Holiday { Date = new DateTime(DateTime.Now.Year, 5, 1), Name = "劳动节", IsOfficial = true });
            _holidays.Add(new Holiday { Date = new DateTime(DateTime.Now.Year, 10, 1), Name = "国庆节", IsOfficial = true });

        }
    }
}
