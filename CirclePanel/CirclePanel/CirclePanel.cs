using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Size = Windows.Foundation.Size;

namespace CirclePanel
{
    public class CirclePanel : Panel
    {
        private double _radius;

        public static readonly DependencyProperty PropertyTypeProperty = DependencyProperty.Register(
            "Radius", typeof(double), typeof(CirclePanel), new PropertyMetadata(0.0, OnRadiusChanged));


        public double Radius
        {
            get => (double)GetValue(PropertyTypeProperty);
            set => SetValue(PropertyTypeProperty, value);
        }

        private static void OnRadiusChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var tar = (CirclePanel)obj;
            tar._radius = (double)e.NewValue;
            tar.InvalidateArrange();
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            double maxElementWidth = 0;
            foreach (var i in Children)
            {
                i.Measure(availableSize);
                maxElementWidth = Math.Max(maxElementWidth, i.DesiredSize.Width);
            }
            double panelWidth = maxElementWidth * 2 + _radius * 2;

            double width = Math.Min(panelWidth, availableSize.Width);
            double height = Math.Min(panelWidth, availableSize.Height);

            return new Size(width, height);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double degree = 0.0;
            double step = 2 * Math.PI / Children.Count;
            double cx = DesiredSize.Width / 2;
            double cy = DesiredSize.Height / 2;
            foreach (var i in Children)
            {
                double x = Math.Cos(degree) * _radius;
                double y = Math.Sin(degree) * _radius;

                i.RenderTransform = new RotateTransform
                {
                    Angle = degree * 180 / Math.PI,
                    CenterX = 0,
                    CenterY = 0
                };

                i.Arrange(new Rect(cx + x, cy + y, i.DesiredSize.Width, i.DesiredSize.Height));

                degree += step;
            }

            return finalSize;
        }
    }
}
