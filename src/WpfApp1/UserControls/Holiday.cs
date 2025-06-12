using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.UserControls;

public class Holiday
{
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public bool IsOfficial { get; set; } // 是否为法定节假日
}
