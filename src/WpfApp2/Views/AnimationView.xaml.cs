using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.UI.Composition;
using Canvas = System.Windows.Controls.Canvas;

namespace WpfApp2.Views
{
    /// <summary>
    /// AnimationView.xaml 的交互逻辑
    /// </summary>
    public partial class AnimationView : UserControl
    {
        private Storyboard _sb;
        private Storyboard _pathSb;
        public AnimationView()
        {
            InitializeComponent();
            CreateAnimation(); CreatePathAnimation();
        }

        private void CreateAnimation()
        {
            //创建动画
            var doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 1;
            doubleAnimation.To = 0;

            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(4));

            //创建故事板
            _sb = new Storyboard();
            _sb.Children.Add(doubleAnimation);
            Storyboard.SetTargetName(doubleAnimation, "toggle");
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(TextBlock.OpacityProperty));

        }

        private void CreatePathAnimation()
        {
            var pathGeometry = new PathGeometry();
            var pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(50, 50);

            //pathFigure.Segments.Add(new BezierSegment(
            //   new Point(200, 100),   // 控制点1
            //   new Point(300, 300),   // 控制点2
            //   new Point(500, 50),    // 终点
            //   true
            //));
            //pathFigure.Segments.Add(new LineSegment(new Point(200, 50), isStroked: true));
            //pathFigure.Segments.Add(new LineSegment(new Point(200, 200), isStroked: true));

            pathFigure.Segments.Add(new QuadraticBezierSegment(
    new Point(200, 150),  // 唯一控制点
    new Point(350, 50),   // 终点
    isStroked: true
));
            pathGeometry.Figures.Add(pathFigure);

            var path = new Path();
            path.Data = pathGeometry;
            path.Stroke = Brushes.Blue;
            path.StrokeThickness = 1;

            canvas.Children.Add(path);

            var animationX = new DoubleAnimationUsingPath();
            animationX.PathGeometry = pathGeometry;
            animationX.Source = PathAnimationSource.X;
            animationX.Duration = TimeSpan.FromSeconds(4);
            animationX.RepeatBehavior = RepeatBehavior.Forever;

            var animationY = new DoubleAnimationUsingPath();
            animationY.PathGeometry = pathGeometry;
            animationY.Source = PathAnimationSource.Y;
            animationY.Duration = TimeSpan.FromSeconds(4);
            animationY.RepeatBehavior = RepeatBehavior.Forever;

            ellipse.BeginAnimation(Canvas.LeftProperty, animationX);
            ellipse.BeginAnimation(Canvas.TopProperty, animationY);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _sb.Pause(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _sb.Resume(this);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _sb.Begin(this);
        }
    }
}
