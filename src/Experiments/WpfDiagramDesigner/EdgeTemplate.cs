using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace WpfDiagramDesigner
{
    public class EdgeTemplate : DependencyObject
    {
        internal static readonly Pen DefaultPen;

        static EdgeTemplate()
        {
            DefaultPen = new Pen() { Brush = Brushes.Black, Thickness = 1.0 };
            DefaultPen.Freeze();
        }

        public Pen Pen
        {
            get { return (Pen)GetValue(PenProperty); }
            set { SetValue(PenProperty, value); }
        }

        public static readonly DependencyProperty PenProperty =
            DependencyProperty.Register("Pen", typeof(Pen), typeof(EdgeTemplate), new PropertyMetadata(DefaultPen));


        public object EdgeType
        {
            get { return (object)GetValue(EdgeTypeProperty); }
            set { SetValue(EdgeTypeProperty, value); }
        }

        public static readonly DependencyProperty EdgeTypeProperty =
            DependencyProperty.Register("EdgeType", typeof(object), typeof(EdgeTemplate), new PropertyMetadata(null));


    }
}
