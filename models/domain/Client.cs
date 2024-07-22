using System.Text.RegularExpressions;
using FacturacionHogar.Application.Services.Extensions;

namespace FacturacionHogar.models.domain
{
    public class Client
    {
        private const string defaultEmail = "default@default.com";

        public Client(string name)
        {
            this.SetDefaultExtraData();
            this.FullName = name;
            this.UpdateDate = DateTime.Now;
        }

        public Client()
        {
        }

        public long Id { get; set; }

        public string? FullName { get; set; }

        public string? Identification { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public DateTime UpdateDate { get; set; }

        public void SetDefaultExtraData() => this.Email = defaultEmail;
    }
}
