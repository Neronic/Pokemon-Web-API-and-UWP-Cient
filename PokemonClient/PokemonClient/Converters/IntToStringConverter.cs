using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PokemonClient.Converters
{
    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value == null)
                {
                    return string.Empty;
                }
                return String.Format("{0:n0}", value);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                string val = value.ToString();
                string number = new string(val.Where(v => (char.IsDigit(v))).ToArray());
                return System.Convert.ToInt32(number);
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
