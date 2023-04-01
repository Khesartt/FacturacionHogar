using System.Text.Json.Serialization;

namespace FacturacionHogar.Dominio.modelos
{
    public class Cliente
    {
        public long id { get; set; }
        public string? nombres { get; set; }
        public string? cedula { get; set; }
        public string? celular { get; set; }
        public string? correo { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public Cliente(string _nombres, string _cedula, string _celular, string _correo)
        {
            fechaActualizacion = DateTime.Now;
            id = 0;
            nombres = _nombres;
            cedula = _cedula;
            celular = _celular;
            correo = _correo;
        }
        public Cliente()
        {
        }
    }
}
