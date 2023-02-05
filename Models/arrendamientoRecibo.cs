namespace FacturacionHogar.Models
{
    public class arrendamientoRecibo
    {
        public string valorArrendamiento { get; set; }
        public string numeroDeRecibo { get; set; }
        public DateTime fechaRecibo { get; set; }
        public string nombreCliente { get; set; }
        public string valorArrendamientoLetra { get; set; }
        public string descripcionArrendamiento { get; set; }
        public string direccionArrendamiento { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }

    }
}
