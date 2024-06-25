using System.Text.RegularExpressions;
using FacturacionHogar.Application.Services.Extensions;

namespace FacturacionHogar.models.domain
{
    public class Client
    {
        private const string defaultEmail = "default@default.com";

        public long Id { get; set; }

        public string? FullName { get; set; }

        public string? Identification { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public DateTime UpdateDate { get; set; }

        public void SetDefaultExtraData() => this.Email = defaultEmail;

        public void NormalizeFullName()
        {
            this.FullName ??= string.Empty;

            this.FullName = this.FullName.RemoveDiacritics().ToLowerInvariant();
            this.FullName = Regex.Replace(this.FullName, @"[^a-zA-Z\s]", string.Empty);
            this.FullName = Regex.Replace(this.FullName, @"\s+", " ").Trim();
        }
    }
}
