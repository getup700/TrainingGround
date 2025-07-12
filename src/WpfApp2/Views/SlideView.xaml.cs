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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2.Views
{
    /// <summary>
    /// SlideView.xaml 的交互逻辑
    /// </summary>
    public partial class SlideView : UserControl
    {
        private double _startX;
        private int _currentPage = 0;
        private bool _isDragging = false;
        private readonly int _totalPages = 2;
        private double _pageWidth => RootGrid.ActualWidth;
        public SlideView()
        {
            InitializeComponent();

            InitializeEvents();
        }

        private void InitializeEvents()
        {
            // 触摸事件
            RootGrid.ManipulationStarted += RootGrid_ManipulationStarted;
            RootGrid.ManipulationDelta += RootGrid_ManipulationDelta;
            RootGrid.ManipulationCompleted += RootGrid_ManipulationCompleted;

            // 鼠标事件
            RootGrid.MouseLeftButtonDown += RootGrid_MouseLeftButtonDown;
            RootGrid.MouseMove += RootGrid_MouseMove;
            RootGrid.MouseLeftButtonUp += RootGrid_MouseLeftButtonUp;

            // 窗口大小改变时调整页面宽度
            SizeChanged += (s, e) => UpdatePagePositions();
        }

        private void UpdatePagePositions()
        {
            for (int i = 0; i < _totalPages; i++)
            {
                if (ContentPanel.Children[i] is FrameworkElement element)
                {
                    Canvas.SetLeft(element, _pageWidth * i);
                }
            }

            // 窗口大小变化时，重新定位到当前页
            AnimateToPage(_currentPage);
        }

        // 触摸事件处理
        private void RootGrid_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            _startX = e.ManipulationOrigin.X;
            _isDragging = true;
        }

        private void RootGrid_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            if (!_isDragging)
                return;

            double deltaX = e.DeltaManipulation.Translation.X;
            double newX = ContentTransform.X + deltaX;

            // 计算目标页面（根据滑动距离决定是当前页还是相邻页）
            double threshold = _pageWidth * 0.5;
            int targetPage = _currentPage;

            if (deltaX < -threshold && _currentPage < _totalPages - 1)
            {
                targetPage = _currentPage + 1;
            }
            else if (deltaX > threshold && _currentPage > 0)
            {
                targetPage = _currentPage - 1;
            }

            // 立即定位到目标页面（不显示过渡状态）
            ContentTransform.X = -_pageWidth * targetPage;
            e.Handled = true;
        }

        private void RootGrid_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            if (!_isDragging)
                return;

            _isDragging = false;
            double deltaX = e.TotalManipulation.Translation.X;

            // 判断是否切换页面
            double threshold = _pageWidth * 0.5;
            int targetPage = _currentPage;

            if (deltaX < -threshold && _currentPage < _totalPages - 1)
            {
                targetPage = _currentPage + 1;
            }
            else if (deltaX > threshold && _currentPage > 0)
            {
                targetPage = _currentPage - 1;
            }

            // 只有当页面确实变化时才更新
            if (targetPage != _currentPage)
            {
                _currentPage = targetPage;
                AnimateToPage(_currentPage);
                UpdateIndicators();
            }
        }

        // 鼠标事件处理
        private void RootGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startX = e.GetPosition(RootGrid).X;
            _isDragging = true;
            RootGrid.CaptureMouse();
        }

        private void RootGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragging || e.LeftButton != MouseButtonState.Pressed)
                return;

            double currentX = e.GetPosition(RootGrid).X;
            double deltaX = currentX - _startX;

            // 计算目标页面
            double threshold = _pageWidth * 0.5;
            int targetPage = _currentPage;

            if (deltaX < -threshold && _currentPage < _totalPages - 1)
            {
                targetPage = _currentPage + 1;
            }
            else if (deltaX > threshold && _currentPage > 0)
            {
                targetPage = _currentPage - 1;
            }

            // 立即定位到目标页面
            ContentTransform.X = -_pageWidth * targetPage;
            _startX = currentX;
        }

        private void RootGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!_isDragging)
                return;

            _isDragging = false;
            RootGrid.ReleaseMouseCapture();

            double endX = e.GetPosition(RootGrid).X;
            double deltaX = endX - _startX;

            // 判断是否切换页面
            double threshold = _pageWidth * 0.5;
            int targetPage = _currentPage;

            if (deltaX < -threshold && _currentPage < _totalPages - 1)
            {
                targetPage = _currentPage + 1;
            }
            else if (deltaX > threshold && _currentPage > 0)
            {
                targetPage = _currentPage - 1;
            }

            // 只有当页面确实变化时才更新
            if (targetPage != _currentPage)
            {
                _currentPage = targetPage;
                AnimateToPage(_currentPage);
                UpdateIndicators();
            }
        }

        // 页面切换动画
        private void AnimateToPage(int pageIndex)
        {
            double targetX = -_pageWidth * pageIndex;
            Storyboard storyboard = (Storyboard)Resources["SlideStoryboard"];
            DoubleAnimation animation = (DoubleAnimation)storyboard.Children[0];
            animation.To = targetX;

            // 应用动画到 Transform
            Storyboard.SetTarget(animation, ContentTransform);
            storyboard.Begin();
        }

        // 更新指示器状态
        private void UpdateIndicators()
        {
            StackPanel indicatorPanel = (StackPanel)RootGrid.Children[1];
            for (int i = 0; i < indicatorPanel.Children.Count; i++)
            {
                if (indicatorPanel.Children[i] is Ellipse ellipse)
                {
                    ellipse.Fill = i == _currentPage ? Brushes.White : Brushes.Gray;
                }
            }
        }
    }
}
