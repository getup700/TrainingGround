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

namespace WpfApp2.Views;

/// <summary>
/// AdornorView.xaml 的交互逻辑
/// </summary>
public partial class AdornorView : UserControl
{
    UIElement targetElement;
    public AdornorView()
    {
        InitializeComponent();
        targetElement = textBox;
    }

    private void clearAdornor_Click(object sender, RoutedEventArgs e)
    {
        // 获取元素所在的 AdornerLayer
        AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(targetElement);
        if (adornerLayer == null)
            return;

        // 获取该元素的所有装饰器
        Adorner[] adorners = adornerLayer.GetAdorners(targetElement);

        // 逐个移除装饰器
        if (adorners != null)
        {
            foreach (var adorner in adorners)
            {
                adornerLayer.Remove(adorner);
            }
        }
    }

    private void addAdornor_Click(object sender, RoutedEventArgs e)
    {
        // 获取目标元素的 AdornerLayer
        AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(targetElement);
        if (adornerLayer == null)
            return;

        // 清除已有的装饰器（可选）
        Adorner[] existingAdorners = adornerLayer.GetAdorners(targetElement);
        if (existingAdorners != null)
        {
            foreach (var adorner in existingAdorners)
            {
                adornerLayer.Remove(adorner);
            }
        }

        // 添加自定义装饰器
        adornerLayer.Add(new CustomAdorner(targetElement));
    }
}


// 自定义装饰器类
public class CustomAdorner : Adorner
{
    // 定义控制点的大小
    private const double HandleSize = 8;

    // 保存控制点（用于后续交互，如拖拽）
    private readonly Ellipse[] _handles;

    // 构造函数：关联被装饰的元素
    public CustomAdorner(UIElement adornedElement) : base(adornedElement)
    {
        // 初始化四个角的控制点
        _handles = new Ellipse[4];
        for (int i = 0; i < 4; i++)
        {
            _handles[i] = new Ellipse
            {
                Width = HandleSize,
                Height = HandleSize,
                Fill = Brushes.White,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            // 将控制点添加到装饰器的可视化树中
            AddVisualChild(_handles[i]);
        }
    }

    // 重写：指定子元素数量（用于布局）
    protected override int VisualChildrenCount => _handles.Length;

    // 重写：获取指定索引的子元素
    protected override Visual GetVisualChild(int index)
    {
        return _handles[index];
    }

    // 重写：布局逻辑（设置控制点位置）
    protected override Size ArrangeOverride(Size finalSize)
    {
        // 获取被装饰元素的位置和大小
        var adornedElementRect = new Rect(finalSize);

        // 计算四个角控制点的位置
        _handles[0].Arrange(new Rect(
            adornedElementRect.Left - HandleSize / 2,
            adornedElementRect.Top - HandleSize / 2,
            HandleSize, HandleSize));

        _handles[1].Arrange(new Rect(
            adornedElementRect.Right - HandleSize / 2,
            adornedElementRect.Top - HandleSize / 2,
            HandleSize, HandleSize));

        _handles[2].Arrange(new Rect(
            adornedElementRect.Left - HandleSize / 2,
            adornedElementRect.Bottom - HandleSize / 2,
            HandleSize, HandleSize));

        _handles[3].Arrange(new Rect(
            adornedElementRect.Right - HandleSize / 2,
            adornedElementRect.Bottom - HandleSize / 2,
            HandleSize, HandleSize));

        return finalSize;
    }

    // 重写：绘制装饰内容（如边框）
    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);

        var size = AdornedElement.RenderSize;
        // 绘制元素边框
        var adornedElementRect = new Rect(AdornedElement.RenderSize);
        var pen = new Pen(Brushes.Blue, 2) { DashStyle = DashStyles.Dash };
        drawingContext.DrawRectangle(Brushes.Transparent, pen, adornedElementRect);
    }
}
