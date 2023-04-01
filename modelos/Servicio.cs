namespace FacturacionHogar.Dominio.modelos
{
    public class Servicio
    {
        public long id { get; set; }
        public string? medicionBackUp { get; set; }
        public string? medicionAnterior { get; set; }
        public string? medicionActual { get; set; }
        public long idCliente { get; set; }
        public long idParametric { get; set; }
        public DateTime fechaActualizacion { get; set; }

    }
}
