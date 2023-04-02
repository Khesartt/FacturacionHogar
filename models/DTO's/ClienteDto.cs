using Swashbuckle.AspNetCore.Annotations;
namespace FacturacionHogar.models.DTO_s
{

    public class ClienteCreateDto
    {
        /// <example>Cesar Luis Reyes Lopez</example>
        public string? nombres { get; set; }

        /// <example>1234567890</example>
        public string? cedula { get; set; }

        /// <example>1234567890</example>
        public string? celular { get; set; }

        /// <example>correo@hotmail.com</example>
        public string? correo { get; set; }
    }
    public class ClienteUpdateDto
    {
        /// <example>1</example>
        public long id { get; set; }

        /// <example>Cesar Luis Reyes Lopez</example>
        public string? nombres { get; set; }

        /// <example>1234567890</example>
        public string? cedula { get; set; }

        /// <example>1234567890</example>
        public string? celular { get; set; }

        /// <example>correo@hotmail.com</example>
        public string? correo { get; set; }
    }
}
