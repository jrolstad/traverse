using System;
using System.Globalization;
using CsvHelper.TypeConversion;

namespace traverse.domain.services.gtfs.class_maps.converters
{
    public class YyyymmddDateConverter:ITypeConverter
    {
        public string ConvertToString(TypeConverterOptions options, object value)
        {
            throw new NotImplementedException();
        }

        public object ConvertFromString(TypeConverterOptions options, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new DateTime?();

            var value = ParseDate(options, text);

            return value;
        }

        private static DateTime ParseDate(TypeConverterOptions options, string text)
        {
            DateTime value;
            if (options != null && options.DateTimeStyle.HasValue)
            {
                value = DateTime.ParseExact(text, "yyyyMMdd", CultureInfo.InvariantCulture, options.DateTimeStyle.Value);
            }
            else
            {
                value = DateTime.ParseExact(text, "yyyyMMdd", CultureInfo.InvariantCulture);
            }
            return value;
        }

        public bool CanConvertFrom(Type type)
        {
            return true;
        }

        public bool CanConvertTo(Type type)
        {
            return true;
        }
    }
}