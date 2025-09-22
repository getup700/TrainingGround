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

public enum WaterDirection { W, E,WE }


/// <summary>
/// WaterPipeAnimationView.xaml 的交互逻辑
/// </summary>
public partial class WaterPipeAnimationView : UserControl
{
    public WaterPipeAnimationView()
    {
        InitializeComponent();
        this.Loaded += (_, _) =>
        {
            VisualStateManager.GoToState(this,   "EWFlowState", false);
        };
    }

    /// <summary>
    /// 流水方向
    /// </summary>
    public WaterDirection Direction
    {
        get { return (WaterDirection)GetValue(DirectionProperty); }

        set { SetValue(DirectionProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Direction.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DirectionProperty =
        DependencyProperty.Register("Direction", typeof(WaterDirection), typeof(WaterPipeAnimationView), new PropertyMetadata(default(WaterDirection), new PropertyChangedCallback(OnDirectionChanged)));

    private static void OnDirectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        WaterDirection value = (WaterDirection)e.NewValue;
        VisualStateManager.GoToState(d as WaterPipeAnimationView, value == WaterDirection.WE ? "WEFlowState" : "EWFlowState", false);
    }


    /// <summary>
    /// 颜色
    /// </summary>
    public Brush LiquidColor
    {
        get { return (Brush)GetValue(LiquidColorProperty); }
        set { SetValue(LiquidColorProperty, value); }
    }

    // Using a DependencyProperty as the backing store for LiquidColor.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty LiquidColorProperty =
        DependencyProperty.Register("LiquidColor", typeof(Brush), typeof(WaterPipeAnimationView), new PropertyMetadata(Brushes.Orange));




    public int CapRadius
    {
        get { return (int)GetValue(CapRadiusProperty); }
        set { SetValue(CapRadiusProperty, value); }
    }

    // Using a DependencyProperty as the backing store for CapRadius.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CapRadiusProperty =
        DependencyProperty.Register("CapRadius", typeof(int), typeof(WaterPipeAnimationView), new PropertyMetadata(0));





}
