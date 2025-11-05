using System.Reflection;
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

namespace WpfAnimation
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                Naviaget(btn);
            }
        }

        private void Naviaget(Button btn)
        {
            var views = GetViews();
            var type = views.FirstOrDefault(x => x.Name == btn.Content.ToString());
            if (type != null)
            {
                var us = CreateUserControlInstance(type);
                this.MainRegion.Content = us;
            }
        }

        private IEnumerable<Type> GetViews()
        {
            // 获取当前程序集（若目标类型在其他程序集，需加载对应程序集）
            Assembly assembly = Assembly.GetExecutingAssembly();
            // 若类型在外部程序集，可使用 Assembly.LoadFrom("程序集路径") 加载

            // 筛选继承自UserControl且命名空间包含"Views"的类型
            var userControlTypes = assembly.GetTypes()
                .Where(type =>
                    // 判断是否继承自UserControl（排除抽象类）
                    type.IsSubclassOf(typeof(UserControl)) && !type.IsAbstract
                    // 命名空间包含"Views"（匹配Views文件夹对应的命名空间）
                    && type.Namespace != null && type.Namespace.Contains(".Views")
                );
            return userControlTypes;
        }

        public static UserControl CreateUserControlInstance(Type controlType)
        {
            if (controlType == null)
                throw new ArgumentNullException(nameof(controlType));

            if (!typeof(UserControl).IsAssignableFrom(controlType))
                throw new ArgumentException("类型必须继承自UserControl", nameof(controlType));

            try
            {
                // 无参构造函数创建实例
                return (UserControl)Activator.CreateInstance(controlType);
            }
            catch (MissingMethodException)
            {
                // 处理无无参构造函数的情况（尝试找其他构造函数）
                return CreateInstanceWithParameters(controlType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"创建实例失败：{ex.Message}");
                return null;
            }
        }

        private static UserControl CreateInstanceWithParameters(Type controlType)
        {
            // 获取所有公共构造函数
            ConstructorInfo[] constructors = controlType.GetConstructors();

            // 示例：尝试匹配带一个string参数的构造函数（根据实际需求修改参数类型）
            ConstructorInfo targetConstructor = constructors
                .FirstOrDefault(c =>
                    c.GetParameters().Length == 1
                    && c.GetParameters()[0].ParameterType == typeof(string)
                );

            if (targetConstructor != null)
            {
                // 传入参数值（示例：传入空字符串，需根据实际逻辑调整）
                return (UserControl)targetConstructor.Invoke(new object[] { "" });
            }

            // 若找不到匹配的构造函数，可继续扩展其他参数组合，或抛出异常
            throw new InvalidOperationException($"类型 {controlType.Name} 没有可匹配的构造函数");
        }
    }
}