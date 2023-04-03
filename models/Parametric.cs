namespace FacturacionHogar.Dominio.modelos
{
    public class Parametric
    {
        public long id { get; set; }
        public string? tipo { get; set; }
        public string? valor { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public Parametric(string _tipo, string _valor)
        {
            id = 0;
            tipo = _tipo;
            valor = _valor;
            fechaActualizacion = DateTime.Now;
        }
        public Parametric()
        {
        }
    }
}
