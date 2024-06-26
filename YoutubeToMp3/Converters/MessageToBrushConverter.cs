﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace YoutubeToMp3
{
    public class MessageToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is SuccessMessage
                ? (SolidColorBrush)new BrushConverter().ConvertFrom("#66BB6A")
                : value is ErrorMessage ? (SolidColorBrush)new BrushConverter().ConvertFrom("#EF5350")
                : new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
