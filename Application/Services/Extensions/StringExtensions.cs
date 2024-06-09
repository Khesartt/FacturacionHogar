namespace FacturacionHogar.Application.Services.Extensions
{
    public static class StringExtensions
    {
        public static string DateToString(this DateTime value, string format)
        {
            return value.Day.ToString(format);
        }

    }
}
