using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Slider.Resources;

namespace Slider
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Thickness _marginCursor;
        private double _containerSliderWidth;
        private double _cursorWidth;

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            _containerSliderWidth = ContainerSlider5.ActualWidth;
            _cursorWidth = Cursor5.Width;
        }

        private void Slider5_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Slider5 != null)
                Cursor5.Margin = SetCursorMargin(_containerSliderWidth, _cursorWidth, e.NewValue);
        }

        private Thickness SetCursorMargin(double containerWidth, double thumbWidth, double sliderValue)
        {
            double cursorWidthHalf = thumbWidth / 2;
            if (sliderValue < cursorWidthHalf)
                _marginCursor.Left = -sliderValue;
            else if (sliderValue > containerWidth - cursorWidthHalf)
                _marginCursor.Left = -(thumbWidth + sliderValue - containerWidth);
            else
                _marginCursor.Left = -thumbWidth / 2;
            return _marginCursor;
        }
    }
}