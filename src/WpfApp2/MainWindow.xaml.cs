using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReportTimeHandler(object sender, CustomControls.ReportTimeEventArgs e)
        {
            var senderName = (sender as FrameworkElement)?.Name;
            if(senderName == "dockPanel")
            {
                e.Handled = true;
            }
            listBox.Items.Add($"Report time: {e.ClickTime:HH-mm-ss:fff}, Sender: {(sender as FrameworkElement)?.Name}");
        }
    }
}