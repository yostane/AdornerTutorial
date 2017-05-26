using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MouseMoveAdorner
{
    class SampleAdorner : Adorner
    {
        private Rectangle child = null;
        private double offsetLeft = 0;
        private double offsetTop = 0;

        // Be sure to call the base class constructor.
        public SampleAdorner(UIElement adornedElement):base(adornedElement)
        {
            Rectangle rect = new Rectangle();
            rect.Fill = new SolidColorBrush(Colors.Aqua);
            rect.Width = 50;
            rect.Height = 50;
            rect.IsHitTestVisible = false;
            this.child = rect;
        }

        protected override Visual GetVisualChild(int index)
        {
            return this.child;
        }

        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            GeneralTransformGroup result = new GeneralTransformGroup();
            result.Children.Add(base.GetDesiredTransform(transform));
            result.Children.Add(new TranslateTransform(this.offsetLeft, this.offsetTop));
            return result;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            this.child.Arrange(new Rect(finalSize));
            return finalSize;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            this.child.Measure(constraint);
            return this.child.DesiredSize;
        }

        public double OffsetLeft
        {
            get { return this.offsetLeft; }
            set
            {
                this.offsetLeft = value;
                UpdateLocation();
            }
        }

        public void SetOffsets(double left, double top)
        {
            this.offsetLeft = left;
            this.offsetTop = top;
            this.UpdateLocation();
        }

        public double OffsetTop
        {
            get { return this.offsetTop; }
            set
            {
                this.offsetTop = value;
                UpdateLocation();
            }
        }

        private void UpdateLocation()
        {
            AdornerLayer adornerLayer = this.Parent as AdornerLayer;
            if (adornerLayer != null)
                adornerLayer.Update(this.AdornedElement);
        }
    }
}
