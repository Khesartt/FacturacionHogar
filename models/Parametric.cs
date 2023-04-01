namespace FacturacionHogar.Dominio.modelos
{
    public class Parametric
    {
        public long id { get; set; }
        public string? tipo { get; set; }
        public string? valor { get; set; }
        public DateTime fechaActualizacion { get; set; }
        Parametric()
        {
            id = 0;
            tipo = "no registra";
            valor = "no registra";
            fechaActualizacion = DateTime.Now;
        }
    }
}
