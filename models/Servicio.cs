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

        public Servicio(string _medicionAnterior, string _medicionActual, long _idCliente, long _idParametric)
        {
            id = 0;
            medicionBackUp = _medicionAnterior;
            fechaActualizacion = DateTime.Now;
            medicionAnterior = _medicionAnterior;
            medicionActual = _medicionActual;
            idCliente = _idCliente;
            idParametric = _idParametric;
        }
        public Servicio()
        {
        }

    }

}
