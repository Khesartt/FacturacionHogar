namespace FacturacionHogar.Dominio.modelos
{
    public class ReciboArrendamiento
    {
        public long id { get; set; }
        public long idCliente { get; set; }
        public string? valorArrendamiento { get; set; }
        public string? numeroRecibo { get; set; }
        public string? nombreCliente { get; set; }
        public string? valorArrendamientoLetra { get; set; }
        public string? descripcionArrendamiento { get; set; }
        public string? direccionArrendamiento { get; set; }
        public DateTime fechaRecibo { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }
        public DateTime fechaActualizacion { get; set; }

        public ReciboArrendamiento(long _idCliente,
            string _valorArrendamiento,
            string _numeroRecibo,
            string _nombreCliente,
            string _valorArrendamientoLetra,
            string _descripcionArrendamiento,
            string _direccionArrendamiento,
            DateTime _fechaRecibo,
            DateTime _fechaInicial,
            DateTime _fechaFinal)
        {
            id = 0;
            fechaActualizacion = DateTime.Now;
            idCliente = _idCliente;
            valorArrendamiento = _valorArrendamiento;
            numeroRecibo = _numeroRecibo;
            nombreCliente = _nombreCliente;
            valorArrendamientoLetra = _valorArrendamientoLetra;
            descripcionArrendamiento = _descripcionArrendamiento;
            direccionArrendamiento = _direccionArrendamiento;
            fechaRecibo = _fechaRecibo;
            fechaInicial = _fechaInicial;
            fechaFinal = _fechaFinal;
        }


        public ReciboArrendamiento()
        {


        }
    }
}
