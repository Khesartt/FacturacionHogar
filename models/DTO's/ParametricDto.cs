namespace FacturacionHogar.models.DTO_s
{
    public class ParametricCreateDto
    {
        public long id { get; set; }
        public string? tipo { get; set; }
        public string? valor { get; set; }
        public DateTime fechaActualizacion { get; set; }

    }
    public class ParametricUpdateDto
    {
        public long id { get; set; }
        public string? tipo { get; set; }
        public string? valor { get; set; }
        public DateTime fechaActualizacion { get; set; }

    }
}
