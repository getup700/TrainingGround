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
using WpfApp2.Views;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> pages = new()
        {
            "GaussianBlur",
            "Animation",
            "ComboBox",
            "Slide",
            "AnimationText",
            "AnimationListBox"
        };

        public MainWindow()
        {
            InitializeComponent();
            this.ListBox.ItemsSource = pages;
            this.ListBox.SelectionChanged += ListBox_SelectionChanged;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var key = e.AddedItems[0] as string;
            var index = pages.IndexOf(key);
            switch (index)
            {
                case 0:
                    this.ContentRegion.Content = new GaussianBlurView();
                    break;
                case 1:
                    this.ContentRegion.Content = new AnimationView();
                    break;
                case 2:
                    this.ContentRegion.Content = new ComboBoxView();
                    break;
                case 3:
                    this.ContentRegion.Content = new SlideView();
                    break;
                case 4:
                    this.ContentRegion.Content = new AnimationTextView();
                    break;
                case 5:
                    this.ContentRegion.Content = new AnimationListBoxView();
                    break;
                default:
                    break;
            }
        }
        private void ReportTimeHandler(object sender, CustomControls.ReportTimeEventArgs e)
        {
            var senderName = (sender as FrameworkElement)?.Name;
            if (senderName == "dockPanel")
            {
                e.Handled = true;
            }
            //listBox.Items.Add($"Report time: {e.ClickTime:HH-mm-ss:fff}, Sender: {(sender as FrameworkElement)?.Name}");
        }

    }
}