namespace FacturacionHogar.models.DTO_s
{
    public class PdfArriendoDto
    {
        /// <example>800000</example>
        public string? valorArrendamiento { get; set; }

        /// <example>21</example>
        public string? numeroRecibo { get; set; }

        /// <example>2023-10-24</example>
        public DateTime fechaRecibo { get; set; }

        /// <example>Jose Antonio</example>
        public string? nombreCliente { get; set; }

        /// <example>Ochocientos Mil Pesos M/c</example>
        public string? valorArrendamientoLetra { get; set; }

        /// <example>Alcoba y cocina</example>
        public string? descripcionArrendamiento { get; set; }

        /// <example>Carrera 73a #68a 17 primer piso</example>
        public string? direccionArrendamiento { get; set; }

        /// <example>2023-01-03</example>
        public DateTime fechaInicial { get; set; }

        /// <example>2023-02-04</example>
        public DateTime fechaFinal { get; set; }
    }
}
