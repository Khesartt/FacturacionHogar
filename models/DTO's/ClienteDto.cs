using Swashbuckle.AspNetCore.Annotations;
namespace FacturacionHogar.models.DTO_s
{

    public class ClienteCreateDto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <example>Cesar Luis Reyes Lopez</example>
        public string? nombres { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>1234567890</example>
        public string? cedula { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>1234567890</example>
        public string? celular { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>correo@hotmail.com</example>
        public string? correo { get; set; }
    }
    public class ClienteUpdateDto
    {
        public long id { get; set; }
        public string? nombres { get; set; }
        public string? cedula { get; set; }
        public string? celular { get; set; }
        public string? correo { get; set; }
    }
}
