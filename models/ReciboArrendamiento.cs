namespace FacturacionHogar.Dominio.modelos
{
    public class ReciboArrendamiento
    {
        public long id { get; set; }
        public string? valorArrendamiento { get; set; }
        public string? numeroRecibo { get; set; }
        public DateTime fechaRecibo { get; set; }
        public string? nombreCliente { get; set; }
        public string? valorArrendamientoLetra { get; set; }
        public string? descripcionArrendamiento { get; set; }
        public string? direccionArrendamiento { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }
        public long idCliente { get; set; }
        public DateTime fechaActualizacion { get; set; }

        ReciboArrendamiento()
        {
            id = 0;
            fechaRecibo = new DateTime(1700, 01, 01);
            fechaInicial = new DateTime(1700, 01, 01);
            fechaFinal = new DateTime(1700, 01, 01);
            fechaActualizacion = DateTime.Now;
        }
    }
}
