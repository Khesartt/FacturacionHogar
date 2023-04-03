namespace FacturacionHogar.models.DTO_s
{
    public class ParametricCreateDto
    {
        /// <example>correo</example>
        public string? tipo { get; set; }

        /// <example>correro@correo.com</example>
        public string? valor { get; set; }

    }
    public class ParametricUpdateDto
    {
        /// <example>1</example>
        public long id { get; set; }

        /// <example>correo</example>
        public string? tipo { get; set; }

        /// <example>correro@correo.com</example>
        public string? valor { get; set; }

    }
}
