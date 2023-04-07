namespace FacturacionHogar.models.DTO_s
{
    public class ServicioCreateDto
    {
        /// <example>200.125</example>
        public string? medicionAnterior { get; set; }

        /// <example>400.125</example>
        public string? medicionActual { get; set; }

        /// <example>1</example>
        public long idCliente { get; set; }

        /// <example>2</example>
        public long idParametric { get; set; }

    }
    public class ServicioUpdateDto
    {
        /// <example>7</example>
        public long id { get; set; }

        /// <example>200.125</example>
        public string? medicionAnterior { get; set; }


        /// <example>400.125</example>
        public string? medicionActual { get; set; }


        /// <example>1</example>
        public long idCliente { get; set; }


        /// <example>2</example>
        public long idParametric { get; set; }


    }
}

