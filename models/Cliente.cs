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
        Cliente()
        {
            fechaActualizacion = DateTime.Now;
            id = 0;
            nombres = "no registra";
            cedula = "no registra";
            celular = "no registra";
            correo = "no registra";
        }
    }
}
