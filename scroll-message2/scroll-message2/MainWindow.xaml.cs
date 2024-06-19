using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace scroll_message2
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeAnimation();
        }
        private void InitializeAnimation()
        {
            var startLeft = canvas.Width;

            // テキストのサイズを算出
            var typeface = new Typeface(textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch);
            var formattedText = new FormattedText(textBlock.Text, Thread.CurrentThread.CurrentCulture, textBlock.FlowDirection, typeface, textBlock.FontSize, textBlock.Foreground, VisualTreeHelper.GetDpi(textBlock).PixelsPerDip);
            var size = new Size(formattedText.Width, formattedText.Height);

            var animation = new DoubleAnimation()
            {
                From = canvas.Width,
                To = -size.Width,
                Duration = new Duration(TimeSpan.FromMilliseconds(10 * (size.Width + canvas.Width))),
                RepeatBehavior = RepeatBehavior.Forever,
            };
            Storyboard.SetTarget(animation, textBlock);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Canvas.Left)"));

            var storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}
