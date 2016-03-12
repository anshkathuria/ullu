using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Controls.RatingController
{
    class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var rating = (int)value;
            switch (rating)
            {
                case 1:
                    return "Disappointed!";
                case 2:
                    return "Not a fan!";
                case 3:
                    return "It's Ok!";
                case 4:
                    return "Like it!";
                case 5:
                    return "Love it!";
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
