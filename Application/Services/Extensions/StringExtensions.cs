using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace FacturacionHogar.Application.Services.Extensions
{
    public static class StringExtensions
    {

        public static string DateToString(this DateTime value, string format)
        {
            return value.Day.ToString(format);
        }

        public static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string NormalizeString(this string name)
        {
            string normalized = Regex.Replace(name, @"[^\w\s]", "");

            string NameNormalized = new string(normalized.Normalize(NormalizationForm.FormD)
                                                       .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                                                       .ToArray())
                                                       .Normalize(NormalizationForm.FormC);

            return NameNormalized;
        }
    }
}
