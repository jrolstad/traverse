using System;
using System.Drawing;
using CsvHelper.TypeConversion;

namespace traverse.domain.services.gtfs.class_maps.converters
{
    public class HexadecimalColorConverter:ITypeConverter
    {
        public string ConvertToString(TypeConverterOptions options, object value)
        {
            throw new NotImplementedException();
        }

        public object ConvertFromString(TypeConverterOptions options, string text)
        {
            var color = ColorTranslator.FromHtml(text);

            return color;
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