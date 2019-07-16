using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFComponents
{
    public class ValueToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Math.Round(((double)value), 2).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Thermometer : ProgressBar
    {
        private Canvas canvas1;
        private Canvas canvas2;

        public static readonly DependencyProperty MajorDivisionCounterProperty = DependencyProperty.Register(
            "MajorDivisionCounter", typeof(int), typeof(Thermometer), new PropertyMetadata(10, (sender, e) =>
            {
                Thermometer t = sender as Thermometer;
                t.DrawScale();
            })
            );

        public int MajorDivisionCounter
        {
            get { return (int)this.GetValue(MajorDivisionCounterProperty); }
            set { this.SetValue(MajorDivisionCounterProperty, value); }
        }

        public static readonly DependencyProperty MinorDivisionCounterProperty = DependencyProperty.Register(
            "MinorDivisionCounter", typeof(int), typeof(Thermometer), new PropertyMetadata(10, (sender, e) =>
            {
                Thermometer t = sender as Thermometer;
                t.DrawScale();
            })
            );

        public int MinorDivisionCounter
        {
            get { return (int)this.GetValue(MinorDivisionCounterProperty); }
            set { this.SetValue(MinorDivisionCounterProperty, value); }
        }

        public static readonly DependencyProperty MajorScaleColorProperty = DependencyProperty.Register(
            "MajorScaleColor", typeof(Brush), typeof(Thermometer), new PropertyMetadata(Brushes.Red, null)
            );

        public Brush MajorScaleColor
        {
            get { return (Brush)this.GetValue(MajorScaleColorProperty); }
            set { this.SetValue(MajorScaleColorProperty, value); }
        }

        public static readonly DependencyProperty MinorScaleColorProperty = DependencyProperty.Register(
            "MinorScaleColor", typeof(Brush), typeof(Thermometer), new PropertyMetadata(Brushes.Black, null)
            );

        public Brush MinorScaleColor
        {
            get { return (Brush)this.GetValue(MinorScaleColorProperty); }
            set { this.SetValue(MinorScaleColorProperty, value); }
        }

        public static readonly DependencyProperty TextProeprty = DependencyProperty.Register(
            "Text", typeof(string), typeof(Thermometer), new PropertyMetadata(null)
            );

        public string Text
        {
            get { return (string)this.GetValue(TextProeprty); }
            set { this.SetValue(TextProeprty, value); }
        }

        public static readonly DependencyProperty IsLeftScaleVisibilityProperty = DependencyProperty.Register(
            "IsLeftScaleVisibility", typeof(Visibility), typeof(Thermometer), new PropertyMetadata(Visibility.Visible, (sender, e) => {
                Thermometer th = sender as Thermometer;
                if (th.canvas1 != null)
                    th.DrawScale();
            })
            );

        public Visibility IsLeftScaleVisibility
        {
            get { return (Visibility)this.GetValue(IsLeftScaleVisibilityProperty); }
            set { this.SetValue(IsLeftScaleVisibilityProperty, value); }
        }

        public static readonly DependencyProperty IsRightScaleVisibilityProperty = DependencyProperty.Register(
            "IsRightScaleVisibility", typeof(Visibility), typeof(Thermometer), new PropertyMetadata(Visibility.Visible, (sender, e) => {
                Thermometer th = sender as Thermometer;
                if (th.canvas2 != null)
                    th.DrawScale();
            })
            );

        public Visibility IsRightScaleVisibility
        {
            get { return (Visibility)this.GetValue(IsRightScaleVisibilityProperty); }
            set { this.SetValue(IsRightScaleVisibilityProperty, value); }
        }

        static Thermometer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Thermometer), new FrameworkPropertyMetadata(typeof(Thermometer)));
        }

        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);

            //if (valueText != null)
            //    valueText.Text = newValue.ToString("f2");

        }

        protected override void OnMaximumChanged(double oldMaximum, double newMaximum)
        {
            base.OnMaximumChanged(oldMaximum, newMaximum);

            this.DrawScale();
        }

        protected override void OnMinimumChanged(double oldMinimum, double newMinimum)
        {
            base.OnMinimumChanged(oldMinimum, newMinimum);

            this.DrawScale();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();


            //valueText = this.GetTemplateChild("ValueText") as TextBlock;
            //valueText.Text = this.Value.ToString("f2");

            canvas2 = this.GetTemplateChild("ScaleCanvas2") as Canvas;
            canvas1 = this.GetTemplateChild("ScaleCanvas1") as Canvas;
            canvas1.SizeChanged += (sender, e) => { DrawScale(); };
            canvas2.SizeChanged += (sender, e) => { DrawScale(); };
        }

        private void DrawScale()
        {
            if(canvas1 != null && this.IsLeftScaleVisibility == Visibility.Visible)
            {
                canvas1.Children.Clear();

                //总刻度数量
                int count = this.MajorDivisionCounter * (this.MinorDivisionCounter > 0 ? this.MinorDivisionCounter : 1);
                double division = canvas1.ActualHeight / count;
                int div = (int)(this.Maximum - this.Minimum) / this.MajorDivisionCounter;

                for (int i = 0; i <= count; i++)
                {
                    Rectangle rect1 = new Rectangle();
                    rect1.Width = i % this.MinorDivisionCounter == 0 ? 15 : (i % (this.MinorDivisionCounter / 2) == 0 ? 10 : 5);
                    rect1.Height = 1;
                    rect1.Fill = i % this.MinorDivisionCounter == 0 ? MajorScaleColor : MinorScaleColor;
                    Canvas.SetRight(rect1, 0);
                    Canvas.SetTop(rect1, canvas1.ActualHeight - i * division);
                    canvas1.Children.Add(rect1);

                    if (i % this.MinorDivisionCounter == 0)
                    {
                        TextBlock text1 = new TextBlock();
                        text1.Text = (this.Minimum + i / this.MinorDivisionCounter * div).ToString();
                        Canvas.SetRight(text1, 15);
                        Canvas.SetTop(text1, canvas1.ActualHeight - i * division - 8);
                        canvas1.Children.Add(text1);
                    }

                }
            };


            if (canvas2 != null && this.IsRightScaleVisibility == Visibility.Visible)
            {
                canvas2.Children.Clear();

                //总刻度数量
                int count = this.MajorDivisionCounter * (this.MinorDivisionCounter > 0 ? this.MinorDivisionCounter : 1);
                double division = canvas1.ActualHeight / count;
                int div = (int)(this.Maximum - this.Minimum) / this.MajorDivisionCounter;

                for (int i = 0; i <= count; i++)
                {
                    Rectangle rect2 = new Rectangle();
                    rect2.Width = i % this.MinorDivisionCounter == 0 ? 15 : (i % (this.MinorDivisionCounter / 2) == 0 ? 10 : 5);
                    rect2.Height = 1;
                    rect2.Fill = i % this.MinorDivisionCounter == 0 ? MajorScaleColor : MinorScaleColor;
                    Canvas.SetLeft(rect2, 0);
                    Canvas.SetTop(rect2, canvas2.ActualHeight - i * division);
                    canvas2.Children.Add(rect2);

                    if (i % this.MinorDivisionCounter == 0)
                    {
                        TextBlock text2 = new TextBlock();
                        text2.Text = (this.Minimum + i / this.MinorDivisionCounter * div).ToString();
                        Canvas.SetLeft(text2, 16);
                        Canvas.SetTop(text2, canvas2.ActualHeight - i * division - 8);
                        canvas2.Children.Add(text2);
                    }

                }
            };
        }
    }
}
